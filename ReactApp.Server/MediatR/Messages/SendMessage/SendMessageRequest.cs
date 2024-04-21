using AspXReactApp.Server.Controllers;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AspXReactApp.Server.MediatR.Messages
{
    public class SendMessageRequest : IRequest<IActionResult>
    {
        public Guid From { get; set; }
        public MyChatType To { get; set; }
        public string Text { get; set; }
    }
}
