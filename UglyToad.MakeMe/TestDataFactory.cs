namespace UglyToad.MakeMe
{
    using System;
    using Makers;
    using Makers.PostalCode;
    using Specification.Date;
    using Specification.Integer;
    using Specification.Name;
    using Specification.PostalCode;

    public class TestDataFactory
    {
        public static TestDataTypeFactory<TGenerated> Make<TGenerated>(ISpecification<TGenerated> config, int? seed = null)
        {
            var random = seed.HasValue ? new Random(seed.Value) : new Random();
            return new TestDataTypeFactory<TGenerated>((Maker<TGenerated>)CreateMaker(config, random));
        }

        private static object CreateMaker<TGenerated>(ISpecification<TGenerated> config, Random random)
        {
            var type = config.GetType();

            if (type == typeof(NameSpecification))
            {
                return new NameMaker((NameSpecification)config, random);
            }

            if (type == typeof(DateSpecification))
            {
                return new DateMaker((DateSpecification)config, random);
            }
            
            if (type == typeof(PostalCodeSpecification))
            {
                return new PostalCodeMaker((PostalCodeSpecification)config, random);
            }
            
            if (type == typeof(IntegerSpecification))
            {
                return new IntegerMaker((IntegerSpecification)config, random);
            }

            throw new NotImplementedException($"No maker exists for the return type: {type}");
        }
    }
}
