using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types.Enums;
using Telegram.Bot.Types.ReplyMarkups;
using temAulaBotTelegram.Models;

namespace temAulaBotTelegram.Services
{
    public class CallBackExecutor : ICallBackExecutor
    {
        private readonly ITelegramBotClient _cliente;
        public CallBackExecutor(ITelegramBotClient cliente)
        {
            _cliente = cliente;
        }
        public async Task SendRulesTonewMembers(InputMessage message)
        {            
            var buttonReadRules = new InlineKeyboardMarkup(
                InlineKeyboardButton.
                        WithCallbackData("Regras", "/regras"));


            foreach (var member in  message.NewChatMembers)
            {
                await _cliente
                            .SendTextMessageAsync(
                                chatId: message.ChatId,
                                text: $"Seja bem-vindo(a) *{member.FirstName}* ao Grupo do Tem Aula\nAproveitem q a galera aqui do grupo é porreta!!!",
                                parseMode: ParseMode.Markdown,
                                replyMarkup: buttonReadRules
                            );
            }
        }
    }
}