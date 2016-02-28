namespace UglyToad.MakeMe.Specification.PostalCode
{
    using Data;

    public class PostalCodeSpecification : ISpecification<string>
    {
        public IsoAlpha2Code? Country { get; private set; } = IsoAlpha2Code.Unknown;
        public bool UseProperSpacing { get; private set; } = true;
        public Percentage InvalidPercentage { get; private set; } = Percentage.Minimum;
        public CaseStyle Case { get; private set; } = CaseStyle.Upper;

        public PostalCodeSpecification FromUnitedKingdom()
        {
            Country = IsoAlpha2Code.UnitedKingdom;
            return this;
        }

        public PostalCodeSpecification FromIndia()
        {
            Country = IsoAlpha2Code.India;
            return this;
        }

        public PostalCodeSpecification WithFiveDigitFormat()
        {
            Country = IsoAlpha2Code.Unknown;
            return this;
        }

        public PostalCodeSpecification IncludeInvalid(int percentageChance = 2)
        {
            InvalidPercentage = new Percentage(percentageChance);
            return this;
        }

        public PostalCodeSpecification WithProperSpacing(bool useProperSpacing = true)
        {
            UseProperSpacing = useProperSpacing;
            return this;
        }

        public PostalCodeSpecification WithCase(CaseStyle caseStyle)
        {
            Case = caseStyle;
            return this;
        }
    }
}
