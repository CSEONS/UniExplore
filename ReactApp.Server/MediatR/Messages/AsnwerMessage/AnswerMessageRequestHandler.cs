using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AspXReactApp.Server.MediatR.Messages
{
    public class AnswerMessageRequestHandler : IRequestHandler<AnswerMessageRequest, IActionResult>
    {
        public async Task<IActionResult> Handle(AnswerMessageRequest request, CancellationToken cancellationToken)
        {
            Console.Write("Asnwered!!!");
            return new BadRequestObjectResult("");
        }
    }
}
