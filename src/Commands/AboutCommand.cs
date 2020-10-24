using System.Threading.Tasks;
using Telegram.Bot;
using temAulaBotTelegram.Interfaces;
using temAulaBotTelegram.Models;

namespace temAulaBotTelegram.Commands
{
    public class AboutCommand : Command
    {                
        public AboutCommand()        
        {
            Name = "/sobre";
            Message = "🤖 Bot do Grupo Tem Aula 🤖, digite o comando /ajuda para ver o que posso fazer.";
        }                
        public override async Task Execute(ITelegramBotClient cliente, InputMessage message)
        {
            await cliente.SendTextMessageAsync(
                    chatId: message.ChatId,
                    text: Message
                );      
        }
    }
}