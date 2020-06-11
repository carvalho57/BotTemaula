using System.Threading.Tasks;
using Telegram.Bot.Types;

namespace temAulaBotTelegram.Services
{
    public interface IMessageService
    {   
        Task FilterCommand(Update update);

        Task ShowCommands(Message message);        
        
    }
}
