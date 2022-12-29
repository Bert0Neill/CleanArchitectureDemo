using AutoMapper;
using CleanArchitecture.API.Middleware;
using CleanArchitecture.Application.Interfaces;
using CleanArchitecture.Application.Services.Database;
using CleanArchitecture.Domain.Entities;
using CleanArchitecture.Infrastructure.Database;
using Microsoft.AspNetCore.Builder;

var builder = WebApplication.CreateBuilder(args);

// Register Configuration
ConfigurationManager configuration = builder.Configuration;

builder.Services.AddControllers();

/************************************************
 * Add Swagger UI to services container
 ************************************************/
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

/************************************************
 * Add connection string to services container
 ************************************************/
builder.Services.AddSqlServer<MusicContext>(builder.Configuration.GetConnectionString("DefaultConnection"));

/************************************************
 * Dependency Injection 
 ************************************************/
builder.Services.AddScoped<IAlbumService, AlbumService>();
builder.Services.AddScoped<IArtistService, ArtistService>();
builder.Services.AddScoped<IAlbumRepository, AlbumRepository>();
builder.Services.AddScoped<IArtistRepository, ArtistRepository>();

/************************************************
 Add AutoMaper DI to services container
 ************************************************/
builder.Services.AddAutoMapper(typeof(Program));

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

app.UseAuthorization();

app.MapControllers();

app.Run();

