
using System;
using System.Threading.Tasks;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using temAulaBotTelegram.Services;

namespace temAulaBotTelegram.Commands {
    public class StartCommand : ICommand
    {
        private const string Message = @"Olá, Eu sou um bot que envia as regras do grupo, para cada novo usuário e quando me pedem para fazer isso. Me envie o commando /sobre para ver o que posso fazer";
        public string Name { get; private set; } = "/start";

    
        public async Task Execute(Message message, IBotService serviceTelegram)
        {
            await serviceTelegram
                .Client.SendTextMessageAsync(
                    chatId: message.Chat.Id,
                    text: Message,
                    parseMode: ParseMode.Markdown
                );        
        }
    }
}