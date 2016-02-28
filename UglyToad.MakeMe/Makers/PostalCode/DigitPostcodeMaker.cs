namespace UglyToad.MakeMe.Makers.PostalCode
{
    using System;
    using System.Linq;
    using Internal;
    using Specification.PostalCode;

    internal class DigitPostcodeMaker : Maker<string>
    {
        private readonly PostalCodeSpecification specification;
        private readonly int length;

        public DigitPostcodeMaker(PostalCodeSpecification specification, Random random, int length) 
            : base(specification, random)
        {
            this.specification = specification;
            this.length = length;
        }

        public override string Make()
        {
            var code = new string(Enumerable.Range(0, length).Select(_ => Random.Next(10).ToString()[0]).ToArray());

            if (!specification.UseProperSpacing)
            {
                var splitAt = Random.Next(code.Length);

                code = code.Insert(splitAt, " ");
            }

            if (specification.InvalidPercentage.Met(Random))
            {
                return RandomiseError(code);
            }

            return code;
        }

        private string RandomiseError(string code)
        {
            var errorCode = Random.Next(5);
            var errorLocation = Random.Next(code.Length);

            switch (errorCode)
            {
                case 0:
                    return code.Insert(errorLocation, Punctuation.GetRandom(Random).ToString());
                case 1:
                    return code.Remove(errorLocation);
                case 2:
                    return code.Replace(code[errorLocation],
                        CharacterStatistics.AccentedCharacters[
                            Random.Next(CharacterStatistics.AccentedCharacters.Length)].Character);
                case 3:
                    return code + Random.Next(10);
                default:
                    return code.Insert(errorLocation,
                        LetterTypes.UppercaseLetters[Random.Next(LetterTypes.UppercaseLetters.Length)]
                        .ToString());
            }
        }
    }
}