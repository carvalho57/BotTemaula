using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Telegram.Bot;
using temAulaBotTelegram;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class TelegramClientExtension
    {
        public static IServiceCollection AddTelegramClient(this IServiceCollection services, IConfiguration configuration)
        {
            var botConfiguration = new BotConfiguration();
            configuration.GetSection(nameof(BotConfiguration)).Bind(botConfiguration);

            var telegram = new TelegramBotClient(botConfiguration.BotToken);
            telegram.SetWebhookAsync(botConfiguration.ApplicationUrl);
            services.AddSingleton<TelegramBotClient>(telegram);

            return services;
        }
    }
}