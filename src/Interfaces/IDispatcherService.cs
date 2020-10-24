using System.Threading.Tasks;
using Telegram.Bot.Types;
using temAulaBotTelegram.Models;

namespace temAulaBotTelegram.Services
{
    public interface IDispatcherService
    {        
        Task Dispatch(Update update);        

        InputMessage GenereteInputMessage(Update update);
    }
}