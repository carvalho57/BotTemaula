using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Telegram.Bot.Types;
using temAulaBotTelegram.Services;


namespace temAulaBotTelegram.Tests.Services
{
    [TestClass]
    public class DispatcherServiceTests
    {

        private readonly IDispatcherService _dispatcherService;             
        public DispatcherServiceTests()
        {
            _dispatcherService = new DispatcherService(null,null);
        }
        [TestMethod]
        [DataRow("/regras")]
        [DataRow("/sobre")]
        [DataRow("/ajuda")]
        public void Dado_um_message_command_deve_gerar_o_input_message_valido(string command)
        {
            var update = new Update
            {
                Id = 617794774,
                Message = new Message()
                {
                    Date = DateTime.Now,
                    Text = command,
                    Chat = new Chat()
                    {
                        Id = 3561653
                    }
                }
            };
            var inputMessage = _dispatcherService.GenereteInputMessage(update);

            Assert.AreEqual(inputMessage.CommandName, command);
        }

        [TestMethod]
        public void Dado_novos_membros_deve_preparar_o_input_message()
        {
            var update = new Update
            {
                Id = 617794774,
                Message = new Message()
                {
                    Date = DateTime.Now,
                    Text = "",
                    Chat = new Chat() { Id = 3561653 },
                    NewChatMembers = new User[] { new User() { Id = 21365451, FirstName = "Diego", LastName = "Jose" } }
                }
            };

            var inputMessage = _dispatcherService.GenereteInputMessage(update);
            Assert.IsTrue(inputMessage.HasNewMembers);
            Assert.AreEqual(inputMessage.NewChatMembers.Length, 1);
        }
    }
}
