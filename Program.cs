using Microsoft.OpenApi.Models;
using RDK.Data.Extensions;
using Serilog;

var builder = WebApplication.CreateBuilder(args);
var @namespace = AppDomain.CurrentDomain.FriendlyName;

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();

// All Services Available in Data.Services
builder.Services.AddAllServicesAvailable(@namespace);

// Notification
builder.Services.AddRDKNotification();

// JS Functions Services
builder.Services.AddJSService();

// Logger
builder.Host.UseSerilog(Funpixart.Settings.InitializeSerilog());

// Custom URL
builder.WebHost.UseUrls(builder.Configuration["UseUrls"]);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
}

app.UsePathBase("/projects/funpixart-mc");

app.UseStaticFiles();
app.UseSerilogRequestLogging();
app.UseRouting();
app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();