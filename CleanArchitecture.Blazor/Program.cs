using CleanArchitecture.Blazor;
using CleanArchitecture.Blazor.Interfaces;
using CleanArchitecture.Blazor.Services;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.Configuration;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

string serviceHostURL = builder.Configuration["Services:apiURL"];

builder.Services.AddHttpClient<IAlbumService, AlbumService>(client =>
{
    client.BaseAddress = new Uri(serviceHostURL);
});

builder.Services.AddHttpClient<IArtistService, ArtistService>(client =>
{
    client.BaseAddress = new Uri(serviceHostURL);
});

await builder.Build().RunAsync();
