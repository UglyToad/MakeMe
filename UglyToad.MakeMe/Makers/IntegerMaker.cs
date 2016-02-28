namespace UglyToad.MakeMe.Makers
{
    using System;
    using Specification.Integer;

    internal class IntegerMaker : Maker<int>
    {
        private readonly IntegerSpecification specification;
        private readonly MarsagliaPolar marsaglia;

        public IntegerMaker(IntegerSpecification specification, Random random) 
            : base(specification, random)
        {
            this.specification = specification;
            marsaglia = new MarsagliaPolar(specification.Minimum, specification.Maximum, Random);
        }

        public override int Make()
        {
            if (!specification.UseNormal)
            {
                return Random.Next(specification.Minimum, specification.Maximum);
            }

            int result;
            do
            {
                result = marsaglia.GeneratNextInNormalDistribution();
            } while (result < specification.Minimum || result > specification.Maximum);

            return result;
        }
    }
}
