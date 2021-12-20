using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using ReleaseNote.Identity.Initializer;
using ReleaseNote.Identity.JWT;
using Microsoft.Extensions.DependencyInjection;
using ReleaseNotes.Identity.Context;
using ReleaseNotes.Identity.IdentityConfig;
using ReleasesNote.Identity.Context;
using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();


var connection = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContext<NpgSqlContext>(options => options.UseNpgsql(connection));

builder.Services.AddIdentity<ApplicationUser, IdentityRole>()
                .AddEntityFrameworkStores<NpgSqlContext>()
                .AddDefaultTokenProviders();


builder.Services.AddScoped<ITokenGenerate, TokenGenerate>();

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

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
