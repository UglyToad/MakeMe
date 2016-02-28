namespace UglyToad.MakeMe.Internal
{
    using System;

    internal class MarsagliaPolar
    {
        private readonly Random random;
        private readonly int distributionMean;
        private readonly double distributionDeviation;

        private int spare;
        private bool isSpareReady;

        public MarsagliaPolar(int minimum, int maximum, Random random)
        {
            this.random = random;
            distributionMean = (((maximum - minimum) / 2) + minimum);
            distributionDeviation = (maximum - minimum) / 3.0;
        }

        /// <summary>
        /// Uses the Marsaglia polar method for generating random normal distributed integers.
        /// </summary>
        /// <returns>An integer in the range defined in the specification.</returns>
        public int GenerateNextInNormalDistribution()
        {
            if (isSpareReady)
            {
                isSpareReady = false;
                return spare;
            }

            double u;
            double v;
            double s;
            do
            {
                u = random.NextDouble() * 2.0 - 1.0;
                v = random.NextDouble() * 2.0 - 1.0;

                s = u * u + v * v;
            } while (s == 0 || s >= 1);

            s = Math.Sqrt((-2 * Math.Log(s)) / s);

            spare = (int)Math.Round((v * s) * distributionDeviation) + distributionMean;
            isSpareReady = true;
            return (int)Math.Round((u * s) * distributionDeviation) + distributionMean;
        }
    }
}
