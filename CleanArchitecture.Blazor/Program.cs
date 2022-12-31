using CleanArchitecture.Blazor;
using CleanArchitecture.Blazor.Interfaces;
using CleanArchitecture.Blazor.Services;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Polly;
using Polly.Extensions.Http;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

/*******************************************************************
* Configure Http Factory and Polly Retry policy - test by only 
* running Web UI and not API, call fetch data in Web UI
********************************************************************/
Random _jitterer = new Random();
string serviceHostURL = builder.Configuration["Services:apiURL"]; // retrieve default URL to API
int _retryCount = int.Parse(builder.Configuration["Services:retryCount"]); // retrieve default URL to API

builder.Services.AddHttpClient<IAlbumService, AlbumService>(client =>
{
    client.BaseAddress = new Uri(serviceHostURL);
}).AddPolicyHandler
(
    GetRetryPolicy(_retryCount, _jitterer)    
);

builder.Services.AddHttpClient<IArtistService, ArtistService>(client => {
    client.BaseAddress = new Uri(serviceHostURL);
}).AddPolicyHandler (
    GetRetryPolicy(_retryCount, _jitterer)
);

await builder.Build().RunAsync();

// use the same retry policy for all API calls
static IAsyncPolicy<HttpResponseMessage> GetRetryPolicy(int retryCount, Random jitterer)
{
    return HttpPolicyExtensions
                .HandleTransientHttpError()
                .WaitAndRetryAsync(retryCount,
                    retryAttempt => TimeSpan.FromSeconds(Math.Pow(2, retryAttempt))
                                  + TimeSpan.FromMilliseconds(jitterer.Next(0, 100)));
}
