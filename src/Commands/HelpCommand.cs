using System.Threading.Tasks;
using Telegram.Bot;
using temAulaBotTelegram.Interfaces;
using temAulaBotTelegram.Models;

namespace temAulaBotTelegram.Commands
{
    public class HelpCommand : Command
    {
        public HelpCommand()
        {
            Name = "/ajuda";
            Message = "Bot do Grupo Tem Aula 🤖 \n Comandos:\n/sobre - Sobre esse bot \n/regras - Descrição das regras\n /ajuda - Ajuda\n";
        }
        public override async Task Execute(RegisteredServices services, InputMessage message)
        {
            await services.TelegramClient.SendTextMessageAsync(
                chatId: message.ChatId,
                text: Message
            );

        }
    }
}