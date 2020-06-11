using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using Telegram.Bot.Types.ReplyMarkups;

namespace temAulaBotTelegram.Services
{
    public interface IInfoService
    {
        Task<User> GetBotInformation();
    } 
}
