using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using app.TelegramBot.Services;
using app.TelegramBot.Configuration;
using Microsoft.Extensions.Configuration;

namespace app.TelegramBot
{
    public class Program
    {
        static async Task Main(string[] args)
        {
            var host = Host.CreateDefaultBuilder(args)
                 .ConfigureAppConfiguration((context, config) =>
                 {
                     config.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);
                 })
                .ConfigureServices((context, services) =>
                {
                    services.Configure<BotConfiguration>(context.Configuration.GetSection("BotConfiguration"));
                    services.AddSingleton<TelegramBotService>();
                })
                .Build();

            using (var scope = host.Services.CreateScope())
            {
                var botService = scope.ServiceProvider.GetRequiredService<TelegramBotService>();
                var cancellationTokenSource = new CancellationTokenSource();

                await botService.StartReceiving(cancellationTokenSource.Token);
            }
        }
    }
}
