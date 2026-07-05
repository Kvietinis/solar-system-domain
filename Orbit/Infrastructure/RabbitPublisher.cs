using Orbit.Application.Interfaces;

namespace Orbit.Infrastructure
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
