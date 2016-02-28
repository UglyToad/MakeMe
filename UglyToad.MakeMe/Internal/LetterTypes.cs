namespace UglyToad.MakeMe.Internal
{
    using System.Linq;

    internal class LetterTypes
    {
        public static readonly char[] Vowels =
        {
            'a', 'e', 'i', 'o', 'u'
        };

        public static readonly char[] Consonants =
        {
            'b', 'c', 'd', 'f', 'g', 'h', 'j', 'k', 'l', 'm', 'n', 'p', 'q', 'r', 's', 't', 'v',
            'w', 'x', 'y', 'z'
        };

        public static bool IsVowel(char c)
        {
            return Vowels.Contains(c);
        }

        public static bool IsConsonant(char c)
        {
            return Consonants.Contains(c);
        }

        public static readonly char[] UppercaseLetters =
        {
            'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N',
            'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z'
        };
    }
}
