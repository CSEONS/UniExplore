using Telegram.Bot;

namespace AspXReactApp.Server.Services
{
    public class Config
    {
        public static string ConnectionString { get; set; }
        public static string TelegramBotToken { get; internal set; }
    }
}
