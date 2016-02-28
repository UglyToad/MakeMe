namespace UglyToad.MakeMe
{
    using System.Collections.Generic;
    using System.Linq;
    using Makers;

    public class TestDataTypeFactory<TGenerated>
    {
        private readonly Maker<TGenerated> maker;

        internal TestDataTypeFactory(Maker<TGenerated> maker)
        {
            this.maker = maker;
        }

        public TGenerated Generate()
        {
            return maker.Make();
        }

        public IEnumerable<TGenerated> GenerateSeries(int count)
        {
            return Enumerable.Range(0, count).Select(_ => maker.Make());
        }
    }
}