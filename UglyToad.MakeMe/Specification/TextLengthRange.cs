namespace UglyToad.MakeMe.Specification
{
    internal class TextLengthRange
    {
        public int Minimum { get; private set; }

        public int Maximum { get; private set; }

        public TextLengthRange(int minimum, int maximum)
        {
            if (minimum < 0)
            {
                minimum = 0;
            }

            if (maximum < 0)
            {
                maximum = 0;
            }

            if (maximum < minimum)
            {
                maximum = minimum;
            }

            Minimum = minimum;
            Maximum = maximum;
        }

        public void SetMinimum(int minimum)
        {
            if (minimum < 0)
            {
                minimum = 0;
            }

            Minimum = minimum;
        }

        public void SetMaximum(int maximum)
        {
            if (maximum < Minimum)
            {
                maximum = Minimum;
            }

            Maximum = maximum;
        }

        public void Set(int min, int max)
        {
            if (max < min)
            {
                max = min;
            }

            Minimum = min;
            Maximum = max;
        }

        public int Size()
        {
            return this.Maximum - this.Minimum;
        }
    }
}