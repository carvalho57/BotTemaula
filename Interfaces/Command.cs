using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;
using temAulaBotTelegram.Services;

namespace temAulaBotTelegram.Commands
{
    public abstract class Command
    {
        public Command(TelegramBotClient telegramClient)
        {
            TelegramClient = telegramClient;
        }
        protected readonly TelegramBotClient TelegramClient;
        public string Name { get; protected set;}
        public abstract Task Execute(Message message);
    }
}