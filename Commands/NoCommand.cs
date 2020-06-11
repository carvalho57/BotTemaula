
using System.Threading.Tasks;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using temAulaBotTelegram.Services;

namespace temAulaBotTelegram.Commands {
    public class NoCommand : ICommand
    {
        public string Name { get; private set; } = "";
        public async Task Execute(Message message, IBotService serviceTelegram)
        {
               
         await serviceTelegram
                .Client.SendTextMessageAsync(
                    chatId: message.Chat.Id,
                    text: $"Você disse:\n {message.Text}",
                    parseMode: ParseMode.Markdown
                );  
        }
    }
}