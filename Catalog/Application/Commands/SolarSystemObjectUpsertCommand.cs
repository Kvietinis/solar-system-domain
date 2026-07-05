using Catalog.Application.Dtos;

namespace Catalog.Application.Commands
{
    public record SolarSystemObjectUpsertCommand
    {
        public required string Name { get; init; }

        public required double Mass { get; init; }

        public required ClassificationEnum Classification { get; init; }
    }
}
