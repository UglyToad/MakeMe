namespace UglyToad.MakeMe.Tests.Data
{
    using MakeMe.Data;
    using Xunit;

    public class NameTests
    {
        [Theory]
        [InlineData("Paul", null, "Coombes", "Paul Coombes")]
        [InlineData("Reginald", "Harry", "Smith", "Reginald Harry Smith")]
        [InlineData(null, null, "Burrows", "Burrows")]
        public void NameAsStringWorksCorrectly(string first, string middle, string last, string expected)
        {
            var name = new Name(first, middle, last);

            Assert.Equal(expected, name);
        }

        [Fact]
        public void ReturnsEmptyString()
        {
            var name = new Name(null, null);

            Assert.Equal(string.Empty, name);
        }
    }
}
