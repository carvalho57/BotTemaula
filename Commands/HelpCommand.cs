
using System.Threading.Tasks;
using Telegram.Bot.Types;
using temAulaBotTelegram.Services;

namespace temAulaBotTelegram.Commands {
    public class HelpCommand : ICommand
    {
        public string Name { get; private set; } = "/ajuda";
        public async Task Execute(Message message, IBotService serviceTelegram)
        {
            const string usage = "Bot do Grupo Tem Aula 🤖 \n Comandos:\n/sobre - Sobre esse bot \n/regras - Descrição das regras\n /ajuda - Ajuda\n";
                                    
            await serviceTelegram
                .Client.SendTextMessageAsync(
                    chatId: message.Chat.Id,
                    text: usage
                );      
        }
    }
}