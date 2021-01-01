using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;

namespace Extendy.Strings.Manipulation
{
    public static class ManipulationExtensions
    {
        /// <summary>
        /// Returns the left substring of a given length from the current string object.
        /// </summary>
        /// <param name="length">The length of the substring to take</param>
        /// <returns>The left part of a string</returns>
        /// <exception cref="ArgumentOutOfRangeException" />
        public static string Left(this string instance, int length)
        {
            if (length < 0)
                throw new ArgumentOutOfRangeException(nameof(length), $"{nameof(length)} cannot be less than zero.");
            else if (length > instance.Length)
                throw new ArgumentOutOfRangeException(nameof(length), $"{nameof(length)} cannot be larger than length of string.");
            return instance.Substring(0, length);
        }

        /// <summary>
        /// Returns the right substring of a given length from the current string object.
        /// </summary>
        /// <param name="length">The length of the substring to take</param>
        /// <returns>The right part of a string</returns>
        /// <exception cref="ArgumentOutOfRangeException" />
        public static string Right(this string instance, int length)
        {
            if (length < 0)
                throw new ArgumentOutOfRangeException(nameof(length), $"{nameof(length)} cannot be less than zero.");
            else if (length > instance.Length)
                throw new ArgumentOutOfRangeException(nameof(length), $"{nameof(length)} cannot be larger than length of string.");
            else
                return instance.Substring(instance.Length - length, length);
        }

