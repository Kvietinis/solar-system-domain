namespace Orbit.Application.Interfaces
{
    public interface IPublisher
    {
        Task Publish<T>(T message);
    }
}
