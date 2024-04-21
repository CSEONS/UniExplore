using AspXReactApp.Server.Controllers;
using AspXReactApp.Server.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AspXReactApp.Server.MediatR.Messages
{
    public class GetMessagesRequest : IRequest<IActionResult>
    {
        public int Start {  get; set; }
        public int Take { get; set; }
        public MyChatType MyChatType { get; set; }
    }
}
