namespace UglyToad.MakeMe.Data
{
    using System;
    using System.Linq;

    public struct IsoAlpha2Code
    {
        public bool Equals(IsoAlpha2Code other)
        {
            return string.Equals(Value, other.Value);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            return obj is IsoAlpha2Code && Equals((IsoAlpha2Code) obj);
        }

        public override int GetHashCode()
        {
            return Value?.GetHashCode() ?? 0;
        }

        public static bool operator ==(IsoAlpha2Code left, IsoAlpha2Code right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(IsoAlpha2Code left, IsoAlpha2Code right)
        {
            return !left.Equals(right);
        }

        public string Value { get; }

        public IsoAlpha2Code(string value)
        {
            if (value == null)
            {
                throw new ArgumentNullException(nameof(value), "Value of ISO 3166 alpha-2 code may not be null.");
            }

            if (value.Length != 2)
            {
                throw new ArgumentException($"ISO 3166 alpha-2 code may only be two characters long: {value}",
                    nameof(value));
            }

            if (!value.All(char.IsLetter))
            {
                throw new ArgumentException($"ISO 3166 alpha-2 code may only contain letters: {value}", nameof(value));
            }

            Value = value;
        }

        public static implicit operator string(IsoAlpha2Code code)
        {
            return code.Value;
        }

        public static readonly IsoAlpha2Code UnitedKingdom = new IsoAlpha2Code("GB");
        public static readonly IsoAlpha2Code India = new IsoAlpha2Code("IN");
        public static readonly IsoAlpha2Code Unknown = new IsoAlpha2Code("ZZ");
    }
}