using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using Telegram.Bot.Types.ReplyMarkups;
using temAulaBotTelegram.Commands;

namespace temAulaBotTelegram.Services
{
    public class CommandService : ICommandService
    {
        private readonly List<Command> _commands;
        private readonly TelegramBotClient _telegramClient;
        public CommandService(TelegramBotClient telegramClient)
        {
            _telegramClient = telegramClient;
            _commands = new List<Command>() {
                new RulesCommand(_telegramClient),
                new AboutCommand(_telegramClient),
                new HelpCommand(_telegramClient),
                new StartCommand(_telegramClient)
            };
        }
        //Procurar o comando
        public async Task Dispatch(Update update)
        {
            var message = update.CallbackQuery != null
                        ? update.CallbackQuery.Message
                        : update.Message;

            var commandName = GetCommandNameFromMessage(message);
            var command = _commands
                            .FirstOrDefault(command => command.Name == commandName);

            await ExecuteCommand(command, message);
            await SendRulesToNewUsers(message);
        }
        // Executa o comando
        private async Task ExecuteCommand(Command command, Message message)
        {
            if (command != null && message != null)
                await command.Execute(message);
        }
        private string GetCommandNameFromMessage(Message message)
        {
            if(message.ReplyMarkup != null) 
                return message.ReplyMarkup.InlineKeyboard.First().First().CallbackData;                                
                
            message.Text ??= "";
            var regex = new Regex(@"[@\s]");
            return regex.Split(message.Text)[0];
        }

        public async Task SendRulesToNewUsers(Message message)
        {
            if (message.NewChatMembers != null)
            {
                var newMembers = message.NewChatMembers;

                var buttonReadRules = new InlineKeyboardMarkup(
                    InlineKeyboardButton.
                            WithCallbackData("Regras", "/regras"));


                foreach (var member in newMembers)
                {
                    await _telegramClient
                                .SendTextMessageAsync(
                                    chatId: message.Chat.Id,
                                    text: $"Seja bem-vindo(a) *{member.FirstName}* ao Grupo do Tem Aula\nAproveitem q a galera aqui do grupo é porreta!!!",
                                    parseMode: ParseMode.Markdown,
                                    replyMarkup: buttonReadRules
                                );
                }
            }

        }
    }
}