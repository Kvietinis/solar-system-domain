namespace ThreatAssessment.Application.IntegrationEvents
{
    public record ThreatCalculated
    {
        public Guid Id { get; set; }

        public int Threat { get; set; }
    }
}
