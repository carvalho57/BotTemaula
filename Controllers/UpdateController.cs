using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using temAulaBotTelegram.Services;
using temAulaBotTelegram.Models;
using Telegram.Bot.Types;


namespace temAulaBotTelegram
{
    [Route("api/[controller]")]
    public class UpdateController : Controller
    {
        private readonly IUpdateService _updateService;
        private readonly IMessageService _messageService;

        private readonly IInfoService _infoService;

        public UpdateController(IUpdateService updateService,
                     IMessageService messageService,
                     IInfoService infoService
        ) {
            _updateService = updateService;
            _messageService = messageService;
            _infoService = infoService;
        }

        [HttpGet]
        public async Task<ActionResult<WhoAmI>> Get() {
            var me = await _infoService.GetBotInformation();
            return new WhoAmI(me.Username, me.FirstName);
        }

        // POST api/update
        [HttpPost]
        public async Task<IActionResult> Post([FromBody]Update update)
        {
            if(update.Message != null && update.Message.NewChatMembers != null) {
                await _updateService.SendRulesToNewUsers(update);            
                return Ok();
            }

            await _messageService.FilterCommand(update);
            return Ok();         
        }
    }
}
