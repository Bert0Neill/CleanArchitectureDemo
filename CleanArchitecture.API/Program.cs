using AutoMapper;
using CleanArchitecture.API.Middleware;
using CleanArchitecture.Application.Interfaces;
using CleanArchitecture.Application.Services.Database;
using CleanArchitecture.Domain.Entities;
using CleanArchitecture.Infrastructure.Database;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using NLog.Web;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Logging.AddConsole();
var logger = NLog.Web.NLogBuilder.ConfigureNLog("nlog.config").GetCurrentClassLogger();

try
{
    logger.Info("init main");

    builder.Logging.ClearProviders();
    builder.Logging.SetMinimumLevel(Microsoft.Extensions.Logging.LogLevel.Trace);
    builder.Host.UseNLog();


    /************************************************
     * Add Swagger UI to services container
     ************************************************/
    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddSwaggerGen();

    /************************************************
     * Add connection string to services container - using EF pooling for performance
     ************************************************/
    builder.Services.AddDbContextPool<MusicContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

    /************************************************
     * Dependency Injection 
     ************************************************/
    builder.Services.AddScoped<IAlbumService, AlbumService>();
    builder.Services.AddScoped<IArtistService, ArtistService>();

    // Infrastructure DI only - API needs to DI into Application services
    builder.Services.AddScoped<IAlbumRepository, AlbumRepository>();
    builder.Services.AddScoped<IArtistRepository, ArtistRepository>();

    /************************************************
     Add AutoMaper DI to services container
     ************************************************/
    builder.Services.AddAutoMapper(typeof(Program));

    /*************************************************
   * Enable CORS
   *************************************************/
    builder.Services.AddCors(policy =>
    {
        policy.AddPolicy("_myAllowSpecificOrigins", builder => builder.WithOrigins("https://localhost:7227")
             .AllowAnyMethod()
             .AllowAnyHeader()
             .AllowCredentials());
    });

    var app = builder.Build();


    /*************************************************
     * Associate a Global Error handler middleware with all your unhandled exceptions
     *************************************************/
    app.UseMiddleware<ErrorHandlerMiddleware>();

    // Configure the HTTP request pipeline.
    if (app.Environment.IsDevelopment())
    {
        app.UseSwagger();
        app.UseSwaggerUI();
    }

    app.UseHttpsRedirection();

    app.UseCors("_myAllowSpecificOrigins");

    app.UseAuthorization();

    app.MapControllers();

    app.Run();
}
catch (Exception exception)
{
    // NLog: catch setup errors
    logger.Error(exception, "Stopped program because of exception");
    throw;
}
finally
{
    // Ensure to flush and stop internal timers/threads before application-exit (Avoid segmentation fault on Linux)
    NLog.LogManager.Shutdown();
}

