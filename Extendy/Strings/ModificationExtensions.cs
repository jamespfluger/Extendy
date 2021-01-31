using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;

namespace Extendy.Strings.Modification
{
    public static class ModificationExtensions
    {
        /// <summary>
        /// Returns a new string in which all occurrences of <paramref name="toRemove"/> in the current instance have been deleted.
        /// </summary>
        /// <param name="toRemove">The character to delete from the current instance.</param>
        /// <returns>A new string that is equivalent to his string except for the removed characters.</returns>
        /// <exception cref="ArgumentException" />
        /// <exception cref="ArgumentNullException" />
        public static string RemoveAll(this string source, string toRemove)
        {
            if (source == null)
                throw new ArgumentNullException(nameof(source));
            if (toRemove == null)
                throw new ArgumentNullException(nameof(toRemove));
            if (toRemove.Length == 0)
                throw new ArgumentException("String cannot be of zero length.");

            return source.Replace(toRemove, "");
        }

        /// <summary>
        /// Returns a new string in which all occurrences of the <paramref name="toRemove"/> char in the current instance have been deleted.
        /// </summary>
        /// <param name="toRemove">The character to delete from the current instance.</param>
        /// <returns>A new string that is equivalent to his string except for the removed characters.</returns>
        /// <exception cref="ArgumentNullException" />
        public static string RemoveAll(this string source, char toRemove)
        {
            if (source == null)
                throw new ArgumentNullException(nameof(source));

            return source.Replace(toRemove.ToString(), "");
        }

        /// <summary>
        /// Returns a new string in which all occurrences of <paramref name="toRemove"/>, case agnostic, in the current instance have been deleted.
        /// </summary>
        /// <param name="toRemove">The character to delete from the current instance.</param>
        /// <returns>A new string that is equivalent to his string except for the removed characters.</returns>
        /// <exception cref="ArgumentException" />
        /// <exception cref="ArgumentNullException" />
        public static string RemoveAllIgnoreCase(this string source, string toRemove)
        {
            if (source == null)
                throw new ArgumentNullException(nameof(source));
            if (toRemove == null)
                throw new ArgumentNullException(nameof(toRemove));
            if (toRemove.Length == 0)
                throw new ArgumentException("String cannot be of zero length.");

            return source.ReplaceIgnoreCase(toRemove, "");
        }

        /// <summary>
        /// Returns a new string in which all occurrences of the <paramref name="toRemove"/> char, case agnostic, in the current instance have been deleted.
        /// </summary>
        /// <param name="toRemove">The character to delete from the current instance.</param>
        /// <returns>A new string that is equivalent to his string except for the removed characters.</returns>
        /// <exception cref="ArgumentException" />
        /// <exception cref="ArgumentNullException" />
        public static string RemoveAllIgnoreCase(this string source, char toRemove)
        {
            if (source == null)
                throw new ArgumentNullException(nameof(source));

            return source.ReplaceIgnoreCase(toRemove.ToString(), "");
        }
        
        /// <summary>
        /// Returns the left substring of a given length from the current string object.
        /// </summary>
        /// <param name="length">The length of the substring to take</param>
        /// <returns>The left part of a string</returns>
        /// <exception cref="ArgumentOutOfRangeException" />
        public static string Left(this string source, int length)
        {
            if (source == null)
                throw new ArgumentNullException(nameof(source));
            if (length < 0)
                throw new ArgumentOutOfRangeException(nameof(length), $"{nameof(length)} cannot be less than zero.");
            else if (length > source.Length)
                throw new ArgumentOutOfRangeException(nameof(length), $"{nameof(length)} cannot be larger than length of string.");

            return source.Substring(0, length);
        }

        /// <summary>
        /// Returns the right substring of a given length from the current string object.
        /// </summary>
        /// <param name="length">The length of the substring to take</param>
        /// <returns>The right part of a string</returns>
        /// <exception cref="ArgumentOutOfRangeException" />
        public static string Right(this string source, int length)
        {
            if (source == null)
                throw new ArgumentNullException(nameof(source));
            if (length < 0)
                throw new ArgumentOutOfRangeException(nameof(length), $"{nameof(length)} cannot be less than zero.");
            else if (length > source.Length)
                throw new ArgumentOutOfRangeException(nameof(length), $"{nameof(length)} cannot be larger than length of string.");

            return source.Substring(source.Length - length, length);
        }

