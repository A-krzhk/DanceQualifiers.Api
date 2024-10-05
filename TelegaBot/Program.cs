using Telegram.Bot.Types;
using Telegram.Bot;

namespace TelegaBot
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            var token = builder.Configuration["BotToken"];
            var webhookUrl = builder.Configuration["BotWebhookUrl"];

            builder.Services.AddSingleton<ITelegramBotClient>(sp => new TelegramBotClient(token));

            var app = builder.Build();
            app.UseHttpsRedirection();

            app.MapGet("/bot/setWebhook", async (ITelegramBotClient bot) =>
            {
                await bot.SetWebhookAsync(webhookUrl);
                return $"Webhook set to {webhookUrl}";
            });

            app.MapPost("/bot", async (ITelegramBotClient bot, Update update) =>
            {
                if (update.Message?.Text != null)
                {
                    await bot.SendTextMessageAsync(update.Message.Chat.Id, $"You said: {update.Message.Text}");
                }
            });

            app.Run();

        }
    }
}
