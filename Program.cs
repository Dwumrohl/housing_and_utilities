using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using System.Net.NetworkInformation;
using testBlazor.Areas.Identity;
using testBlazor.Data;
using System.Data.SqlClient;
using testBlazor.Data.services;
using testBlazor.Data.security;
using Blazored.SessionStorage;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionString = builder.Configuration["housing_context"]; 
builder.Services.AddDbContext<HousingAndUtilitiesAppContext>(options =>
    options.UseNpgsql(connectionString));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();
builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<HousingAndUtilitiesAppContext>();
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();

builder.Services.AddScoped<AuthenticationStateProvider, RevalidatingIdentityAuthenticationStateProvider<IdentityUser>>();
builder.Services.AddScoped<IClientService, ClientService>();
builder.Services.AddScoped<IClientAddressService, ClientAddressService>();
builder.Services.AddScoped<IRequestService, RequestService>();
builder.Services.AddScoped<IMeterReadingsService, MeterReadingsService>();
builder.Services.AddBlazoredSessionStorage();
builder.Services.AddScoped<AuthenticationStateProvider,CustomAuthenticationStateProvider>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllers();
app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();
