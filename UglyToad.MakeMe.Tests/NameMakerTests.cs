namespace UglyToad.MakeMe.Tests
{
    using System.Linq;
    using Xunit;

    public class NameMakerTests
    {
        [Fact]
        public void MakesRequiredQuantityOfNames()
        {
            var names = TestDataFactory.Make(A.Name()).GenerateSeries(52);

            Assert.Equal(52, names.Count());
        }

        [Fact]
        public void NoAccentedCharacters_ReturnsNormalCharactersOnly()
        {
            var names = TestDataFactory.Make(A.Name().IncludeAccentedCharacters(0)).GenerateSeries(100).ToList();

            var accentedCharactersDetected = false;

            for (var i = 0; i < names.Count && !accentedCharactersDetected; i++)
            {
                for (var j = 0; j < names[i].ToString().Length; j++)
                {
                    accentedCharactersDetected =
                        CharacterStatistics.AccentedCharacters.Any(ac => ac.Character == names[i].ToString()[j]);
                }
            }

            Assert.False(accentedCharactersDetected);
        }

        [Fact]
        public void OneHundredPercentAccentedCharacters_ReturnsAccentedCharacterAlways()
        {
            var names = TestDataFactory.Make(A.Name().IncludeAccentedCharacters(100)).GenerateSeries(52).ToList();

            var accentedCharactersDetected = true;

            for (var i = 0; i < names.Count && accentedCharactersDetected; i++)
            {
                for (var j = 0; j < names[i].ToString().Length; j++)
                {
                    accentedCharactersDetected =
                        !CharacterStatistics.AccentedCharacters.Any(ac => ac.Character == names[i].ToString()[j]);
                }
            }

            Assert.True(accentedCharactersDetected);
        }
    }
}
