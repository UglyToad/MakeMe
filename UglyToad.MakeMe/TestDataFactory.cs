namespace UglyToad.MakeMe
{
    using System;
    using Makers;
    using Specification.Date;
    using Specification.Name;

    public class TestDataFactory
    {
        public static TestDataTypeFactory<TGenerated> Make<TGenerated>(ISpecification<TGenerated> config, int? seed = null)
        {
            var random = seed.HasValue ? new Random(seed.Value) : new Random();
            return new TestDataTypeFactory<TGenerated>((Maker<TGenerated>)CreateMaker(config, random));
        }

        private static object CreateMaker<TGenerated>(ISpecification<TGenerated> config, Random random)
        {
            var type = typeof (TGenerated);

            if (type == typeof(Name))
            {
                return new NameMaker((NameSpecification)config, random);
            }
            else if (type == typeof(DateTime))
            {
                return new DateMaker((DateSpecification)config, random);
            }

            throw new NotImplementedException($"No maker exists for the return type: {type}");
        }
    }
}
