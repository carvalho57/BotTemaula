
using System.Threading.Tasks;
using Telegram.Bot.Types;
using temAulaBotTelegram.Services;

namespace temAulaBotTelegram.Commands {
    public class AboutCommand : ICommand
    {
        public string Name { get; private set; } = "/sobre";
        public async Task Execute(Message message, IBotService serviceTelegram)
        {
            const string usage = "🤖 Bot do Grupo Tem Aula 🤖, digite o comando /sobre para mais informações";
                                    
            await serviceTelegram
                .Client.SendTextMessageAsync(
                    chatId: message.Chat.Id,
                    text: usage
                );      
        }
    }
}