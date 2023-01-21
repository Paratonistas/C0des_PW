using ConsoleBordingCards.Helpers;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
// See https://aka.ms/new-console-template for more information
//Console.WriteLine("Hello, World!");

IHost _host = Host.CreateDefaultBuilder().ConfigureServices(

    services =>{
        services.AddSingleton < IBoardingCardsSort, BordingCardsSort>();
    }).Build();
var app = _host.Services.GetRequiredService<IBoardingCardsSort>();
app.Run();

