using System.Threading.Tasks;
using temAulaBotTelegram.Interfaces;
using temAulaBotTelegram.Models;

namespace temAulaBotTelegram.Services
{
    public interface ICommandService
    {        
        Task ExecuteCommand(InputMessage message);
        Command GetCommand(string commandName);
    }
}