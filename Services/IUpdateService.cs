﻿using System.Threading.Tasks;
using Telegram.Bot.Types;

namespace temAulaBotTelegram.Services
{
    public interface IUpdateService
    {   
        Task SendRulesToNewUsers(Message update, IBotService serviceTelegram);
    }
}
