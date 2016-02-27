namespace UglyToad.MakeMe.Makers
{
    using System;

    public abstract class Maker<TGenerated>
    {
        // ReSharper disable once MemberCanBePrivate.Global
        protected readonly ISpecification<TGenerated> Specification;
        protected readonly Random Random;

        protected Maker(ISpecification<TGenerated> specification, Random random)
        {
            Specification = specification;
            Random = random;
        }

        public abstract TGenerated Make();
    }
}