
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using temAulaBotTelegram.Services;

namespace temAulaBotTelegram.Commands
{
    public class NoCommand : Command
    {
        public NoCommand(TelegramBotClient telegramClient) : base(telegramClient)
        {
            Name = "";
        }
        public async override Task Execute(Message message)
        {
            var text = $"Você disse:\n {message.Text}";
            await TelegramClient
                .SendTextMessageAsync(
                                chatId: message.Chat.Id,
                                text: text,
                                parseMode: ParseMode.Default
                            );
        }
    }
}