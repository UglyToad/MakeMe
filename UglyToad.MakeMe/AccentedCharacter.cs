namespace UglyToad.MakeMe
{
    public struct AccentedCharacter
    {
        public readonly char Character;
        public readonly char NonAccentedEquivalent;
        public readonly bool TreatAsVowel;

        public AccentedCharacter(char character, char nonAccentedEquivalent, bool treatAsVowel)
        {
            Character = character;
            NonAccentedEquivalent = nonAccentedEquivalent;
            TreatAsVowel = treatAsVowel;
        }
    }
}