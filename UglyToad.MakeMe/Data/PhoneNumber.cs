namespace UglyToad.MakeMe.Data
{
    /// <summary>
    /// A data type representing phone number data.
    /// </summary>
    public struct PhoneNumber
    {
        /// <summary>
        /// Country calling code.
        /// </summary>
        public int? CountryCode  { get; private set; }

        /// <summary>
        /// Body of the phone number
        /// </summary>
        public string Body { get; private set; }

        /// <summary>
        /// Create a new instance of <see cref="PhoneNumber"/>.
        /// </summary>
        /// <param name="body">The body of the phone number to use.</param>
        /// <param name="countryCode">The country code for international numbers</param>
        public PhoneNumber(string body, int? countryCode = null)
        {
            CountryCode = countryCode;
            Body = body;
        }
    }
}
