namespace UglyToad.MakeMe.Makers
{
    using System;
    using Internal;
    using Specification.Text;

    internal class TextMaker : Maker<string>
    {
        private readonly TextSpecification specification;
        private readonly MarsagliaPolar normalisedGenerator;
        private readonly SentenceGenerator sentenceGenerator;

        public TextMaker(TextSpecification specification, Random random) : base(specification, random)
        {
            this.specification = specification;
            normalisedGenerator = new MarsagliaPolar(specification.Length.Minimum, specification.Length.Maximum, random);
            sentenceGenerator = new SentenceGenerator(random);
        }

        public override string Make()
        {
            var wordLength = 0;
            if (specification.Length.Size() < 3)
            {
                wordLength = Random.Next(specification.Length.Minimum, specification.Length.Maximum);
            }
            else
            {
                while (wordLength < specification.Length.Minimum || wordLength > specification.Length.Maximum)
                {
                    wordLength = normalisedGenerator.GenerateNextInNormalDistribution();
                }
            }

            return sentenceGenerator.GenerateSentence(wordLength, specification.CaseStyle);
        }
    }
}