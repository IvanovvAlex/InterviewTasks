using AutoMapper;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using OnlineStore.API.Logger;
using OnlineStore.API.Middlewares;
using OnlineStore.Data;
using OnlineStore.Data.Interfaces;
using OnlineStore.Data.Interfaces.Repositories;
using OnlineStore.Data.Repositories;
using OnlineStore.Domain.Interfaces;
using OnlineStore.Domain.Services;

var builder = WebApplication.CreateBuilder(args);

// DB Context
builder.Services.AddDbContext<OnlineStoreDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("OnlineStoreDbConnectionString")));

// Add services to the container.
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

builder.Services.AddScoped<ICompanyRepository, CompanyRepository>();
builder.Services.AddScoped<IOrderRepository, OrderRepository>();
builder.Services.AddScoped<IProductRepository, ProductRepository>();

builder.Services.AddTransient<ICompanyService, CompanyService>();
builder.Services.AddTransient<IOrderService, OrderService>();
builder.Services.AddTransient<IProductService, ProductService>();

// Automapper
builder.Services.AddAutoMapper(typeof(Program));
//builder.Services.AddControllersWithViews();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

//builder.Services.AddDbContext<OnlineStoreDbContext>();

builder.Services.AddSwaggerGen();



var app = builder.Build();

// Create the database if it doesn't exist
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var dbContext = services.GetService<OnlineStoreDbContext>();
    //await dbContext.Database.EnsureCreatedAsync();
    await dbContext.Database.MigrateAsync();

}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

// global cors policy
app.UseCors(x => x
    .AllowAnyOrigin()
    .AllowAnyMethod()
    .AllowAnyHeader());

app.UseAuthorization();

app.MapControllers();

var logFilePath = "./Logger/Requests.log";
var fileLoggerProvider = new FileLoggerProvider(logFilePath);
var loggerFactory = LoggerFactory.Create(builder =>
{
    builder.AddProvider(fileLoggerProvider);
});
var logger = loggerFactory.CreateLogger("Requests");

// Register the middleware that logs each request
app.UseMiddleware<RequestLoggingMiddleware>(logger);

app.Run();