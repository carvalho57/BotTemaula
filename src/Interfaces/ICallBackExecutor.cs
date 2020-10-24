using System.Threading.Tasks;
using temAulaBotTelegram.Models;

namespace temAulaBotTelegram.Services
{
    public interface ICallBackExecutor
    {
        Task SendRulesTonewMembers(InputMessage message);
    }
}