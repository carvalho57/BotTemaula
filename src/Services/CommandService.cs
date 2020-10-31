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
        private readonly RegisteredServices _services;
        public CommandService(RegisteredServices services)
        {
            _services = services;
            _commands = RegisteredCommands.GetCommands();
        }

        //Implementar commando default
        public async Task ExecuteCommand(InputMessage message)
        {
            var command = GetCommand(message.CommandName);
            if (command != null)
                await command.Execute(_services, message);
        }

        public Command GetCommand(string commandName)
        {
            return _commands.FirstOrDefault(command => command.Name == commandName);
        }
    }
}