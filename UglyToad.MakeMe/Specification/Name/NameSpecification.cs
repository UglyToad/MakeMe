namespace UglyToad.MakeMe.Specification.Name
{
    using Name = MakeMe.Name;

    public class NameSpecification : ISpecification<Name>
    {
        private const int DefaultAccentedPercentage = 2;
        private const int DefaultNameMinimumLength = 2;
        private const int DefaultNameMaximumLength = 7;

        private static readonly WordLengthRange DefaultLengthRange =
            new WordLengthRange(DefaultNameMinimumLength, DefaultNameMaximumLength);

        public WordLengthRange FirstNameRange { get; } = DefaultLengthRange;

        public WordLengthRange LastNameRange { get; } = DefaultLengthRange;

        public WordLengthRange MiddleNameRange { get; } = DefaultLengthRange;

        public NamePartData NamePartData { get; } = new NamePartData();

        public CaseStyle CaseStyle { get; private set; } = CaseStyle.Pascal;

        public Percentage AccentedCharacterPercentage { get; private set; } = Percentage.Minimum;

        public NameSpecification IncludeMiddleNames(bool include, int percentageChance = Percentage.MaximumValue)
        {
            NamePartData.MiddleNamePercentage = include
                ? new Percentage(percentageChance)
                : Percentage.Minimum;

            return this;
        }

        public NameSpecification IncludeAccentedCharacters(int percentageChance = DefaultAccentedPercentage)
        {
            AccentedCharacterPercentage = new Percentage(percentageChance);

            return this;
        }

        public NameSpecification UseCase(CaseStyle caseStyle)
        {
            CaseStyle = caseStyle;

            return this;
        }

        public NameSpecification WithFirstNameLength(int max, int minimum = DefaultNameMinimumLength)
        {
            FirstNameRange.Set(minimum, max);

            return this;
        }

        public NameSpecification WithMiddleNameLength(int max, int minimum = DefaultNameMinimumLength)
        {
            MiddleNameRange.Set(minimum, max);

            return this;
        }

        public NameSpecification WithLastNameLength(int max, int minimum = DefaultNameMinimumLength)
        {
            LastNameRange.Set(minimum, max);

            return this;
        }

        public NameSpecification WithDefaultFirstName(string value)
        {
            NamePartData.FirstNameValue = new DefaultString(value);

            return this;
        }

        public NameSpecification WithDefaultMiddleName(string value)
        {
            NamePartData.MiddleNameValue = new DefaultString(value);

            return this;
        }

        public NameSpecification WithDefaultLastName(string value)
        {
            NamePartData.LastNameValue = new DefaultString(value);

            return this;
        }

        public NameSpecification WithMaximumLength(int maxLength)
        {
            // TODO: Ability to limit maximum length
            return this;
        }
    }
}