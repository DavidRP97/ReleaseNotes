using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using ReleaseNotes.Service.Interfaces;
using ReleaseNotes.Service.Services;
using ReleaseNotes.Web.Context;
using ReleaseNotes.Web.JWT;
using ReleaseNotes.Web.Repository;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

var connection = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContext<NpgSqlDbContext>(options => options.UseNpgsql(connection));

var identity = builder.Services.AddIdentity<ApplicationUser, IdentityRole>()
                .AddEntityFrameworkStores<NpgSqlDbContext>()
                .AddDefaultTokenProviders();

builder.Services.AddAuthentication(
                JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.SaveToken = true;
        options.TokenValidationParameters = new TokenValidationParameters
        {

            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidAudience = builder.Configuration["TokenConfiguration:Audience"],
            ValidIssuer = builder.Configuration["TokenConfiguration:Issuer"],
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(
                        Encoding.UTF8.GetBytes(builder.Configuration["Jwt:key"]))
        };
    });
    
                

builder.Services.AddSession();

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddHttpClient<IReleasePowerServerService, ReleasePowerServerService>(c =>
                c.BaseAddress = new Uri(builder.Configuration["ServiceUrls:ReleasePowerServer"])
            );
builder.Services.AddHttpClient<IReleasePDVService, ReleasePDVService>(c =>
                c.BaseAddress = new Uri(builder.Configuration["ServiceUrls:ReleasePDV"])
            );
builder.Services.AddScoped<ITokenGenerate, TokenGenerate>();
builder.Services.AddScoped<IUser, User>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.UseSession();

app.Use(async (context, next) =>
{
    var token = context.Session.GetString("JWTToken");
    if (!string.IsNullOrEmpty(token))
    {
        context.Request.Headers.Add("Authorization", "Bearer" + token);
    }
    await next();
});

app.UseAuthentication();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
