
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;
using temAulaBotTelegram.Services;

namespace temAulaBotTelegram.Commands {
    public class HelpCommand : Command
    {
        public HelpCommand(TelegramBotClient telegramClient)
        : base(telegramClient)
        {
            Name = "/ajuda";
        }
        
        public async override Task Execute(Message message)
        {
            const string usage = "Bot do Grupo Tem Aula 🤖 \n Comandos:\n/sobre - Sobre esse bot \n/regras - Descrição das regras\n /ajuda - Ajuda\n";
                                    
            await TelegramClient.SendTextMessageAsync(
                    chatId: message.Chat.Id,
                    text: usage
                );      
        }
    }
}