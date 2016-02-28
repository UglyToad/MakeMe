namespace UglyToad.MakeMe
{
    using System;

    internal class Punctuation
    {
        public static readonly char[] Characters =
        {
            ';', ':', ',', '\'', '\\', '.', '-', '/', '?', '#', '@', '"', '_', '(', ')'
        };

        public static char GetRandom(Random random)
        {
            return Characters[random.Next(Characters.Length)];
        }
    }
}
