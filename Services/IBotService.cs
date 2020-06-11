using Telegram.Bot;

namespace temAulaBotTelegram.Services
{
    public interface IBotService
    {
        TelegramBotClient Client { get; }
    }
}