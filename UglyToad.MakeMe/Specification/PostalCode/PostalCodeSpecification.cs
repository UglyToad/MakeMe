namespace UglyToad.MakeMe.Specification.PostalCode
{
    using Data;
    using Internal;

    /// <summary>
    /// Specification for generating postal codes. Defaults to a 5 digit postal code.
    /// </summary>
    public class PostalCodeSpecification : ISpecification<string>
    {
        internal IsoAlpha2Code? Country { get; private set; } = IsoAlpha2Code.Unknown;
        internal bool UseProperSpacing { get; private set; } = true;
        internal Percentage InvalidPercentage { get; private set; } = Percentage.Minimum;
        internal CaseStyle Case { get; private set; } = CaseStyle.Upper;

        /// <summary>
        /// Use the United Kingdom format.
        /// </summary>
        /// <returns>A <see cref="PostalCodeSpecification"/>.</returns>
        public PostalCodeSpecification FromUnitedKingdom()
        {
            Country = IsoAlpha2Code.UnitedKingdom;
            return this;
        }

        /// <summary>
        /// Use the six digit Indian postal code format.
        /// </summary>
        /// <returns>A <see cref="PostalCodeSpecification"/>.</returns>
        public PostalCodeSpecification FromIndia()
        {
            Country = IsoAlpha2Code.India;
            return this;
        }

        /// <summary>
        /// Use the five digit format common in many countries.
        /// Default behaviour.
        /// </summary>
        /// <returns>A <see cref="PostalCodeSpecification"/>.</returns>
        public PostalCodeSpecification WithFiveDigitFormat()
        {
            Country = IsoAlpha2Code.Unknown;
            return this;
        }

        /// <summary>
        /// Chance to generate invalid format postal codes.
        /// </summary>
        /// <param name="percentageChance">Percentage chance of invalid results between 0 - 100.</param>
        /// <returns>A <see cref="PostalCodeSpecification"/>.</returns>
        public PostalCodeSpecification IncludeInvalid(int percentageChance = 2)
        {
            InvalidPercentage = new Percentage(percentageChance);
            return this;
        }

        /// <summary>
        /// Use proper spacing, e.g. AA1 1AA for UK postcodes and 12345 for others.
        /// Default is true. Set to false to randomly insert spaces in the result.
        /// </summary>
        /// <param name="useProperSpacing">Set to false for random spacing of the result.</param>
        /// <returns>A <see cref="PostalCodeSpecification"/>.</returns>
        public PostalCodeSpecification WithProperSpacing(bool useProperSpacing = true)
        {
            UseProperSpacing = useProperSpacing;
            return this;
        }

        /// <summary>
        /// Where the postal code format contains letters, use letters of the specified case.
        /// Ignored where postal code is numbers only.
        /// </summary>
        /// <param name="caseStyle">The case style to use for letters.</param>
        /// <returns>A <see cref="PostalCodeSpecification"/>.</returns>
        public PostalCodeSpecification WithCase(CaseStyle caseStyle)
        {
            Case = caseStyle;
            return this;
        }
    }
}
