using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using Telegram.Bot.Types.ReplyMarkups;

namespace temAulaBotTelegram.Services
{
    public class MessageService : IMessageService
    {
        private readonly IBotService _botService;
        private readonly ILogger<IMessageService> _logger;
        private const string  RulesMessage = "Bem vindo ao grupo do TEM AULA!\n\nAntes de mais nada #vamosprogramar! 💻\n\n O objetivo deste grupo é para que alunos que participam dos cursos Tem Aula promovidos pelo @professorisidro no Youtube e em seu site possam discutir e compartilhar dúvidas referentes aos mais diversos exercícios de programação.\n\nAlgumas observações:\n\n✅ Este é um ambiente colaborativo, portanto seja razoável\n✅ Não permitiremos envio de assuntos que possam gerar SPAM\n✅ Não permitiremos conteúdo ofensivo ou pornográfico\n✅ Não permitiremos ofensas a membros de qualquer natureza (lembrem-se: estamos aqui para ESTUDAR) \n✅ Evite áudios ou vídeos para pedir dúvidas\n✅ Fica mais fácil ajudar se vc compartilhar seu código via Github, gist ou pastebin (ao invés de tirar foto do monitor)\n\nE uma coisa muito importante:\n\n*Aqui não é repositório de profissionais para que outros resolvam seus exercícios de aula (ou trabalho). Aqui é para que cada um aprenda com os demais.*."; 
        public MessageService(IBotService botService, ILogger<IMessageService> logger)
        {
            _botService = botService;
            _logger = logger;
        }
        public async Task FilterCommand(Update update)
        {
            var message = update.Message;
            switch(update.Type) {
                case UpdateType.CallbackQuery:
                    await HandleCallBackQuery(update);
                    break;
                case UpdateType.Message:
                    await HandleMessage(message);
                    break;
                case UpdateType.EditedMessage:
                    await HandleMessage(message);
                    break;
                default:
                    await ShowCommands(message);
                    break;
            }
        }
        public async Task HandleCallBackQuery(Update callbackQuery) {             
             var message = callbackQuery.CallbackQuery.Message;

            switch(callbackQuery.CallbackQuery.Data) {
                case "/regras":
                    await SendRules(message);
                    break;
            }
        }    

        public async Task HandleMessage(Message message) {             
            if (message == null || message.Type != MessageType.Text)
                return;
            
            switch (message.Text.Split(" ").First())
            {
                case "/regras":
                    await SendRules(message);
                    break;
                case "/regras@temAula_bot":
                    await SendRules(message);
                    break;                
                case "/sobre":
                    await ShowCommands(message);
                    break;
                case "/sobre@temAula_bot":
                    await ShowCommands(message);
                    break;              
                default:
                    await ReplyMessage(message);
                    break;
            }
        }
        private async Task SendRules(Message message)
        {
            await _botService.Client.SendTextMessageAsync(
                chatId: message.Chat.Id,
                text: RulesMessage,
                parseMode: ParseMode.Markdown
            );
        }

        private async Task ReplyMessage(Message message)
        {
            await _botService.Client.SendTextMessageAsync(
                chatId: message.Chat.Id,
                text: $"Você disse:\n {message.Text}",
                parseMode: ParseMode.Markdown
            );
        }

        public async Task ShowCommands(Message message)
        {             
            const string usage = "Bot do Grupo Tem Aula 🤖 \n Comandos:\n/sobre - Sobre esse bot \n/regras - Descrição das regras\n";
                                    
            await _botService.Client.SendTextMessageAsync(
                chatId: message.Chat.Id,
                text: usage,
                replyMarkup: new ReplyKeyboardRemove()
            );            
        }
    }
}
