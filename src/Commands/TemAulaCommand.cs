using System.Linq;
using System.Threading.Tasks;
using Telegram.Bot;
using temAulaBotTelegram.Interfaces;
using temAulaBotTelegram.Models;
using static Google.Apis.YouTube.v3.SearchResource.ListRequest;

namespace temAulaBotTelegram.Commands
{
    public class TemAulaCommand : Command
    {        
        public TemAulaCommand()
        {
            Name = "/temaula";
            Message = "{0}  💻 #vamosprogramar!";
        }
        public override async Task Execute(RegisteredServices services, InputMessage message)
        {
            var upcommingLives = await services.YoutubeClient.GetUpcommingLives(OrderEnum.Date);

            var live = upcommingLives.FirstOrDefault();
            
            await services.TelegramClient.SendTextMessageAsync(
                chatId: message.ChatId,
                text: string.Format(Message, live.Url)
            );
        }
    }
}