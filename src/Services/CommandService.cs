using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Telegram.Bot;
using temAulaBotTelegram.Interfaces;
using temAulaBotTelegram.Models;

namespace temAulaBotTelegram.Services
{
    public class CommandService : ICommandService
    {
        private readonly List<Command> _commands;
        public TelegramBotClient _telegramClient { get; }
        public CommandService(TelegramBotClient telegramClient)
        {
            _telegramClient = telegramClient;
            _commands = RegisteredCommands.GetCommands();
        }
        
        //Implementar commando default
        public async Task ExecuteCommand(InputMessage message)
        {
            var command = GetCommand(message.CommandName);
            if (command != null)
                await command.Execute(_telegramClient, message);
        }

        public Command GetCommand(string commandName)
        {
            return _commands.FirstOrDefault(command => command.Name == commandName);
        }
    }
}