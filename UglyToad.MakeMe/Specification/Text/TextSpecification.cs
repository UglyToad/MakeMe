namespace UglyToad.MakeMe.Specification.Text
{
    /// <summary>
    /// Specification for generating blocks of text.
    /// </summary>
    public class TextSpecification : ISpecification<string>
    {
        internal int NumberOfSentences { get; private set; } = 0;
        internal TextLengthRange Length { get; private set; } = new TextLengthRange(5, 10);
        internal CaseStyle CaseStyle { get; private set; } = CaseStyle.Pascal;

        /// <summary>
        /// Set whether to use sentences and if so, how many.
        /// </summary>
        /// <param name="useSentences">True to split the generated text into sentences.</param>
        /// <param name="numberOfSentences">The number of sentences to use in the generated text.</param>
        /// <returns>A <see cref="TextSpecification"/>.</returns>
        public TextSpecification WithSentences(bool useSentences, int numberOfSentences = 1)
        {
            if (!useSentences || numberOfSentences < 0)
            {
                NumberOfSentences = 0;
            }
            else
            {
                NumberOfSentences = numberOfSentences;
            }

            return this;
        }

        /// <summary>
        /// Set the minimum length of the generated text.
        /// </summary>
        /// <param name="minLength">The lower bound.</param>
        /// <returns>A <see cref="TextSpecification"/>.</returns>
        public TextSpecification WithMinimumLength(int minLength)
        {
            Length.SetMinimum(minLength);
            return this;
        }

        /// <summary>
        /// Sets the maximum length of the generated text.
        /// </summary>
        /// <param name="maxLength">The upper bound.</param>
        /// <returns>A <see cref="TextSpecification"/>.</returns>
        public TextSpecification WithMaximumLength(int maxLength)
        {
            Length.SetMaximum(maxLength);
            return this;
        }

        /// <summary>
        /// Sets the maximum and minimum length of the generated text.
        /// </summary>
        /// <param name="min">The lower bound.</param>
        /// <param name="max">The upper bound.</param>
        /// <returns>A <see cref="TextSpecification"/>.</returns>
        public TextSpecification WithLengthRange(int min, int max)
        {
            Length.Set(min, max);
            return this;
        }

        /// <summary>
        /// Sets the case style of generated text.
        /// Pascal will follow the pattern "Only first word starts with capital".
        /// </summary>
        /// <param name="caseStyle">The case style to use.</param>
        /// <returns>A <see cref="TextSpecification"/>.</returns>
        public TextSpecification WithCase(CaseStyle caseStyle)
        {
            CaseStyle = caseStyle;
            return this;
        }
    }
}