        /// <summary>
        /// Inverts the order of the elements in a string
        /// </summary>
        /// <returns>The inverted string</returns>
        public static string Reverse(this string source)
        {
            if (source == null)
                throw new ArgumentNullException(nameof(source));

            StringBuilder reversedStringBuilder = new StringBuilder();
            StringInfo stringInfo = new StringInfo(source);

            for (int i = stringInfo.LengthInTextElements - 1; i >= 0; i--)
            {
                reversedStringBuilder.Append(stringInfo.SubstringByTextElements(i, 1));
            }

            return reversedStringBuilder.ToString();
        }

        /// <summary>
        /// Removes all the occurrences of the given character at the start and end of the current string object, case agnostic.
        /// </summary>
        /// <param name="trimChar">A character to remove or null.</param>
        /// <returns>The trimmed string.</returns>
        public static string TrimIgnoreCase(this string source, char trimChar)
        {
            if (source == null)
                throw new ArgumentNullException(nameof(source));
            if (source.Length == 0)
                return source;

            int startIndex = GetIndexOfLastLeadingChar(source, trimChar);
            int endIndex = GetIndexOfFirstTrailingChar(source, trimChar);

            if (startIndex > endIndex)
                return "";
            else
                return source.Substring(startIndex, Math.Min(source.Length, endIndex) - startIndex);
        }


        /// <summary>
        /// Removes all the occurrences of the given character at the start of the current string object, case agnostic.
        /// </summary>
        /// <param name="trimChar">A character to remove or null.</param>
        /// <returns>The trimmed string.</returns>
        public static string TrimStartIgnoreCase(this string source, char trimChar)
        {
            if (source == null)
                throw new ArgumentNullException(nameof(source));
            if (source.Length == 0)
                return source;

            int startIndex = GetIndexOfLastLeadingChar(source, trimChar);

            return source.Substring(startIndex);
        }


        /// <summary>
        /// Removes all the occurrences of the given character at the end of the current string object, case agnostic.
        /// </summary>
        /// <param name="trimChar">A character to remove or null.</param>
        /// <returns>The trimmed string.</returns>
        public static string TrimEndIgnoreCase(this string source, char trimChar)
        {
            if (source == null)
                throw new ArgumentNullException(nameof(source));
            if (source.Length == 0)
                return source;

            int endIndex = GetIndexOfFirstTrailingChar(source, trimChar);

            return source.Substring(0, Math.Min(source.Length, endIndex));
        }

        /// <summary>
        /// Removes all the occurrences of a set of Unicode characters from the start and end of the current string object, case agnostic.
        /// </summary>
        /// <param name="trimChars">An array of Unicode characters.</param>
        /// <returns>The trimmed string.</returns>
        public static string TrimIgnoreCase(this string source, char[] trimChars)
        {
            if (source == null)
                throw new ArgumentNullException(nameof(source));
            if (trimChars == null)
                throw new ArgumentNullException(nameof(trimChars));
            if (source.Length == 0 || trimChars.Length == 0)
                return source;

            int startIndex = GetIndexOfLastLeadingAnyChar(source, trimChars);
            int endIndex = GetIndexOfFirstTrailingAnyChar(source, trimChars);

            if (startIndex > endIndex)
                return "";
            else
                return source.Substring(startIndex, endIndex - startIndex);
        }

        /// <summary>
        /// Removes all the occurrences of a set of Unicode characters from the start of the current string object, case agnostic.
        /// </summary>
        /// <param name="trimChars">An array of Unicode characters.</param>
        /// <returns>The trimmed string.</returns>
        public static string TrimStartIgnoreCase(this string source, char[] trimChars)
        {
            if (source == null)
                throw new ArgumentNullException(nameof(source));
            if (trimChars == null)
                throw new ArgumentNullException(nameof(trimChars));
            if (source.Length == 0 || trimChars.Length == 0)
                return source;

            int startIndex = GetIndexOfLastLeadingAnyChar(source, trimChars);

            return source.Substring(startIndex);
        }

        /// <summary>
        /// Removes all the occurrences of a set of Unicode characters from the end of the current string object, case agnostic.
        /// </summary>
        /// <param name="trimChars">An array of Unicode characters.</param>
        /// <returns>The trimmed string.</returns>
        /// <exception cref="ArgumentNullException" />
        public static string TrimEndIgnoreCase(this string source, char[] trimChars)
        {
            if (source == null)
                throw new ArgumentNullException(nameof(source));
            if (trimChars == null)
                throw new ArgumentNullException(nameof(trimChars));
            if (source.Length == 0 || trimChars.Length == 0)
                return source;

            int endIndex = GetIndexOfFirstTrailingAnyChar(source, trimChars);

            return source.Substring(0, endIndex);
        }

