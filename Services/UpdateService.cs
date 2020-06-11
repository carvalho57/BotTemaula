using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using Telegram.Bot.Types.ReplyMarkups;
using temAulaBotTelegram.Commands;  

namespace temAulaBotTelegram.Services
{
    public class UpdateService : IUpdateService
    {
        private readonly IBotService _botService;    
        public UpdateService(IBotService botService)
        {
            _botService = botService;        
        }
        private bool HasNewUsers(Message message) => message.NewChatMembers != null;

        public async Task SendRulesToNewUsers(Message message, IBotService serviceTelegram)
        {
            if(!HasNewUsers(message))
                return;

            var newMembers = message.NewChatMembers;

            var buttonReadRules = new InlineKeyboardMarkup(
                InlineKeyboardButton.
                        WithCallbackData("Regras", 
                                new RulesCommand().Name)
                        );   

            foreach(var member in newMembers) {                    
                await _botService
                        .Client
                            .SendTextMessageAsync(
                                chatId: message.Chat,                           
                                text: $"Seja bem-vindo(a) {member.FirstName}\n ao Grupo do Tem Aula",
                                parseMode: ParseMode.Markdown,
                                replyMarkup: buttonReadRules
                            );
            }         
        }
    }
}
