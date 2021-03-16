using Moq;
using Notifier.Contracts;
using Notifier.Services;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace Notifier.Tests
{
    public class EnglishGreeterShould
    {
        private const string Hello = "Hello World";

        private readonly Mock<INotification> notification;

        private readonly IList<INotification> notificationServices;

        private readonly Mock<EnglishGreeter> sut;

        public EnglishGreeterShould()
        {
            notification = new Mock<INotification>();

            notificationServices = new List<INotification>()
            {
                notification.Object,
                notification.Object,
                notification.Object
            };

            sut = new Mock<EnglishGreeter>(notificationServices);
        }

        [Fact]
        public async void Call_Send_Once_Per_Service()
        {
            notification.Setup(it => it.Send(Hello)).Returns(Task.CompletedTask);

            await sut.Object.SayHello().ConfigureAwait(false);

            notification.Verify(it => it.Send(Hello), Times.Exactly(notificationServices.Count));
        }
    }
}
