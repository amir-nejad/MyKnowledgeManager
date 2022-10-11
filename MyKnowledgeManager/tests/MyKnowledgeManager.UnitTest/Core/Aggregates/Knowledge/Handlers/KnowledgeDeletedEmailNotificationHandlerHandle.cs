using Moq;
using MyKnowledgeManager.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyKnowledgeManager.Core.Handlers;
using MyKnowledgeManager.Core.Events;

namespace MyKnowledgeManager.UnitTest.Core.Aggregates.Knowledge.Handlers
{
    public class KnowledgeDeletedEmailNotificationHandlerHandle
    {
        private KnowledgeDeletedEmailNotificationHandler _handler;
        private Mock<IEmailSender> _emailSenderMock;

        public KnowledgeDeletedEmailNotificationHandlerHandle()
        {
            _emailSenderMock = new Mock<IEmailSender>();
            _handler = new KnowledgeDeletedEmailNotificationHandler(_emailSenderMock.Object);
        }

        [Fact]
        public async Task ThrowsExceptionGivenNullEventArgument()
        {
#nullable disable
            Exception ex = await Assert.ThrowsAsync<ArgumentNullException>(() => _handler.Handle(null, CancellationToken.None));
#nullable enable
        }

        [Fact]
        public async Task SendsEmailGivenEventInstance()
        {
            await _handler.Handle(new KnowledgeDeletedEevent(new KnowledgeBuilder().Build()), CancellationToken.None);

            _emailSenderMock.Verify(sender => sender.SendEmailAsync(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>()), Times.Once);
        }
    }
}
