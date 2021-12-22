using Microsoft.AspNetCore.Authentication;
using ReleaseNotes.Service.Interfaces;
using ReleaseNotes.Service.Services;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddHttpClient<IReleasePowerServerService, ReleasePowerServerService>(c =>
                c.BaseAddress = new Uri(builder.Configuration["ServiceUrls:ReleasePowerServer"])
            );
builder.Services.AddHttpClient<IReleasePDVService, ReleasePDVService>(c =>
                c.BaseAddress = new Uri(builder.Configuration["ServiceUrls:ReleasePDV"])

            );

builder.Services.AddAuthentication(options =>
{
    options.DefaultScheme = "Cookies";
    options.DefaultChallengeScheme = "oidc";
})
                .AddCookie("Cookies", c => c.ExpireTimeSpan = TimeSpan.FromMinutes(10))
                .AddOpenIdConnect("oidc", options =>
                {
                    options.Authority = builder.Configuration["ServiceUrls:IdentityServer"];
                    options.GetClaimsFromUserInfoEndpoint = true;
                    options.ClientId = "release_notes";
                    options.ClientSecret = "app_secret";
                    options.ResponseType = "code";
                    options.ClaimActions.MapJsonKey("role", "role", "role");
                    options.ClaimActions.MapJsonKey("sub", "sub", "sub");
                    options.TokenValidationParameters.NameClaimType = "name";
                    options.TokenValidationParameters.RoleClaimType = "role";
                    options.Scope.Add("release_notes");
                    options.SaveTokens = true;
                }
            );

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
