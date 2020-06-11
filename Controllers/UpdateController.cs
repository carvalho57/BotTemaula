using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using temAulaBotTelegram.Services;
using temAulaBotTelegram.Models;
using Telegram.Bot.Types;
using System.Text.RegularExpressions;


namespace temAulaBotTelegram
{
    [Route("api/[controller]")]
    public class UpdateController : Controller
    {
        private readonly ICommandService _commandService;
        private readonly IUpdateService _updateService;
        private readonly IBotService _serviceTelegram;
        
        public UpdateController(
            ICommandService commandService,
            IBotService serviceTelegram,
            IUpdateService updateService)
        {            
            _commandService = commandService;
            _serviceTelegram = serviceTelegram;
            _updateService = updateService;
        }
       
        public async Task<object> Get() {
            var me =  await _serviceTelegram.Client.GetMeAsync();                          
            return new {
                        UserName = me.Username,
                        FirstName = me.FirstName,
                        IsBot = me.IsBot,
                        Message = "Aqui o pessoal é porreta"
                        };     
        }
        // POST api/update
        [HttpPost]
        public async Task<IActionResult> Post([FromBody]Update update)
        {                                                    
            await _commandService.Dispatch(update,_serviceTelegram);            
            await _updateService.SendRulesToNewUsers(update.Message, _serviceTelegram);
            return Ok();         
        }

    }
}
