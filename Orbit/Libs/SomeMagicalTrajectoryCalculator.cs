namespace Libs
{
    public class SomeMagicalTrajectoryCalculator : ISomeMagicalTrajectoryCalculator
    {
        public Task<double> ByMass(double mass)
        {
            var result = new Random((int)mass).NextDouble();

            return Task.FromResult(result);
        }
    }
}
