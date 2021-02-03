using System;
using System.Linq;
using Extendy.Strings.Common;

namespace Extendy.Strings.Searching
{
    public static class SearchingExtensions
    {
        /// <summary>
        /// Determines whether this string occurs in <paramref name="anyOf"/> or not.
        /// </summary>
        /// <param name="anyOf">The set of strings to check for the existence of the string.</param>
        /// <returns>true if the <see cref="string"/> exists within <paramref name="anyOf"/>; otherwise, false.</returns>
        /// <exception cref="ArgumentNullException" />
        /// <exception cref="ArgumentException" />
        public static bool ContainsAny(this string source, params string[] anyOf)
        {
            if (source == null)
                throw new ArgumentNullException(nameof(source));
            if (anyOf == null)
                throw new ArgumentNullException(nameof(anyOf));
            if (anyOf.Any(v => v == null))
                throw new ArgumentNullException(nameof(anyOf), $"No argument can be null.");

            return anyOf.Any(source.Contains);
        }

        /// <summary>
        /// Determines whether this string occurs in <paramref name="anyOf"/> or not, case agnostic.
        /// </summary>
        /// <param name="anyOf">The set of strings to check for the existence of the string.</param>
        /// <returns>true if the <see cref="string"/> exists within <paramref name="anyOf"/>; otherwise, false.</returns>
        /// <exception cref="ArgumentNullException" />
        /// <exception cref="ArgumentException" />
        public static bool ContainsAnyIgnoreCase(this string source, params string[] anyOf)
        {
            if (source == null)
                throw new ArgumentNullException(nameof(source));
            if (anyOf == null)
                throw new ArgumentNullException(nameof(anyOf));
            if (anyOf.Any(v => v == null))
                throw new ArgumentNullException(nameof(anyOf), $"No argument can be null.");

            return anyOf.Any(n => source.ContainsIgnoreCase(n));
        }

        /// <summary>
        /// Reports the zero-based index of the first occurrence of the specified string in this instance, case agnostic.
        /// </summary>
        /// <param name="value">The string to seek.</param>
        /// <returns>The zero-based index position of <paramref name="value"/> if that character is found, or -1 if it is not.</returns>
        /// <exception cref="ArgumentNullException" />
        /// <exception cref="ArgumentException" />
        public static int IndexOfIgnoreCase(this string source, string value)
        {
            if (source == null)
                throw new ArgumentNullException(nameof(source));

            return source.IndexOf(value, StringComparison.OrdinalIgnoreCase);
        }

        /// <summary>
        /// Reports the zero-based index of the first occurrence of the specified string in this instance, case agnostic.
        /// The search starts at a specified index.
        /// </summary>
        /// <param name="value">The string to seek.</param>
        /// <param name="startIndex">The search starting position.</param>
        /// <returns>The zero-based index position of <paramref name="value"/> if that character is found, or -1 if it is not.</returns>
        /// <exception cref="ArgumentNullException" />
        /// <exception cref="ArgumentOutOfRangeException" />
        /// <exception cref="ArgumentException" />
        public static int IndexOfIgnoreCase(this string source, string value, int startIndex)
        {
            if (source == null)
                throw new ArgumentNullException(nameof(source));

            return source.IndexOf(value, startIndex, StringComparison.OrdinalIgnoreCase);
        }

        /// <summary>
        /// Reports the zero-based index of the first occurrence of the specified string in this instance, case agnostic.
        /// The search starts at a specified index and examines a specified number of positions.
        /// </summary>
        /// <param name="value">The string to seek.</param>
        /// <param name="startIndex">The search starting position.</param>
        /// <param name="count">The number of character positions to examine.</param>
        /// <returns>The zero-based index position of <paramref name="value"/> if that character is found, or -1 if it is not.</returns>
        /// <exception cref="ArgumentNullException" />
        /// <exception cref="ArgumentOutOfRangeException" />
        /// <exception cref="ArgumentException" />
        public static int IndexOfIgnoreCase(this string source, string value, int startIndex, int count)
        {
            if (source == null)
                throw new ArgumentNullException(nameof(source));

            return source.IndexOf(value, startIndex, count, StringComparison.OrdinalIgnoreCase);
        }

