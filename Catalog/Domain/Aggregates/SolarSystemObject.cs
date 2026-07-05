using Catalog.Domain.DomainEvents;
using Catalog.Domain.ValueObjects;

namespace Catalog.Domain.Aggregates
{
    public class SolarSystemObject : IAggregate
    {
        private readonly List<IIsDomainEvent> _events = [];

        public Guid Id { get; private set; } = Guid.NewGuid();

        public string Name { get; private set; } = string.Empty;

        public Mass Mass { get; private set; } = Mass.FromDouble(0);

        public Classification Classification { get; private set; } = Classification.Unknown;

        public void AddName(string name)
        {
            Name = name;
        }

        public void ChangeMass(Mass mass)
        {
            Mass = mass;
            _events.Add(new MassChanged { Id = Id, Mass = mass });
        }

        public void ChangeClassification(Classification classification)
        {
            Classification = classification;
        }

        public IIsDomainEvent[] GetEvents()
        {
            return [.. _events];
        }
    }
}
