using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using temAulaBotTelegram.Models;

namespace temAulaBotTelegram.Services
{
    public class DispatcherService : IDispatcherService
    {
        private readonly ICommandService _commandService;
        private readonly ICallBackExecutor _callbackExecutor;
        public DispatcherService(ICommandService commandService, ICallBackExecutor callbackExecutor)
        {
            _commandService = commandService;
            _callbackExecutor = callbackExecutor;
        }

        public async Task Dispatch(Update update)
        {
            var inputMessage = GenereteInputMessage(update);         
            if(inputMessage.HasNewMembers)    
                await _callbackExecutor.SendRulesTonewMembers(inputMessage);
            else                
                await _commandService.ExecuteCommand(inputMessage);
        }

        public InputMessage GenereteInputMessage(Update update)
        {

            if (update.Type == UpdateType.CallbackQuery)
            {
                var callmessage = update.CallbackQuery.Message;
                return
                    new InputMessage(
                            callmessage.Chat.Id,
                            callmessage.ReplyMarkup.InlineKeyboard.First().First().CallbackData,
                            callmessage.NewChatMembers,
                            callmessage,
                            update.Type
                        );
            }

            var message = update.Message;
            var commandName = GetCommandFromMessage(message);
            return new InputMessage(message.Chat.Id, commandName, message.NewChatMembers, message, update.Type);

        }
        private string GetCommandFromMessage(Message message)
        {            
            if (message.Text == null)
                return string.Empty;
            var regex = new Regex(@"[@\s]");
            return regex.Split(message.Text)[0];
        }
    }
}