        /// <summary>
        /// Reports the zero-based index of the first occurrence of the specified Unicode character in this instance, case agnostic.
        /// </summary>
        /// <param name="value">The string to seek.</param>
        /// <returns>The zero-based index position of <paramref name="value"/> if that character is found, or -1 if it is not.</returns>
        /// <exception cref="ArgumentNullException" />
        /// <exception cref="ArgumentException" />
        public static int IndexOfIgnoreCase(this string source, char value)
        {
            if (source == null)
                throw new ArgumentNullException(nameof(source));

            return IndexOfIgnoreCaseInternal(source, value, 0, source.Length);
        }

        /// <summary>
        /// Reports the zero-based index of the first occurrence of the specified Unicode character in this instance, case agnostic.
        /// The search starts at a specified index.
        /// </summary>
        /// <param name="value">The string to seek.</param>
        /// <param name="startIndex">The search starting position.</param>
        /// <returns>The zero-based index position of <paramref name="value"/> if that character is found, or -1 if it is not.</returns>
        /// <exception cref="ArgumentNullException" />
        /// <exception cref="ArgumentOutOfRangeException" />
        /// <exception cref="ArgumentException" />
        public static int IndexOfIgnoreCase(this string source, char value, int startIndex)
        {
            if (source == null)
                throw new ArgumentNullException(nameof(source));

            return IndexOfIgnoreCaseInternal(source, value, startIndex, source.Length - startIndex);
        }

        /// <summary>
        /// Reports the zero-based index of the first occurrence of the specified Unicode character in this instance, case agnostic.
        /// The search starts at a specified index and examines a specified number of positions.
        /// </summary>
        /// <param name="value">The string to seek.</param>
        /// <param name="startIndex">The search starting position.</param>
        /// <param name="count">The number of character positions to examine.</param>
        /// <returns>The zero-based index position of <paramref name="value"/> if that character is found, or -1 if it is not.</returns>
        /// <exception cref="ArgumentNullException" />
        /// <exception cref="ArgumentOutOfRangeException" />
        /// <exception cref="ArgumentException" />
        public static int IndexOfIgnoreCase(this string source, char value, int startIndex, int count)
        {
            if (source == null)
                throw new ArgumentNullException(nameof(source));

            return IndexOfIgnoreCaseInternal(source, value, startIndex, count);
        }

        /// <summary>
        /// Reports the zero-based index of the last occurrence of the specified string in this instance, case agnostic.
        /// </summary>
        /// <param name="value">The string to seek.</param>
        /// <returns>The zero-based index position of the last occurrence of <paramref name="value"/> if that string is found, or -1 if it is not.
        /// If <paramref name="value"/> is empty, the return value is the last index position in this instance.</returns>
        /// <exception cref="ArgumentNullException" />
        /// <exception cref="ArgumentException" />
        public static int LastIndexOfIgnoreCase(this string source, string value)
        {
            if (source == null)
                throw new ArgumentNullException(nameof(source));

            return source.LastIndexOf(value, StringComparison.OrdinalIgnoreCase);
        }

        /// <summary>
        /// Reports the zero-based index of the last occurrence of the specified string in this instance, case agnostic.
        /// The search starts at a specified index and works backwards through the string.
        /// </summary>
        /// <param name="value">The string to seek.</param>
        /// <param name="startIndex">The search starting position.</param>
        /// <returns>The zero-based index position of the last occurrence of <paramref name="value"/> if that string is found,
        /// or -1 if it is not or if the current instance is empty
        /// If <paramref name="value"/> is empty, the return value is the smaller of <paramref name="startIndex"/> and the last index position in this instance.</returns>
        /// <exception cref="ArgumentNullException" />
        /// <exception cref="ArgumentOutOfRangeException" />
        /// <exception cref="ArgumentException" />
        public static int LastIndexOfIgnoreCase(this string source, string value, int startIndex)
        {
            if (source == null)
                throw new ArgumentNullException(nameof(source));

            return source.LastIndexOf(value, startIndex, startIndex + 1, StringComparison.OrdinalIgnoreCase);
        }

