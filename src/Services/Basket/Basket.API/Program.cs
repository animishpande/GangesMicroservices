using Microsoft.AspNetCore.OpenApi;
using Scalar.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to application.
var assembly = typeof(Program).Assembly;
builder.Services.AddCarter();
builder.Services.AddMediatR(config =>
{
    config.RegisterServicesFromAssembly(assembly);
});
builder.Services.AddOpenApi(); 

var app = builder.Build();
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    // Expose the OpenAPI JSON endpoint
    app.MapOpenApi(); 
    // Enable Scalar UI at the default /scalar route
    app.MapScalarApiReference(); 
    // Optional: Automatically redirect the root URL to the Scalar documentation
    app.MapGet("/", () => Results.Redirect("/scalar"));
}
// Configure HTTP Request pipeline.
app.MapCarter();
app.Run();