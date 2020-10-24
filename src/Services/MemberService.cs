using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types.Enums;
using Telegram.Bot.Types.ReplyMarkups;
using temAulaBotTelegram.Models;

namespace temAulaBotTelegram.Services
{
    public class MemberService : IMemberService
    {
        private readonly TelegramBotClient _cliente;
        public MemberService(TelegramBotClient cliente)
        {
            _cliente = cliente;
        }
        public async Task SendRulesToNewMembers(InputMessage message)
        {
            var buttonReadRules = new InlineKeyboardMarkup(InlineKeyboardButton.WithCallbackData("Regras", "/regras"));
            
            foreach (var member in message.NewChatMembers)
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