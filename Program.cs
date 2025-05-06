using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using HotelBookingAPI.Services.Interfaces;
using HotelBookingAPI.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container (if needed)
builder.Services.AddControllers();
builder.Services.AddScoped<IBookingService, BookingService>();
builder.Services.AddScoped<IRoomService, RoomService>();
builder.Services.AddScoped<IPaymentService, PaymentService>();
builder.Services.AddScoped<IEmailService, EmailService>();

var app = builder.Build();

// Configure the HTTP request pipeline
app.MapControllers();

// Add a health check endpoint
app.MapGet("/", () => Results.Ok("Server is running"));

app.Run();
