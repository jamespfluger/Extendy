using System;

namespace Extendy.Enums
{
    public static class EnumExtensions
    {
        /// <summary>
        /// Converts a string to the provided enum type of <typeparamref name="T"/>
        /// </summary>
        /// <typeparam name="T">The type of enum to convert the string to</typeparam>
        /// <returns>The parsed enum value</returns>
        /// <exception cref="ArgumentException" />
        /// <exception cref="ArgumentNullException" />
        /// <exception cref="OverflowException" />
        public static T ToEnum<T>(this string source) where T : Enum
        {
            if (source == null)
                throw new ArgumentNullException(nameof(source));

            return (T)Enum.Parse(typeof(T), source);
        }

        /// <summary>
        /// Converts a string to the provided enum type of <typeparamref name="T"/>
        /// </summary>
        /// <typeparam name="T">The type of enum to convert the string to</typeparam>
        /// <param name="ignoreCase">True to ignore case; false to regard case.</param>
        /// <returns>The parsed enum value</returns>
        /// <exception cref="ArgumentException" />
        /// <exception cref="ArgumentNullException" />
        /// <exception cref="OverflowException" />
        public static T ToEnum<T>(this string source, bool ignoreCase)
        {
            if (source == null)
                throw new ArgumentNullException(nameof(source));

            return (T)Enum.Parse(typeof(T), source, ignoreCase);
        }
    }
}