        /// <summary>
        /// Inverts the order of the elements in a string
        /// </summary>
        /// <returns>The inverted string</returns>
        public static string Reverse(this string instance)
        {
            List<string> g = new List<string>();
            StringBuilder reversedStringBuilder = new StringBuilder();
            StringInfo stringInfo = new StringInfo(instance);

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
        public static string TrimIgnoreCase(this string instance, char trimChar)
        {
            if (string.IsNullOrEmpty(instance))
                return instance;

            int startIndex = GetIndexOfLastLeadingChar(instance, trimChar);
            int endIndex = GetIndexOfFirstTrailingChar(instance, trimChar);

            if (startIndex > endIndex)
                return "";
            else
                return instance.Substring(startIndex, Math.Min(instance.Length, endIndex) - startIndex);
        }


        /// <summary>
        /// Removes all the occurrences of the given character at the start of the current string object, case agnostic.
        /// </summary>
        /// <param name="trimChar">A character to remove or null.</param>
        /// <returns>The trimmed string.</returns>
        public static string TrimStartIgnoreCase(this string instance, char trimChar)
        {
            if (string.IsNullOrEmpty(instance))
                return instance;

            int startIndex = GetIndexOfLastLeadingChar(instance, trimChar);

            return instance.Substring(startIndex);
        }


        /// <summary>
        /// Removes all the occurrences of the given character at the end of the current string object, case agnostic.
        /// </summary>
        /// <param name="trimChar">A character to remove or null.</param>
        /// <returns>The trimmed string.</returns>
        public static string TrimEndIgnoreCase(this string instance, char trimChar)
        {
            if (string.IsNullOrEmpty(instance))
                return instance;

            int endIndex = GetIndexOfFirstTrailingChar(instance, trimChar);

            return instance.Substring(0, Math.Min(instance.Length, endIndex));
        }

        /// <summary>
        /// Removes all the occurrences of a set of Unicode characters from the start and end of the current string object, case agnostic.
        /// </summary>
        /// <param name="trimChars">An array of Unicode characters.</param>
        /// <returns>The trimmed string.</returns>
        public static string TrimIgnoreCase(this string instance, char[] trimChars)
        {
            if (string.IsNullOrEmpty(instance) || trimChars.Length == 0)
                return instance;

            int startIndex = GetIndexOfLastLeadingAnyChar(instance, trimChars);
            int endIndex = GetIndexOfFirstTrailingAnyChar(instance, trimChars);

            if (startIndex > endIndex)
                return "";
            else
                return instance.Substring(startIndex, endIndex - startIndex);
        }

        /// <summary>
        /// Removes all the occurrences of a set of Unicode characters from the start of the current string object, case agnostic.
        /// </summary>
        /// <param name="trimChars">An array of Unicode characters.</param>
        /// <returns>The trimmed string.</returns>
        public static string TrimStartIgnoreCase(this string instance, char[] trimChars)
        {
            if (string.IsNullOrEmpty(instance) || trimChars.Length == 0)
                return instance;

            int startIndex = GetIndexOfLastLeadingAnyChar(instance, trimChars);

            return instance.Substring(startIndex);
        }

        /// <summary>
        /// Removes all the occurrences of a set of Unicode characters from the end of the current string object, case agnostic.
        /// </summary>
        /// <param name="trimChars">An array of Unicode characters.</param>
        /// <returns>The trimmed string.</returns>
        public static string TrimEndIgnoreCase(this string instance, char[] trimChars)
        {
            if (string.IsNullOrEmpty(instance) || trimChars.Length == 0)
                return instance;

            int endIndex = GetIndexOfFirstTrailingAnyChar(instance, trimChars);

            return instance.Substring(0, endIndex);
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
        public static string ReplaceIgnoreCase(this string instance, string oldValue, string newValue)
        {
            if (instance == null)
                throw new ArgumentNullException(nameof(instance));
            if (oldValue == null)
                throw new ArgumentNullException(nameof(oldValue));
            if (instance.Length == 0)
                return instance;
            if (oldValue.Length == 0)
                throw new ArgumentException("String cannot be of zero length.");

            StringBuilder replacedString = new StringBuilder(instance.Length);
            bool isNewValueNullOrEmpty = string.IsNullOrEmpty(newValue);
            int searchStartIndex = 0;
            int foundCharIndex;

            while ((foundCharIndex = instance.IndexOf(oldValue, searchStartIndex, StringComparison.OrdinalIgnoreCase)) != -1)
            {
                int numCharsUntilReplacement = foundCharIndex - searchStartIndex;
                if (numCharsUntilReplacement != 0)
                {
                    replacedString.Append(instance, searchStartIndex, numCharsUntilReplacement);
                }

                if (!isNewValueNullOrEmpty)
                {
                    replacedString.Append(newValue);
                }

                searchStartIndex = foundCharIndex + oldValue.Length;
                if (searchStartIndex == instance.Length)
                {
                    return replacedString.ToString();
                }
            }

            int numCharsUntilEnd = instance.Length - searchStartIndex;
            replacedString.Append(instance, searchStartIndex, numCharsUntilEnd);

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
        public static string ReplaceIgnoreCase(this string instance, char oldValue, char newValue)
        {
            if (instance == null)
                throw new ArgumentNullException(nameof(instance));
            if (instance.Length == 0)
                return instance;

            StringBuilder replacedString = new StringBuilder();

            char upperOldValue = char.ToUpper(oldValue);

            foreach (char c in instance)
            {
                if (char.ToUpper(c) == upperOldValue)
                    replacedString.Append(newValue);
                else
                    replacedString.Append(c);
            }

            return replacedString.ToString();
        }

        private static int GetIndexOfLastLeadingChar(string instance, char trimChar)
        {
            int startIndex = 0;

            for (int i = 0; i < instance.Length; i++)
            {
                if (char.ToUpper(instance[i]) == char.ToUpper(trimChar))
                    startIndex++;
                else
                    break;
            }

            return startIndex;
        }

        private static int GetIndexOfFirstTrailingChar(string instance, char trimChar)
        {
            int endIndex = instance.Length;

            for (int i = instance.Length - 1; i >= 0; i--)
            {
                if (char.ToUpper(instance[i]) == char.ToUpper(trimChar))
                    endIndex--;
                else
                    break;
            }

            return endIndex;
        }

        private static int GetIndexOfLastLeadingAnyChar(string instance, char[] trimChars)
        {
            int startIndex = 0;

            for (int i = 0; i < instance.Length; i++)
            {
                if (trimChars.Any(trimChar => char.ToUpper(instance[i]) == char.ToUpper(trimChar)))
                    startIndex++;
                else
                    break;
            }

            return startIndex;
        }

        private static int GetIndexOfFirstTrailingAnyChar(string instance, char[] trimChars)
        {
            int endIndex = instance.Length;
            for (int i = instance.Length - 1; i >= 0; i--)
            {
                if (trimChars.Any(trimChar => char.ToUpper(instance[i]) == char.ToUpper(trimChar)))
                    endIndex--;
                else
                    break;
            }

            return endIndex;
        }
    }
}
