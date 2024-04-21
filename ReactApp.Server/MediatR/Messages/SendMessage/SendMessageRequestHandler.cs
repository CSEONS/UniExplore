using AspXReactApp.Server.Domain;
using AspXReactApp.Server.Domain.Entities;
using AspXReactApp.Server.Service;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AspXReactApp.Server.MediatR.Messages
{
    public class SendMessageRequestHandler : IRequestHandler<SendMessageRequest, IActionResult>
    {
        private readonly ApplicationDbContext _context;
        private readonly TelegramBot _telegramBot;

        public SendMessageRequestHandler(ApplicationDbContext context, TelegramBot telegramBot)
        {
            _context = context;
            _telegramBot = telegramBot;
        }

        public async Task<IActionResult> Handle(SendMessageRequest request, CancellationToken cancellationToken)
        {
            var message = new Message()
            {
                From = request.From,
                Text = request.Text,
                To = request.To,
                HaveAnyAnswer = false
            };

            _context.Messages.Add(message);

            _context.SaveChanges();

            _telegramBot.SendTextMessage(message.To, message.ToTelegramFormat());

            return new OkObjectResult("Message sended");
        }
    }
}
