using Catalog.Application.Interfaces;

namespace Catalog.Infrastructure
{
    public class RabbitPublisher : IPublisher
    {
        public Task Publish<T>(T message)
        {
            // publishes message via RabbitMQ

            throw new NotImplementedException();
        }
    }
}
