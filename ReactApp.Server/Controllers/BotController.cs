using AspXReactApp.Server.Service;
using Microsoft.AspNetCore.Mvc;
using Telegram.Bot.Types;
using UpdateRecivingTelegramBot;

namespace AspXReactApp.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BotController : ControllerBase
    {
        private readonly TelegramBot _telegramBot;

        public BotController(TelegramBot telegramBot)
        {
            _telegramBot = telegramBot;
        }

        [HttpPost("UpdateReciving")]
        public IActionResult UpdateReciving(TelegramDataDTO update)
        {
            //TODO: Telegram handle
            return Ok();
        }

        [HttpGet("Start")]
        public IActionResult Start(MyChatType chatType, string text)
        {
            _telegramBot.SendTextMessage(chatType, text);

            return Ok();
        }
    }

    public enum MyChatType
    {
        All = 0,
        Student = 1,
        Teacher = 2,
    }
}
