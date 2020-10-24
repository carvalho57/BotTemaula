using System.Threading.Tasks;
using Telegram.Bot;
using temAulaBotTelegram.Models;

namespace temAulaBotTelegram.Interfaces
{
    public abstract class Command
    {
        public string Name { get; protected set;}
        public string Message {get;protected set;}
        public abstract Task Execute(TelegramBotClient cliente, InputMessage inputMessage);
    }
}