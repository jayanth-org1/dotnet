using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container (if needed)
builder.Services.AddControllers();

var app = builder.Build();

// Configure the HTTP request pipeline
app.MapControllers();

// Add a health check endpoint
app.MapGet("/", () => Results.Ok("Server is running"));

app.Run();
