namespace UglyToad.MakeMe.Internal
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    internal class SentenceGenerator
    {
        private readonly Random random;
        private readonly MarsagliaPolar marsagliaPolarGenerator;

        public SentenceGenerator(Random random)
        {
            this.random = random;
            marsagliaPolarGenerator = new MarsagliaPolar(1, 10, random);
        }

        public string GenerateSentence(int length, CaseStyle caseStyle)
        {
            if (length <= 2)
            {
                return WordGenerator.Generate(length, caseStyle, random);
            }

            var words = new List<string>();

            var localCase = caseStyle;
            var wordsWithSpacingLength = 0;
            while (wordsWithSpacingLength < length)
            {
                var wordLength = marsagliaPolarGenerator.GenerateNextInNormalDistribution();
                while (wordLength < 1 || wordLength > 10)
                {
                    wordLength = marsagliaPolarGenerator.GenerateNextInNormalDistribution();
                }

                if (wordLength + wordsWithSpacingLength >= length)
                {
                    wordLength = length - wordsWithSpacingLength - 1;
                    if (wordLength == 0)
                    {
                        break;
                    }
                }

                if (words.Count == 0 && localCase == CaseStyle.Pascal)
                {
                    words.Add(WordGenerator.Generate(wordLength, localCase, random));
                    localCase = CaseStyle.Lower;
                }
                else
                {
                    words.Add(WordGenerator.Generate(wordLength, localCase, random));
                }

                wordsWithSpacingLength = words.Sum(w => w.Length) + words.Count - 1;
            }

            if (caseStyle != CaseStyle.Pascal)
            {
                return string.Join(" ", words.OrderBy(_ => random.Next()).ToArray());
            }

            if (words.Count > 2)
            {
                var first = words[0];
                words.RemoveAt(0);
                words = words.OrderBy(_ => random.Next()).ToList();
                words.Insert(0, first);
            }

            return string.Join(" ", words.ToArray());
        }
    }
}
