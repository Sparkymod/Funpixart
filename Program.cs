using Microsoft.OpenApi.Models;
using RDK.Data.Extensions;
using Serilog;

var builder = WebApplication.CreateBuilder(args);
var @namespace = AppDomain.CurrentDomain.FriendlyName;

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
// Notification
builder.Services.AddRDKNotification();
// All Services Available in Data.Services
builder.Services.AddAllServicesAvailable(@namespace);
// Logger
builder.Host.UseSerilog(BSATemplateNet6.Settings.InitializeSerilog());
// Custom URL
builder.WebHost.UseUrls(builder.Configuration["UseUrls"]);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Version = "v1",
        Title = "BSATemplateApi Swagger",
        Description = "A Template Swagger doc for this template"
    });
});
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
}
app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Blazor API V1");
});

app.UseStaticFiles();
app.UseSerilogRequestLogging();
app.UseRouting();
app.MapBlazorHub();
app.MapFallbackToPage("{*path}", "/_Host");

app.Run();