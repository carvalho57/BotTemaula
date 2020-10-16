
using System;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using temAulaBotTelegram.Services;

namespace temAulaBotTelegram.Commands {
    public class StartCommand : Command
    {
        private const string Message = @"Olá, Eu sou um bot que envia as regras do grupo, para cada novo usuário e quando me pedem para fazer isso. Me envie o commando /ajuda para ver o que posso fazer";    
        public StartCommand(TelegramBotClient telegramClient) : base(telegramClient)
        {
            Name = "/start";
        }        
        public async override Task Execute(Message message)
        {
            await TelegramClient
                .SendTextMessageAsync(
                    chatId: message.Chat.Id,
                    text: Message,
                    parseMode: ParseMode.Markdown
                );        
        }
    }
}