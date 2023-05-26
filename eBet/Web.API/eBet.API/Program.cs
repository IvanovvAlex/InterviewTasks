using AutoMapper;
using eBet.API.Logger;
using eBet.API.Middlewares;
using eBet.Data;
using eBet.Data.Interfaces;
using eBet.Data.Interfaces.Repositories;
using eBet.Data.Repositories;
using eBet.Domain.Interfaces;
using eBet.Domain.Services;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using Microsoft.Win32;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Numerics;
using System.Runtime.Intrinsics.X86;
using System;

var builder = WebApplication.CreateBuilder(args);

// DB Context
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("AppDbConnectionString")));

// Add services to the container.
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

builder.Services.AddScoped<ISportRepository, SportRepository>();
builder.Services.AddScoped<IEventRepository, EventRepository>();
builder.Services.AddScoped<IMatchRepository, MatchRepository>();
builder.Services.AddScoped<IBetRepository, BetRepository>();
builder.Services.AddScoped<IOddRepository, OddRepository>();

builder.Services.AddTransient<ISportService, SportService>();
builder.Services.AddTransient<IEventService, EventService>();
builder.Services.AddTransient<IMatchService, MatchService>();
builder.Services.AddTransient<IBetService, BetService>();
builder.Services.AddTransient<IOddService, OddService>();

builder.Services.AddScoped<XmlPullingService>();
builder.Services.AddSingleton<PeriodicHostedService>();
builder.Services.AddHostedService(
    provider => provider.GetRequiredService<PeriodicHostedService>());

//builder.Services.AddSingleton<XmlPullingService>();
//builder.Services.AddHostedService(
//    provider => provider.GetRequiredService<XmlPullingService>());

//builder.Services.AddTransient<XmlPullingService>();

//builder.Services.AddHostedService<XmlPullingService>();
//builder.Services.AddScoped<IHostedService, XmlPullingService>();
//builder.Services.AddSingleton<IHostedService, XmlPullingService>();

//builder.Services.AddSingleton<Func<IServiceProvider, IXmlPullingServiceFactory>>(provider =>
//{
//    return scopedProvider =>
//    {
//        using (var scope = scopedProvider.CreateScope())
//        {
//            return scope.ServiceProvider.GetRequiredService<IXmlPullingServiceFactory>();
//        }
//    };
//});


// Automapper
builder.Services.AddAutoMapper(typeof(Program));


//builder.Services.AddControllersWithViews();
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Create the database if it doesn't exist
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var dbContext = services.GetService<AppDbContext>();
    await dbContext.Database.EnsureCreatedAsync();
    //await dbContext.Database.MigrateAsync();

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
