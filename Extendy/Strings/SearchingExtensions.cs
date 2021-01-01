using System;
using System.Linq;
using Extendy.Strings.Common;

namespace Extendy.Strings.Searching
{
    public static class SearchingExtensions
    {
        /// <summary>
        /// Determines whether this string occurs in <paramref name="needles"/> or not.
        /// </summary>
        /// <param name="needles">The set of strings to check for the existence of the string.</param>
        /// <returns>true if the <see cref="string"/> exists within <paramref name="needles"/>; otherwise, false.</returns>
        /// <exception cref="ArgumentNullException" />
        /// <exception cref="ArgumentException" />
        public static bool ContainsAny(this string haystack, params string[] needles) 
        {
            return needles.Any(haystack.Contains);
        }

        /// <summary>
        /// Determines whether this string occurs in <paramref name="needles"/> or not, case agnostic.
        /// </summary>
        /// <param name="needles">The set of strings to check for the existence of the string.</param>
        /// <returns>true if the <see cref="string"/> exists within <paramref name="needles"/>; otherwise, false.</returns>
        /// <exception cref="ArgumentNullException" />
        /// <exception cref="ArgumentException" />
        public static bool ContainsAnyIgnoreCase(this string haystack, params string[] needles) 
        {
            return needles.Any(n => haystack.ContainsIgnoreCase(n));
        }

