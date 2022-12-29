using AutoMapper;
using CleanArchitecture.Application.Interfaces;
using CleanArchitecture.Application.Services.Database;
using CleanArchitecture.Domain.Entities;
using CleanArchitecture.Infrastructure.Database;
using Microsoft.AspNetCore.Builder;

var builder = WebApplication.CreateBuilder(args);

// Register Configuration
ConfigurationManager configuration = builder.Configuration;

/************************************************
 * AutoMapper Configuration
 ************************************************/
//var mapperConfiguration = new MapperConfiguration(cfg =>
//{
//    cfg.CreateMap<Albums, AlbumDTO>();
//    cfg.CreateMap<AlbumDTO, Albums>();
//    cfg.CreateMap<Artists, ArtistDTO>();
//    cfg.CreateMap<ArtistDTO, Artists>();
//});
// only during development, validate your mappings; remove it before release
//#if DEBUG
//mapperConfiguration.AssertConfigurationIsValid();
//#endif

// use DI (http://docs.automapper.org/en/latest/Dependency-injection.html) or create the mapper yourself
//var mapper = mapperConfiguration.CreateMapper();

builder.Services.AddControllers();

/************************************************
 * Swagger 
 ************************************************/
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

/************************************************
 * Add connection string to services container
 ************************************************/
builder.Services.AddSqlServer<MusicContext>(builder.Configuration.GetConnectionString("DefaultConnection"));

/************************************************
 * Dependency Injection Container
 ************************************************/
builder.Services.AddScoped<IAlbumService, AlbumService>();
builder.Services.AddScoped<IArtistService, ArtistService>();

builder.Services.AddScoped<IAlbumRepository, AlbumRepository>();
builder.Services.AddScoped<IArtistRepository, ArtistRepository>();

//builder.Services.AddScoped<IMapper, Mapper>();
builder.Services.AddAutoMapper(typeof(Program));

var app = builder.Build();

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

