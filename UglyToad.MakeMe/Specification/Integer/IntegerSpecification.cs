namespace UglyToad.MakeMe.Specification.Integer
{
    public class IntegerSpecification : ISpecification<int>
    {
        public int Maximum { get; private set; } = 100;

        public int Minimum { get; private set; } = 0;

        public bool UseNormal { get; private set; } = false;

        public IntegerSpecification WithMaximum(int maximum)
        {
            if (maximum < Minimum)
            {
                Minimum = maximum;
            }

            Maximum = maximum;

            return this;
        }

        public IntegerSpecification WithMinimum(int minimum)
        {
            if (minimum > Maximum)
            {
                Maximum = minimum;
            }

            Minimum = minimum;

            return this;
        }

        /// <summary>
        /// Generates the random number according to a normal distribution defined between the minimum and maximum.
        /// Because values are clamped by minimum and maximum you should not use this for statistically meaningful data. Only random test data.
        /// </summary>
        /// <param name="useNormal">Use a normal distribution to generate numbers if true. Standard random number generator if false.</param>
        /// <returns>The specification.</returns>
        public IntegerSpecification UseNormalDistribution(bool useNormal)
        {
            UseNormal = useNormal;
            return this;
        }
    }
}
