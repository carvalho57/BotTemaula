
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using temAulaBotTelegram.Services;

namespace temAulaBotTelegram.Commands
{
    public class RulesCommand : Command
    {
        public RulesCommand(TelegramBotClient telegramClient) : base(telegramClient)
        {
            Name = "/regras";
        }
        private const string RulesMessage = "Bem vindo ao grupo do TEM AULA!\n\nAntes de mais nada #vamosprogramar! 💻\n\n O objetivo deste grupo é para que alunos que participam dos cursos Tem Aula promovidos pelo @professorisidro no Youtube e em seu site possam discutir e compartilhar dúvidas referentes aos mais diversos exercícios de programação.\n\nAlgumas observações:\n\n✅ Este é um ambiente colaborativo, portanto seja razoável\n✅ Não permitiremos envio de assuntos que possam gerar SPAM\n✅ Não permitiremos conteúdo ofensivo ou pornográfico\n✅ Não permitiremos ofensas a membros de qualquer natureza (lembrem-se: estamos aqui para ESTUDAR) \n✅ Evite áudios ou vídeos para pedir dúvidas\n✅ Fica mais fácil ajudar se vc compartilhar seu código via Github, gist ou pastebin (ao invés de tirar foto do monitor)\n\nE uma coisa muito importante:\n\n*Aqui não é repositório de profissionais para que outros resolvam seus exercícios de aula (ou trabalho). Aqui é para que cada um aprenda com os demais.*.";
        public async override Task Execute(Message message)
        {
            await TelegramClient.SendTextMessageAsync(
                    chatId: message.Chat.Id,
                    text: RulesMessage,
                    parseMode: ParseMode.Markdown
                );
        }
    }
}