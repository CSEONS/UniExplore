using System.Text;
using Telegram.Bot;
using Telegram.Bot.Polling;
using Telegram.Bot.Types;

namespace UpdateRecivingTelegramBot
{
    public class Program
    {
        static async Task Main(string[] args)
        {
            var options = new TelegramBotClientOptions("6658119094:AAFBvyl7akKvkP-CczHI4svLcJV0W-JJ-3M");
            var recivingOptions = new ReceiverOptions()
            {
                ThrowPendingUpdates = true
            };

            var botClient = new TelegramBotClient(options);
            var httpClient = new HttpClient();

            botClient.StartReceiving(UpdateHandler, ErrorHandler, recivingOptions);

            Console.WriteLine("Bot started...");

            Console.ReadLine();
        }

        private static async Task UpdateHandler(ITelegramBotClient client, Update update, CancellationToken token)
        {
            await Console.Out.WriteLineAsync(update.Message?.ReplyToMessage?.Text);

            /*if (update.Message?.Date - DateTime.UtcNow > TimeSpan.FromMinutes(1))
            {
                return;
            }

            if (update?.Message?.ReplyToMessage != null && !string.IsNullOrWhiteSpace(update.Message.ReplyToMessage.Text))
            {
                string replyMessageText = update.Message.ReplyToMessage.Text.Trim();
                string[] messageParts = replyMessageText.Split('\n');

                if (messageParts.Length >= 2 && Guid.TryParse(messageParts[0], out Guid messageId))
                {
                    var answerMessage = new AnswerMessage
                    {
                        TelegramId = update.Message.From.Id,
                        ReplyedMessageId = messageId,
                        Text = string.Join('\n', messageParts.Skip(1))
                    };

                    var jsonString = Newtonsoft.Json.JsonConvert.SerializeObject(answerMessage);

                    using var httpClient = new HttpClient();
                    var content = new StringContent(jsonString, Encoding.UTF8, "application/json");
                    var response = await httpClient.PostAsync("https://localhost:7083/api/Bot/Answer", content, token);

                    response.EnsureSuccessStatusCode();
                }
            }*/
        }


        private static async Task ErrorHandler(ITelegramBotClient client, Exception exception, CancellationToken token)
        {
            Console.WriteLine($"Error: {exception.Message}");
        }
    }

    public class TelegramDataDTO
    { 
        public long ChatId { get; set; }
        public long UserId { get; set; }
        public string ReplyMessage { get; set; }
        public string Text { get; set; }
    }

    public class AnswerMessage
    {
        public long TelegramId { get; set; }
        public Guid ReplyedMessageId { get; set; }
        public string Text { get; set; }
    }
}
