using System.Collections.Generic;
using temAulaBotTelegram.Commands;
using temAulaBotTelegram.Interfaces;

namespace temAulaBotTelegram.Models
{
    public static class RegisteredCommands
    {
        private static List<Command> _commands;

        static RegisteredCommands()
        {
            _commands = new List<Command>() {
                new AboutCommand(),
                new HelpCommand(),
                new RulesCommand(),
                new StartCommand(),
                new TemAulaCommand()                
            };
        }
        public static List<Command> GetCommands() => _commands;
    }
}