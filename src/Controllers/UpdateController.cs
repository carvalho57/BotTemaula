using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using temAulaBotTelegram.Services;
using Telegram.Bot.Types;
using Telegram.Bot;

namespace temAulaBotTelegram
{
    [Route("[controller]")]
    public class UpdateController : Controller
    {
        private readonly IDispatcherService _dispatcher;        
        private readonly ITelegramBotClient _telegramClient;
        public UpdateController(IDispatcherService dispatcher, ITelegramBotClient telegramBotClient)
        {
            _dispatcher = dispatcher;            
            _telegramClient = telegramBotClient;
        }

        public async Task<object> Get()
        {
            var me = await _telegramClient.GetMeAsync();
            return Ok(new
                {
                    UserName = me.Username,
                    FirstName = me.FirstName,
                    IsBot = me.IsBot,
                    Message = "Aqui o pessoal é porreta"
                }
            );
        }
        // POST api/update
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Update update)
        {               
            await _dispatcher.Dispatch(update);
            return Ok();
        }        

    }
}
