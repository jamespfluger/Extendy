using System;
using System.Linq;

namespace Extendy.Strings.TypeChecks
{
    public static class TypeChecksExtensions
    {
        /// <summary>
        /// Determines whether this instance is an integer
        /// </summary>
        /// <returns>true if the string is numeric; otherwise, false.</returns>
        public static bool IsInteger(this string source)
        {
            if (source == null)
                throw new ArgumentNullException(nameof(source));

            return source.Length != 0 && source.All(c => char.IsDigit(c));
        }

        /// <summary>
        /// Determines whether this instance contains only alphabetic characters.
        /// </summary>
        /// <returns>true if the string is an integer; otherwise, false.</returns>
        public static bool IsAlphabetic(this string source)
        {
            if (source == null)
                throw new ArgumentNullException(nameof(source));

            return source.Length != 0 && source.All(c => char.IsLetter(c));
        }

        /// <summary>
        /// Determines whether this instance contains only alphabetic and/or numeric characters.
        /// </summary>
        /// <returns>true if the string only contains alphanumeric characters; otherwise, false.</returns>
        public static bool IsAlphaNumeric(this string source)
        {
            if (source == null)
                throw new ArgumentNullException(nameof(source));

            return source.Length != 0 && source.All(c => char.IsLetterOrDigit(c));
        }

        /// <summary>
        /// Determines whether this instance contains only uppercase alphabetic characters.
        /// </summary>
        /// <returns>true if the string only contains uppercase letters; otherwise, false.</returns>
        public static bool IsUpper(this string source)
        {
            if (source == null)
                throw new ArgumentNullException(nameof(source));

            return source.Length != 0 && source.All(c => char.IsLetter(c) && char.IsUpper(c));
        }

        /// <summary>
        /// Determines whether this instance contains only lowercase alphabetic characters.
        /// </summary>
        /// <returns>true if the string only contains lowercase letters; otherwise, false.</returns>
        public static bool IsLower(this string source)
        {
            if (source == null)
                throw new ArgumentNullException(nameof(source));

            return source.Length != 0 && source.All(c => char.IsLetter(c) && char.IsLower(c));
        }
    }
}
