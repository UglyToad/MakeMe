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

        [Fact]
        public void RestrictsFirstNameLength()
        {
            var names = TestDataFactory.Make(A.Name().WithFirstNameLength(5, 3), 100).GenerateSeries(1000);

            Assert.Equal(Enumerable.Range(3, 3), names.Select(f => f.FirstName.Length).Distinct().OrderBy(v => v));
        }

        [Fact]
        public void GeneratesMiddleNames()
        {
            var names = TestDataFactory.Make(A.Name().IncludeMiddleNames(true), 100).GenerateSeries(1000);

            Assert.True(names.All(n => !string.IsNullOrWhiteSpace(n.MiddleName)));
        }

        [Fact]
        public void GeneratesMiddleNamesWithPercentageChance()
        {
            var names = TestDataFactory.Make(A.Name().IncludeMiddleNames(true, 10), 100).GenerateSeries(1000);
            
            var middleNames = names.Count(n => !string.IsNullOrWhiteSpace(n.MiddleName));

            Assert.True(middleNames > 0 && middleNames < 200);
        }
    }
}