        /// <summary>
        /// Returns a new string in which all occurrences of a specified string, case agnostic, in the current instance 
        /// are replaced with another specified string.
        /// </summary>
        /// <param name="oldValue">The string to be replaced.</param>
        /// <param name="newValue">The string to replace all values of <paramref name="oldValue"/>.</param>
        /// <returns>A string that is equivalent to the current string except that all instances of <paramref name="oldValue"/>
        /// are replaced with <paramref name="newValue"/>, case agnostic. If <paramref name="oldValue"/> is not found in the current instance,
        /// the method returns the current instance unchanged.</returns>
        /// <exception cref="ArgumentException" />
        /// <exception cref="ArgumentNullException" />
        public static string ReplaceIgnoreCase(this string source, string oldValue, string newValue)
        {
            if (source == null)
                throw new ArgumentNullException(nameof(source));
            if (oldValue == null)
                throw new ArgumentNullException(nameof(oldValue));
            if (source.Length == 0)
                return source;
            if (oldValue.Length == 0)
                throw new ArgumentException("String cannot be of zero length.");

            StringBuilder replacedString = new StringBuilder(source.Length);
            bool isNewValueNullOrEmpty = string.IsNullOrEmpty(newValue);
            int searchStartIndex = 0;
            int foundCharIndex;

            while ((foundCharIndex = source.IndexOf(oldValue, searchStartIndex, StringComparison.OrdinalIgnoreCase)) != -1)
            {
                int numCharsUntilReplacement = foundCharIndex - searchStartIndex;
                if (numCharsUntilReplacement != 0)
                {
                    replacedString.Append(source, searchStartIndex, numCharsUntilReplacement);
                }

                if (!isNewValueNullOrEmpty)
                {
                    replacedString.Append(newValue);
                }

                searchStartIndex = foundCharIndex + oldValue.Length;
                if (searchStartIndex == source.Length)
                {
                    return replacedString.ToString();
                }
            }

            int numCharsUntilEnd = source.Length - searchStartIndex;
            replacedString.Append(source, searchStartIndex, numCharsUntilEnd);

            return replacedString.ToString();
        }

        /// <summary>
        /// Returns a new string in which all occurrences of a specified Unicode character, case agnostic, in the current instance 
        /// are replaced with another specified Unicode character.
        /// </summary>
        /// <param name="oldValue">The string to be replaced.</param>
        /// <param name="newValue">The string to replace all values of <paramref name="oldValue"/>.</param>
        /// <returns>A string that is equivalent to the current string except that all instances of <paramref name="oldValue"/>
        /// are replaced with <paramref name="newValue"/>, case agnostic. If <paramref name="oldValue"/> is not found in the current instance,
        /// the method returns the current instance unchanged.</returns>
        /// <exception cref="ArgumentNullException" />
        public static string ReplaceIgnoreCase(this string source, char oldValue, char newValue)
        {
            if (source == null)
                throw new ArgumentNullException(nameof(source));
            if (source.Length == 0)
                return source;

            StringBuilder replacedString = new StringBuilder();

            char upperOldValue = char.ToUpper(oldValue);

            foreach (char c in source)
            {
                if (char.ToUpper(c) == upperOldValue)
                    replacedString.Append(newValue);
                else
                    replacedString.Append(c);
            }

            return replacedString.ToString();
        }

        private static int GetIndexOfLastLeadingChar(string source, char trimChar)
        {
            int startIndex = 0;

            for (int i = 0; i < source.Length; i++)
            {
                if (char.ToUpper(source[i]) == char.ToUpper(trimChar))
                    startIndex++;
                else
                    break;
            }

            return startIndex;
        }

        private static int GetIndexOfFirstTrailingChar(string source, char trimChar)
        {
            int endIndex = source.Length;

            for (int i = source.Length - 1; i >= 0; i--)
            {
                if (char.ToUpper(source[i]) == char.ToUpper(trimChar))
                    endIndex--;
                else
                    break;
            }

            return endIndex;
        }

        private static int GetIndexOfLastLeadingAnyChar(string source, char[] trimChars)
        {
            int startIndex = 0;

            for (int i = 0; i < source.Length; i++)
            {
                if (trimChars.Any(trimChar => char.ToUpper(source[i]) == char.ToUpper(trimChar)))
                    startIndex++;
                else
                    break;
            }

            return startIndex;
        }

        private static int GetIndexOfFirstTrailingAnyChar(string source, char[] trimChars)
        {
            int endIndex = source.Length;
            for (int i = source.Length - 1; i >= 0; i--)
            {
                if (trimChars.Any(trimChar => char.ToUpper(source[i]) == char.ToUpper(trimChar)))
                    endIndex--;
                else
                    break;
            }

            return endIndex;
        }
    }
}
