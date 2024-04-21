using AspXReactApp.Server.Domain;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AspXReactApp.Server.MediatR.Messages
{
    public class GetMessagesRequestHandler : IRequestHandler<GetMessagesRequest, IActionResult>
    {
        private readonly ApplicationDbContext _context;

        public GetMessagesRequestHandler(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Handle(GetMessagesRequest request, CancellationToken cancellationToken)
        {
            var messages = _context.Messages
                .Skip(request.Start)
                .Take(request.Take);

            return new OkObjectResult(messages);
        }
    }
}
