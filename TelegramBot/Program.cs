using Telegram.Bot;

namespace TelegramBot
{
    public class Program
    {
        private static string token = "7931048563:AAGL17dfJLylNTJtXxkiLRuLKerZXha44Sk";
        private static TelegramBotClient client;
        public static async Task Main(string[] args)
        {
            client = new TelegramBotClient(token);
            

        }
    }
}
