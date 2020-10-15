using System.Threading.Tasks;
using Telegram.Bot.Types;
using temAulaBotTelegram.Commands;

namespace temAulaBotTelegram.Services {
    public interface ICommandService
    {        
        Task Dispatch(Update update);
    }
}