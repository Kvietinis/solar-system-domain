namespace Libs
{
    public class SomeMagicalVelocityCalculator : ISomeMagicalVelocityCalculator
    {
        public Task<double> ByMass(double mass)
        {
            var result = new Random((int)mass).NextDouble();

            return Task.FromResult(result);
        }
    }
}
