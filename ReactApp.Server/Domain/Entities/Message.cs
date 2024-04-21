using AspXReactApp.Server.Controllers;

namespace AspXReactApp.Server.Domain.Entities
{
    public class Message
    {
        public Guid Id { get; set; }
        public Guid From { get; set; }
        public MyChatType To { get; set; }
        public string Text { get; set; }
        public bool HaveAnyAnswer { get; set; }

        public string ToTelegramFormat()
        {
            return $"{Id}\n{Text}";
        }
    }
}
