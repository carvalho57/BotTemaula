using Telegram.Bot;
using temAulaBotTelegram.Services;

namespace temAulaBotTelegram.Models {
    public class RegisteredServices {
        public RegisteredServices(TelegramBotClient telegramClient, YoutubeApiService youtubeClient)
        {
            TelegramClient = telegramClient;
            YoutubeClient = youtubeClient;
        }

        public TelegramBotClient TelegramClient { get; set; }
        public YoutubeApiService YoutubeClient { get; set; }
    }
}