namespace UglyToad.MakeMe.Tests
{
    using System.Linq;
    using Xunit;

    public class NameMakerTests
    {
        [Fact]
        public void NameMaker_MakesRequiredQuantityOfNames()
        {
            var names = MakeMeA.Name().ThisManyTimes(52);

            Assert.Equal(52, names.Count());
        }
    }
}
