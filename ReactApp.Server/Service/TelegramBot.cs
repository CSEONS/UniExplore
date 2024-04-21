using AspXReactApp.Server.Controllers;
using Telegram.Bot;
using Telegram.Bot.Types.Enums;

namespace AspXReactApp.Server.Service
{
    public class TelegramBot
    {
        private readonly ITelegramBotClient _botClient = new TelegramBotClient("6971483142:AAESV9VvnST3yGzVRIx-HnbD6gPA9vp26Jc");

        public async void SendTextMessage(MyChatType myChatType, string text)
        {
            switch (myChatType)
            {
                case MyChatType.All:
                    await _botClient.SendTextMessageAsync(-4125727293, text);
                    break;
                case MyChatType.Student:
                   await _botClient.SendTextMessageAsync(-4176881483, text);
                    break;
                case MyChatType.Teacher:
                    await _botClient.SendTextMessageAsync(-4170897029, text);
                    break;
            }
        }
    }
}
