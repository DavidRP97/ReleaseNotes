using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using ReleaseNotes.IdentityServer.Config;
using ReleaseNotes.IdentityServer.Context;
using ReleaseNotes.IdentityServer.Initializer;
using ReleaseNotes.IdentityServer.Model;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

var connection = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContext<NpgSqlContext>(options => options.UseNpgsql(connection));

builder.Services.AddIdentity<ApplicationUser, IdentityRole>()
    .AddEntityFrameworkStores<NpgSqlContext>()
    .AddDefaultTokenProviders();

var identity = builder.Services.AddIdentityServer(options =>
    {
        options.Events.RaiseErrorEvents = true;
        options.Events.RaiseInformationEvents = true;
        options.Events.RaiseFailureEvents = true;
        options.Events.RaiseSuccessEvents = true;
        options.EmitStaticAudienceClaim = true;
    }).AddInMemoryIdentityResources(IdentityConfig.IdentityResources)
        .AddInMemoryApiScopes(IdentityConfig.ApiScopes)
        .AddInMemoryClients(IdentityConfig.Clients)
        .AddAspNetIdentity<ApplicationUser>();

builder.Services.AddScoped<IDbInitializer, DbInitializer>();

identity.AddDeveloperSigningCredential();

var app = builder.Build();

var scope = app.Services.CreateScope();
var dbInitializer = scope.ServiceProvider.GetService<IDbInitializer>();
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

app.UseIdentityServer();

app.UseAuthorization();

dbInitializer.Initialize();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
