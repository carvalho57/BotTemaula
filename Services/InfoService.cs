using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using Telegram.Bot.Types.ReplyMarkups;

namespace temAulaBotTelegram.Services
{
    public class InfoService : IInfoService
    {
        private readonly IBotService _botService;
        
        public InfoService(IBotService botService)
        {
            _botService = botService;        
        }

        public async Task<User> GetBotInformation() {
            return await _botService.Client.GetMeAsync();            
        }
    }

}