        /// <summary>
        /// Reports the zero-based index of the last occurrence of the specified string in this instance, case agnostic.
        /// The search starts at a specified index and works backwards through the string for the specified number of character positions.
        /// </summary>
        /// <param name="value">The string to seek.</param>
        /// <param name="startIndex">The search starting position.</param>
        /// <param name="count">The number of character positions to examine.</param>
        /// <returns>The zero-based index position of the last occurrence of <paramref name="value"/> if that string is found,
        /// or -1 if it is not or if the current instance is empty
        /// If <paramref name="value"/> is empty, the return value is the smaller of <paramref name="startIndex"/> and the last index position in this instance.</returns>
        /// <exception cref="ArgumentNullException" />
        /// <exception cref="ArgumentOutOfRangeException" />
        /// <exception cref="ArgumentException" />
        public static int LastIndexOfIgnoreCase(this string source, string value, int startIndex, int count)
        {
            if (source == null)
                throw new ArgumentNullException(nameof(source));

            return source.LastIndexOf(value, startIndex, count, StringComparison.OrdinalIgnoreCase);
        }

        /// <summary>
        /// Reports the zero-based index of the last occurrence of the specified Unicode character in this instance, case agnostic.
        /// The search starts at a specified index and works backwards through the string for the specified number of character positions.
        /// </summary>
        /// <param name="value">The Unicode character to seek.</param>
        /// <returns>The zero-based index position of the last occurrence of <paramref name="value"/> if that Unicode character is found,
        /// or -1 if it is not or if the current instance is empty.</returns>
        /// <exception cref="ArgumentNullException" />
        /// <exception cref="ArgumentException" />
        public static int LastIndexOfIgnoreCase(this string source, char value)
        {
            if (source == null)
                throw new ArgumentNullException(nameof(source));

            return LastIndexOfIgnoreCaseInternal(source, value, source.Length - 1, source.Length);
        }

        /// <summary>
        /// Reports the zero-based index of the last occurrence of the specified Unicode character in this instance, case agnostic.
        /// The search starts at a specified index and works backwards through the string for the specified number of character positions.
        /// </summary>
        /// <param name="value">The Unicode character to seek.</param>
        /// <param name="startIndex">The search starting position.</param>
        /// <returns>The zero-based index position of the last occurrence of <paramref name="value"/> if that Unicode character is found,
        /// or -1 if it is not or if the current instance is empty.</returns>
        /// <exception cref="ArgumentNullException" />
        /// <exception cref="ArgumentOutOfRangeException" />
        /// <exception cref="ArgumentException" />
        public static int LastIndexOfIgnoreCase(this string source, char value, int startIndex)
        {
            if (source == null)
                throw new ArgumentNullException(nameof(source));

            return LastIndexOfIgnoreCaseInternal(source, value, startIndex, startIndex + 1);
        }

        /// <summary>
        /// Reports the zero-based index of the last occurrence of the specified Unicode character in this instance, case agnostic.
        /// The search starts at a specified index and works backwards through the string for the specified number of character positions.
        /// </summary>
        /// <returns>The zero-based index position of the last occurrence of <paramref name="value"/> if that Unicode character is found,
        /// or -1 if it is not or if the current instance is empty.</returns>
        /// <param name="value">The Unicode character to seek.</param>
        /// <param name="startIndex">The search starting position.</param>
        /// <param name="count">The number of character positions to examine.</param>
        /// <exception cref="ArgumentNullException" />
        /// <exception cref="ArgumentOutOfRangeException" />
        /// <exception cref="ArgumentException" />
        public static int LastIndexOfIgnoreCase(this string source, char value, int startIndex, int count)
        {
            if (source == null)
                throw new ArgumentNullException(nameof(source));

            return LastIndexOfIgnoreCaseInternal(source, value, startIndex, count);
        }

        private static int LastIndexOfIgnoreCaseInternal(string source, char value, int startIndex, int count)
        {
            char invertedCaseValue = char.IsUpper(value) ? char.ToLower(value) : char.ToUpper(value);

            int lastIndex = source.LastIndexOf(value, startIndex, count);
            int lastIndexOfInverted = source.LastIndexOf(invertedCaseValue, startIndex, count);

            return Math.Max(lastIndex, lastIndexOfInverted);
        }

        private static int IndexOfIgnoreCaseInternal(string source, char value, int startIndex, int count)
        {
            char invertedCaseValue = char.IsUpper(value) ? char.ToLower(value) : char.ToUpper(value);

            int index = source.IndexOf(value, startIndex, count);
            int indexOfInverted = source.IndexOf(invertedCaseValue, startIndex, count);

            if (index != -1 && indexOfInverted != -1)
                return Math.Min(index, indexOfInverted);
            else
                return index != -1 ? index : indexOfInverted;
        }
    }
}
