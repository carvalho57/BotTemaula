using System;
using System.Threading.Tasks;
using Telegram.Bot.Types;
using temAulaBotTelegram.Services;

namespace temAulaBotTelegram.Commands {
    public interface ICommand
    {
        string Name { get;}
        Task Execute(Message message, IBotService serviceTelegram); 
    }
}