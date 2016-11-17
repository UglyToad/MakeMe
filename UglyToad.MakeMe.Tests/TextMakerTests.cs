namespace UglyToad.MakeMe.Tests
{
    using System.Linq;
    using Xunit;

    public class TextMakerTests
    {
        [Theory]
        [InlineData(0)]
        [InlineData(1)]
        [InlineData(2)]
        [InlineData(10)]
        [InlineData(20)]
        public void GenerateText(int length)
        {
            Assert.Equal(length,
            MakeFactory.Make(A.Text().WithLengthRange(length, length), 50).Generate().Length);
        }

        [Fact]
        public void GenerateSeriesGeneratesCorrectLengthData()
        {
            var results = MakeFactory.Make(A.Text().WithLengthRange(10, 30), 30).GenerateSeries(100).ToList();

            Assert.True(results.All(s => s.Length >= 10 && s.Length <= 30));
            Assert.True(results.All(r => char.IsUpper(r[0])));
        }
    }
}
