using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;

namespace temAulaBotTelegram.Models
{
    public class InputMessage
    {
        public InputMessage() { }
        public InputMessage(long chatId, string commandName, User[] newChatMembers, Message message, UpdateType inputType, bool isCallbackquery)
        {
            ChatId = chatId;
            CommandName = commandName;            
            NewChatMembers = newChatMembers;
            Message = message;
            InputType = inputType;
            IsCallBackQuery = isCallbackquery;
        }

        public long ChatId { get; set; }
        public string CommandName { get; set; }
        public bool HasNewMembers
        {
            get
            {
                return NewChatMembers != null;
            }
        }
        public User[] NewChatMembers { get; set; }
        public Message Message { get; set; }
        public UpdateType InputType { get; set; }

        public bool IsCallBackQuery { get; set; }
    }
}