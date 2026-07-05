namespace Catalog.Application.Interfaces
{
    public interface IPublisher
    {
        Task Publish<T>(T message);
    }
}
