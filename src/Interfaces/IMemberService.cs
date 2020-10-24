using System.Threading.Tasks;
using temAulaBotTelegram.Models;

namespace temAulaBotTelegram.Services
{
    public interface IMemberService
    {
        Task SendRulesToNewMembers(InputMessage message);
    }
}