namespace UglyToad.MakeMe
{
    /// <summary>
    /// The case convention for generated strings.
    /// </summary>
    public enum CaseStyle
    {
        /// <summary>
        /// Strings will be "Pascal Case" on every word.
        /// </summary>
        Pascal = 1,
        /// <summary>
        /// Strings will be "lower case" on every letter.
        /// </summary>
        Lower = 2,
        /// <summary>
        /// Strings will be "UPPER CASE" on every letter.
        /// </summary>
        Upper = 3,
        /// <summary>
        /// String case will "vARy rAndoMlY" on every letter.
        /// </summary>
        Random = 4
    }
}