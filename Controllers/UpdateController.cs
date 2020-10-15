using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using temAulaBotTelegram.Services;
using Telegram.Bot.Types;
using Telegram.Bot;

namespace temAulaBotTelegram
{
    [Route("api/[controller]")]
    public class UpdateController : Controller
    {
        private readonly ICommandService _commandService;
        private readonly IUpdateService _updateService;        
        private readonly TelegramBotClient _telegramClient;
        public UpdateController(
            ICommandService commandService,
            IUpdateService updateService,
            TelegramBotClient telegramClient)
        {
            _commandService = commandService;
            _telegramClient  = telegramClient;
            _updateService = updateService;
        }

        public async Task<object> Get()
        {
            var me = await _telegramClient.GetMeAsync();
            return new
            {
                UserName = me.Username,
                FirstName = me.FirstName,
                IsBot = me.IsBot,
                Message = "Aqui o pessoal é porreta"
            };
        }
        // POST api/update
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Update update)
        {               
            await _commandService.Dispatch(update);
            return Ok();
        }        

    }
}
