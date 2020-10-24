using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types.Enums;
using temAulaBotTelegram.Interfaces;
using temAulaBotTelegram.Models;

namespace temAulaBotTelegram.Commands
{
    public class StartCommand : Command
    {

        public StartCommand()
        {
            Name = "/start";
            Message = @"Olá, Eu sou um bot que envia as regras do grupo, para cada novo usuário e quando me pedem para fazer isso. Me envie o commando /ajuda para ver o que posso fazer";
        }

        public override async Task Execute(ITelegramBotClient cliente, InputMessage message)
        {
            await cliente
                .SendTextMessageAsync(
                    chatId: message.ChatId,
                    text: Message,
                    parseMode: ParseMode.Markdown
                );

        }
    }
}