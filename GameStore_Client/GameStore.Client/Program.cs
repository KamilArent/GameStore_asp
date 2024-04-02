using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using GameStore.Client;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");
builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

builder.Services.AddScoped(sp =>
            {
                var httpClient = new HttpClient
                {
                    BaseAddress = new Uri("http://localhost:5167/")
                };
                return httpClient;
            });

builder.Services.AddScoped<GameStore.Client.Services.GameClientService>();
builder.Services.AddScoped<GameStore.Client.Services.GenreClientServices>();


await builder.Build().RunAsync();
