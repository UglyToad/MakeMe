namespace UglyToad.MakeMe.Tests
{
    using System.Linq;
    using Xunit;

    public class IntegerMakerTests
    {
        [Fact]
        public void GeneratesNormalDistribution()
        {
            var values = MakeFactory.Make(A.Integer().WithMaximum(10).UseNormalDistribution(true))
                .GenerateSeries(10000);
            
            Assert.Equal(values.Distinct().OrderBy(v => v), Enumerable.Range(0, 11));
        }

        [Fact]
        public void GeneratesDifferentNormalDistribution()
        {
            var values = MakeFactory.Make(A.Integer().WithMinimum(-10).WithMaximum(10).UseNormalDistribution(true))
                .GenerateSeries(10000);
            
            Assert.Equal(values.Distinct().OrderBy(v => v), Enumerable.Range(-10, 21));
        }
    }
}
