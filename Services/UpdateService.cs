using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using Telegram.Bot.Types.ReplyMarkups;

namespace temAulaBotTelegram.Services
{
    public class UpdateService : IUpdateService
    {
        private readonly IBotService _botService;    
        public UpdateService(IBotService botService)
        {
            _botService = botService;        
        }

        public async Task SendRulesToNewUsers(Update update)
        {            
            Message message = update.Message;
            var newMembers = message.NewChatMembers;
                   
            var buttonReadRules = new InlineKeyboardMarkup(
                InlineKeyboardButton.WithCallbackData("Regras", "/regras")
            );

            foreach(var member in newMembers) {                    
                    await _botService.Client
                        .SendTextMessageAsync(
                            chatId: message.Chat,                           
                            text: $"Seja bem-vindo(a) {member.FirstName} ao Grupo do Tem Aula",
                            parseMode: ParseMode.Markdown,
                            replyMarkup: buttonReadRules
                        );
            }         
        }
    }
}
