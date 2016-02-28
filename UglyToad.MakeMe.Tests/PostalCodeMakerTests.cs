namespace UglyToad.MakeMe.Tests
{
    using System.Linq;
    using Xunit;

    public class PostalCodeMakerTests
    {
        [Fact]
        public void MakesUkPostCodesValidByDefault()
        {
            var codes = TestDataFactory.Make(A.PostalCode().FromUnitedKingdom(), 52).GenerateSeries(500)
                .ToList();
            
            Assert.True(codes.All(c => char.IsDigit(c[c.Length - 3]) 
            && char.IsLetter(c[c.Length - 2])
            && char.IsLetter(c[c.Length - 1])));
        }

        [Fact]
        public void MakesInvalidUkPostCodes()
        {
            var codes = TestDataFactory.Make(A.PostalCode().FromUnitedKingdom().IncludeInvalid(10), 25).GenerateSeries(100);

            Assert.False(codes.All(c => char.IsDigit(c[c.Length - 3])
            && char.IsLetter(c[c.Length - 2])
            && char.IsLetter(c[c.Length - 1])));
        }

        [Fact]
        public void MakesValidFiveDigitPostalCodesByDefault()
        {
            var codes = TestDataFactory.Make(A.PostalCode()).GenerateSeries(250);

            Assert.True(codes.All(c => c.All(char.IsDigit)));
        }
    }
}
