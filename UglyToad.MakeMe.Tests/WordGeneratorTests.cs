namespace UglyToad.MakeMe.Tests
{
    using System;
    using System.Linq;
    using Xunit;

    public class WordGeneratorTests
    {
        private readonly Random random = new Random(250);

        [Fact]
        public void CorrectCaseLower()
        {
            var result = WordGenerator.Generate(7, CaseStyle.Lower, random);

            Assert.True(result.All(char.IsLower));
        }

        [Fact]
        public void CorrectCaseUpper()
        {
            var result = WordGenerator.Generate(7, CaseStyle.Upper, random);

            Assert.True(result.All(char.IsUpper));
        }
        
        [Fact]
        public void CorrectCasePascal()
        {
            var result = WordGenerator.Generate(7, CaseStyle.Pascal, random);

            Assert.True(result.Skip(1).All(char.IsLower));
            Assert.True(char.IsUpper(result[0]));
        }

        [Fact]
        public void CorrectCaseRandom()
        {
            var result = WordGenerator.Generate(7, CaseStyle.Random, random);

            Assert.True(!result.All(char.IsLower));
        }

        [Theory]
        [InlineData(0)]
        [InlineData(1)]
        [InlineData(50)]
        [InlineData(100)]
        public void GeneratesWordOfCorrectLength(int length)
        {
            var result = WordGenerator.Generate(length, CaseStyle.Pascal, random);

            Assert.Equal(length, result.Length);
        }
    }
}
