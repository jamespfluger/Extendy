using System;

namespace Extendy.Strings.Common
{
    public static class CommonExtensions
    {
        /// <summary>
        /// Determines whether this instance and another specified <see cref="string"/> object are the same value, agnostic of case.
        /// </summary>
        /// <param name="value">The string to compare to this instance.</param>
        /// <returns>true if the value of the <paramref name="value"/> parameter is the same as the value of this instance
        /// ignoring the case of the strings being compared; otherwise, false.</returns>
        /// <exception cref="ArgumentException" />
        public static bool EqualsIgnoreCase(this string source, string value)
        {
            if (source == null)
                throw new ArgumentNullException(nameof(source));

            return source.Equals(value, StringComparison.OrdinalIgnoreCase);
        }

        /// <summary>
        /// Returns a value indicating whether a specified substring occurs within this string, agnostic of case.
        /// </summary>
        /// <param name="value">The value to seek.</param>
        /// <returns>true if the <paramref name="value"/> parameter occurs within this string, regardless of case, or if the <paramref name="value"/> is an empty string (""); otherwise, false.</returns>
        /// <exception cref="ArgumentNullException" />
        /// <exception cref="ArgumentException" />
        public static bool ContainsIgnoreCase(this string source, string value)
        {
            if (source == null)
                throw new ArgumentNullException(nameof(source));
            if (value == null)
                throw new ArgumentNullException(nameof(value));

            return source.IndexOf(value, StringComparison.OrdinalIgnoreCase) >= 0;
        }

        /// <summary>
        /// Determines whether the beginning of this string instance matches the specified string.
        /// </summary>
        /// <param name="value">The string to compare to the substring at the start of this instance.</param>
        /// <returns>true if <paramref name="value"/> matches the beginning of this string; otherwise, false.</returns>
        /// <exception cref="ArgumentNullException" />
        /// <exception cref="ArgumentException" />
        public static bool StartsWithIgnoreCase(this string source, string value)
        {
            if (source == null)
                throw new ArgumentNullException(nameof(source));
            if (value == null)
                throw new ArgumentNullException(nameof(value));

            return source.StartsWith(value, StringComparison.OrdinalIgnoreCase);
        }

        /// <summary>
        /// Determines whether the end of this string instance matches the specified string.
        /// </summary>
        /// <param name="value">The string to compare to the substring at the end of this instance.</param>
        /// <returns>true if <paramref name="value"/> matches the end of this string; otherwise, false.</returns>
        /// <exception cref="ArgumentNullException" />
        /// <exception cref="ArgumentException" />
        public static bool EndsWithIgnoreCase(this string source, string value)
        {
            if (source == null)
                throw new ArgumentNullException(nameof(source));
            if (value == null)
                throw new ArgumentNullException(nameof(value));

            return source.EndsWith(value, StringComparison.OrdinalIgnoreCase);
        }
    }
}
