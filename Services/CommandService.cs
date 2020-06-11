using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using temAulaBotTelegram.Commands;

namespace temAulaBotTelegram.Services {
    public class CommandService : ICommandService
    {
        public Dictionary<string, ICommand> Commands {get;private set;}

        public CommandService() {
            Commands = new Dictionary<string, ICommand>();
            Commands.Add("/start", new StartCommand());
            Commands.Add("/sobre", new AboutCommand());
            Commands.Add("/regras", new RulesCommand());
            Commands.Add("/ajuda", new HelpCommand());
            
        }    
        public async Task Dispatch(Update update, IBotService telegramService)
        {                                
            await ExecuteCommand(update.Message, telegramService);            
            await ExecuteCommand(update.CallbackQuery.Message , telegramService);            
        }

        private async Task ExecuteCommand(Message message, IBotService telegramService) {
            if(isMessageNull(message))
                return;

            var commandName = GetCommandNameFromMessage(message);
            var command = Commands[commandName];
            if(command == null)
                return;
            
            await command.Execute(message, telegramService);
        }
        
        private string GetCommandNameFromMessage(Message message) {
            var regex = new Regex(@"[@\s]");
            return regex.Split(message.Text)[0];
        }

        private bool isMessageNull(Message message) => message == null;      
    }
}