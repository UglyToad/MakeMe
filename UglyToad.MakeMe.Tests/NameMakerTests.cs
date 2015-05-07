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

        [Fact]
        public void NameMaker_NoAccentedCharacters_ReturnsNormalCharactersOnly()
        {
            var names = MakeMeA.Name().ThisManyTimes(52).ToList();

            var accentedCharactersDetected = false;

            for (int i = 0; i < names.Count && !accentedCharactersDetected; i++)
            {
                for (int j = 0; j < names[i].ToString().Length; j++)
                {
                    accentedCharactersDetected =
                        CharacterStatistics.AccentedCharacters.Any(ac => ac.Character == names[i].ToString()[j]);
                }
            }

            Assert.False(accentedCharactersDetected);
        }

        [Fact]
        public void NameMaker_100PercentAccentedCharacters_ReturnsAccentedCharacterAlways()
        {
            var names = MakeMeA.Name().IncludeAccentedCharactersPercentChance(100).ThisManyTimes(52).ToList();

            var accentedCharactersDetected = true;

            for (int i = 0; i < names.Count && accentedCharactersDetected; i++)
            {
                for (int j = 0; j < names[i].ToString().Length; j++)
                {
                    accentedCharactersDetected =
                        !CharacterStatistics.AccentedCharacters.Any(ac => ac.Character == names[i].ToString()[j]);
                }
            }

            Assert.True(accentedCharactersDetected);
        }
    }
}
