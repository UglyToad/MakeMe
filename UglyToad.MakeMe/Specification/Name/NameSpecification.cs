namespace UglyToad.MakeMe.Specification.Name
{
    using Internal;
    using Name = Data.Name;

    /// <summary>
    /// Specification for generating <see cref="Name"/>s.
    /// </summary>
    public class NameSpecification : ISpecification<Name>
    {
        private const int DefaultAccentedPercentage = 2;
        private const int DefaultNameMinimumLength = 2;
        private const int DefaultNameMaximumLength = 7;

        internal static readonly TextLengthRange DefaultLengthRange =
            new TextLengthRange(DefaultNameMinimumLength, DefaultNameMaximumLength);

        internal TextLengthRange FirstNameRange { get; } = DefaultLengthRange;

        internal TextLengthRange LastNameRange { get; } = DefaultLengthRange;

        internal TextLengthRange MiddleNameRange { get; } = DefaultLengthRange;

        internal NamePartData NamePartData { get; } = new NamePartData();

        internal CaseStyle CaseStyle { get; private set; } = CaseStyle.Pascal;

        internal Percentage AccentedCharacterPercentage { get; private set; } = Percentage.Minimum;

        /// <summary>
        /// Sets whether generated names should contain a middle name.
        /// </summary>
        /// <param name="include">True to include, false otherwise.</param>
        /// <param name="percentageChance">The percentage likelihood of a name having a middle name. Default 100%.</param>
        /// <returns>A <see cref="NameSpecification"/>.</returns>
        public NameSpecification IncludeMiddleNames(bool include, int percentageChance = Percentage.MaximumValue)
        {
            NamePartData.MiddleNamePercentage = include
                ? new Percentage(percentageChance)
                : Percentage.Minimum;

            return this;
        }

        /// <summary>
        /// Sets whether generated names should contain characters with accents.
        /// Defaults to 2% chance.
        /// </summary>
        /// <param name="percentageChance">The percentage likelihood of a name containing an accented character.</param>
        /// <returns>A <see cref="NameSpecification"/>.</returns>
        public NameSpecification IncludeAccentedCharacters(int percentageChance = DefaultAccentedPercentage)
        {
            AccentedCharacterPercentage = new Percentage(percentageChance);

            return this;
        }

        /// <summary>
        /// Sets the case used by all generated names.
        /// </summary>
        /// <param name="caseStyle">The <see cref="CaseStyle"/> to use.</param>
        /// <returns>A <see cref="NameSpecification"/>.</returns>
        public NameSpecification UseCase(CaseStyle caseStyle)
        {
            CaseStyle = caseStyle;

            return this;
        }

        /// <summary>
        /// Sets the maximum and minimum length range of the first name.
        /// Default range is 2 - 7.
        /// </summary>
        /// <param name="max">The maximum number of characters contained in the name.</param>
        /// <param name="minimum">The minimum number of characters in the name.</param>
        /// <returns>A <see cref="NameSpecification"/>.</returns>
        public NameSpecification WithFirstNameLength(int max, int minimum = DefaultNameMinimumLength)
        {
            FirstNameRange.Set(minimum, max);

            return this;
        }

        /// <summary>
        /// Sets the maximum and minimum length range of the middle name.
        /// Default range is 2 - 7.
        /// </summary>
        /// <param name="max">The maximum number of characters contained in the name.</param>
        /// <param name="minimum">The minimum number of characters in the name.</param>
        /// <returns>A <see cref="NameSpecification"/>.</returns>
        public NameSpecification WithMiddleNameLength(int max, int minimum = DefaultNameMinimumLength)
        {
            MiddleNameRange.Set(minimum, max);

            return this;
        }

        /// <summary>
        /// Sets the maximum and minimum length range of the last name.
        /// Default range is 2 - 7.
        /// </summary>
        /// <param name="max">The maximum number of characters contained in the name.</param>
        /// <param name="minimum">The minimum number of characters in the name.</param>
        /// <returns>A <see cref="NameSpecification"/>.</returns>
        public NameSpecification WithLastNameLength(int max, int minimum = DefaultNameMinimumLength)
        {
            LastNameRange.Set(minimum, max);

            return this;
        }

        /// <summary>
        /// Sets the string to use in place of a first name for all generated names.
        /// </summary>
        /// <param name="value">The string to use for first name.</param>
        /// <returns>A <see cref="NameSpecification"/>.</returns>
        public NameSpecification WithDefaultFirstName(string value)
        {
            NamePartData.FirstNameValue = new DefaultString(value);

            return this;
        }

        /// <summary>
        /// Sets the string to use in place of a middle name for all generated names.
        /// </summary>
        /// <param name="value">The string to use for middle name.</param>
        /// <returns>A <see cref="NameSpecification"/>.</returns>
        public NameSpecification WithDefaultMiddleName(string value)
        {
            NamePartData.MiddleNameValue = new DefaultString(value);

            return this;
        }

        /// <summary>
        /// Sets the string to use in place of a middle name for all generated names.
        /// </summary>
        /// <param name="value">The string to use for middle name.</param>
        /// <returns>A <see cref="NameSpecification"/>.</returns>
        public NameSpecification WithDefaultLastName(string value)
        {
            NamePartData.LastNameValue = new DefaultString(value);

            return this;
        }
    }
}