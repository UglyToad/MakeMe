namespace UglyToad.MakeMe.Makers.PostalCode
{
    using System;
    using Specification.PostalCode;

    internal class UnitedKingdomPostcodeMaker : Maker<string>
    {
        private readonly PostalCodeSpecification specification;

        public UnitedKingdomPostcodeMaker(PostalCodeSpecification specification, Random random)
            : base(specification, random)
        {
            this.specification = specification;
        }

        public override string Make()
        {
            var code = GenerateValidCode();

            if (specification.InvalidPercentage.Met(Random))
            {
                var incode = code.InCode;
                var outcode = code.OutCode;

                return RandomiseError(outcode, incode);
            }

            if (!specification.UseProperSpacing)
            {
                return RandomiseSpacing(code.OutCode, code.InCode);
            }
            
            return $"{code.OutCode} {code.InCode}";
        }

        private UkCodeFormat GenerateValidCode()
        {
            var targetFormat = UkCodeFormat.ValidFormats[Random.Next(UkCodeFormat.ValidFormats.Length)];

            return targetFormat.GenerateRandom(Random, specification.Case);
        }

        private string RandomiseSpacing(string outcode, string incode)
        {
            return
                $"{RandomisedSpaceString()}{outcode}{RandomisedSpaceString()}{incode}{RandomisedSpaceString()}";
        }

        private string RandomisedSpaceString()
        {
            var result = Random.Next(30);

            if (result < 20)
            {
                return string.Empty;
            }

            if (result < 25)
            {
                return new string(' ', 2);
            }

            return new string(' ', 1);
        }

        private string RandomiseError(string outcode, string incode)
        {
            var errorCode = Random.Next(5);

            switch (errorCode)
            {
                case 0:
                    return $"{outcode} {incode}{Punctuation.GetRandom(Random)}";
                case 1:
                    return $"{outcode}{Punctuation.GetRandom(Random)}{incode}";
                case 2:
                    outcode = outcode.Replace(outcode[0],
                        CharacterStatistics.AccentedCharacters[
                            Random.Next(CharacterStatistics.AccentedCharacters.Length)].Character);

                    return $"{outcode} {incode}";
                case 3:
                    incode +=
                        CharacterStatistics.UppercaseLetters[Random.Next(CharacterStatistics.UppercaseLetters.Length)];

                    return $"{outcode} {incode}";
                default:
                    return $"{incode} {outcode}";
            }
        }
    }
}