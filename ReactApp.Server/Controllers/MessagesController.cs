using AspXReactApp.Server.MediatR.Messages;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using UpdateRecivingTelegramBot;

namespace AspXReactApp.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MessagesController
    {
        private readonly IMediator _mediator;

        public MessagesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("SendMessage")]
        public async Task<IActionResult> SendMessage(SendMessageRequest request)
        {
            return await  _mediator.Send(request);
        }

        [HttpPost("Answer")]
        public async Task<IActionResult> Answer(AnswerMessageRequest request)
        {
            return await _mediator.Send(request);
        }

    }
}