        /// <summary>
        /// Reports the zero-based index of the first occurrence of the specified string in this instance, case agnostic.
        /// </summary>
        /// <param name="value">The string to seek.</param>
        /// <returns>The zero-based index position of <paramref name="value"/> if that character is found, or -1 if it is not.</returns>
        /// <exception cref="ArgumentNullException" />
        /// <exception cref="ArgumentException" />
        public static int IndexOfIgnoreCase(this string instance, string value)
        {
            return instance.IndexOf(value, StringComparison.OrdinalIgnoreCase);
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
        public static int IndexOfIgnoreCase(this string instance, string value, int startIndex)
        {
            return instance.IndexOf(value, startIndex, StringComparison.OrdinalIgnoreCase);
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
        public static int IndexOfIgnoreCase(this string instance, string value, int startIndex, int count)
        {
            return instance.IndexOf(value, startIndex, count, StringComparison.OrdinalIgnoreCase);
        }

        /// <summary>
        /// Reports the zero-based index of the first occurrence of the specified Unicode character in this instance, case agnostic.
        /// </summary>
        /// <param name="value">The string to seek.</param>
        /// <returns>The zero-based index position of <paramref name="value"/> if that character is found, or -1 if it is not.</returns>
        /// <exception cref="ArgumentNullException" />
        /// <exception cref="ArgumentException" />
        public static int IndexOfIgnoreCase(this string instance, char value)
        {
            return IndexOfIgnoreCaseInternal(instance, value, 0, instance.Length);
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
        public static int IndexOfIgnoreCase(this string instance, char value, int startIndex)
        {
            return IndexOfIgnoreCaseInternal(instance, value, startIndex, instance.Length - startIndex);
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
        public static int IndexOfIgnoreCase(this string instance, char value, int startIndex, int count)
        {
            return IndexOfIgnoreCaseInternal(instance, value, startIndex, count);
        }

        /// <summary>
        /// Reports the zero-based index of the last occurrence of the specified string in this instance, case agnostic.
        /// </summary>
        /// <param name="value">The string to seek.</param>
        /// <returns>The zero-based index position of <paramref name="value"/> if that character is found, or -1 if it is not.</returns>
        /// <exception cref="ArgumentNullException" />
        /// <exception cref="ArgumentException" />
        public static int LastIndexOfIgnoreCase(this string instance, string value)
        {
            return instance.LastIndexOf(value, StringComparison.OrdinalIgnoreCase);
        }

        /// <summary>
        /// Reports the zero-based index of the last occurrence of the specified string in this instance, case agnostic.
        /// The search starts at a specified index and works backwards through the string.
        /// </summary>
        /// <param name="value">The string to seek.</param>
        /// <param name="startIndex">The search starting position.</param>
        /// <returns>The zero-based index position of <paramref name="value"/> if that character is found, or -1 if it is not.</returns>
        /// <exception cref="ArgumentNullException" />
        /// <exception cref="ArgumentOutOfRangeException" />
        /// <exception cref="ArgumentException" />
        public static int LastIndexOfIgnoreCase(this string instance, string value, int startIndex)
        {
            return instance.LastIndexOf(value, startIndex, startIndex + 1, StringComparison.OrdinalIgnoreCase);
        }

        /// <summary>
        /// Reports the zero-based index of the last occurrence of the specified string in this instance, case agnostic.
        /// The search starts at a specified index and works backwards through the string for the specified number of character positions.
        /// </summary>
        /// <param name="value">The string to seek.</param>
        /// <param name="startIndex">The search starting position.</param>
        /// <param name="count">The number of character positions to examine.</param>
        /// <exception cref="ArgumentNullException" />
        /// <exception cref="ArgumentOutOfRangeException" />
        /// <exception cref="ArgumentException" />
        public static int LastIndexOfIgnoreCase(this string instance, string value, int startIndex, int count)
        {
            return instance.LastIndexOf(value, startIndex, count, StringComparison.OrdinalIgnoreCase);
        }

        /// <summary>
        /// Reports the zero-based index of the last occurrence of the specified string in this instance, case agnostic.
        /// The search starts at a specified index and works backwards through the string for the specified number of character positions.
        /// </summary>
        /// <param name="value">The string to seek.</param>
        /// <exception cref="ArgumentNullException" />
        /// <exception cref="ArgumentException" />
        public static int LastIndexOfIgnoreCase(this string instance, char value)
        {
            return LastIndexOfIgnoreCaseInternal(instance, value, instance.Length - 1, instance.Length);
        }

        /// <summary>
        /// Reports the zero-based index of the last occurrence of the specified Unicode character in this instance, case agnostic.
        /// The search starts at a specified index and works backwards through the string for the specified number of character positions.
        /// </summary>
        /// <param name="value">The string to seek.</param>
        /// <param name="startIndex">The search starting position.</param>
        /// <exception cref="ArgumentNullException" />
        /// <exception cref="ArgumentOutOfRangeException" />
        /// <exception cref="ArgumentException" />
        public static int LastIndexOfIgnoreCase(this string instance, char value, int startIndex)
        {
            return LastIndexOfIgnoreCaseInternal(instance, value, startIndex, startIndex + 1);
        }

        /// <summary>
        /// Reports the zero-based index of the last occurrence of the specified Unicode character in this instance, case agnostic.
        /// The search starts at a specified index and works backwards through the string for the specified number of character positions.
        /// </summary>
        /// <param name="value">The string to seek.</param>
        /// <param name="startIndex">The search starting position.</param>
        /// <param name="count">The number of character positions to examine.</param>
        /// <exception cref="ArgumentNullException" />
        /// <exception cref="ArgumentOutOfRangeException" />
        /// <exception cref="ArgumentException" />
        public static int LastIndexOfIgnoreCase(this string instance, char value, int startIndex, int count)
        {
            return LastIndexOfIgnoreCaseInternal(instance, value, startIndex, count);
        }

        private static int LastIndexOfIgnoreCaseInternal(string instance, char value, int startIndex, int count)
        {
            char invertedCaseValue = char.IsUpper(value) ? char.ToLower(value) : char.ToUpper(value);

            int lastIndex = instance.LastIndexOf(value, startIndex, count);
            int lastIndexOfInverted = instance.LastIndexOf(invertedCaseValue, startIndex, count);

            return Math.Max(lastIndex, lastIndexOfInverted);
        }

        private static int IndexOfIgnoreCaseInternal(string instance, char value, int startIndex, int count)
        {
            char invertedCaseValue = char.IsUpper(value) ? char.ToLower(value) : char.ToUpper(value);

            int index = instance.IndexOf(value, startIndex, count);
            int indexOfInverted = instance.IndexOf(invertedCaseValue, startIndex, count);

            if (index != -1 && indexOfInverted != -1)
                return Math.Min(index, indexOfInverted);
            else
                return index != -1 ? index : indexOfInverted;
        }
    }
}
