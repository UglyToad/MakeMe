namespace UglyToad.MakeMe.Specification.Name
{
    internal class NamePartData
    {
        public Percentage FirstNamePercentage { get; set; } = Percentage.Maximum;

        public Percentage MiddleNamePercentage { get; set; } = Percentage.Minimum;

        public Percentage LastNamePercentage { get; set; } = Percentage.Maximum;

        public DefaultString FirstNameValue { get; set; } = new DefaultString();

        public DefaultString MiddleNameValue { get; set; } = new DefaultString();

        public DefaultString LastNameValue { get; set; } = new DefaultString();
    }
}