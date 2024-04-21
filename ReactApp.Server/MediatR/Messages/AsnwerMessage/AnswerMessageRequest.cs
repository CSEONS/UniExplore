using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AspXReactApp.Server.MediatR.Messages
{
    public class AnswerMessageRequest : IRequest<IActionResult>
    {
        public long TelegramId { get; set; }
        public Guid ReplyedMessageId { get; set; }
        public string Text { get; set; }
    }
}
