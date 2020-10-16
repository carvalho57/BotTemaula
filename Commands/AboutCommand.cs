
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;
using temAulaBotTelegram.Services;

namespace temAulaBotTelegram.Commands {
    public class AboutCommand : Command
    {
        public AboutCommand(TelegramBotClient telegramClient)
        :base(telegramClient)
        {
            Name = "/sobre";
        }        
        public async override Task Execute(Message message)
        {
            const string usage = "🤖 Bot do Grupo Tem Aula 🤖, digite o comando /ajuda para ver o que posso fazer.";
                                    
            await TelegramClient.SendTextMessageAsync(
                    chatId: message.Chat.Id,
                    text: usage
                );      
        }
    }
}