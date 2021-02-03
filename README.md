# Extendy - a simple library of extension methods for C#

[![build](https://github.com/jamespfluger/extendy/workflows/build/badge.svg)](https://github.com/jamespfluger/Extendy/actions?query=workflow%3Abuild)
[![codecov](https://codecov.io/gh/jamespfluger/extendy/branch/main/graph/badge.svg)](https://codecov.io/gh/jamespfluger/Extendy)
[![Nuget](https://img.shields.io/nuget/v/Extendy)](https://www.nuget.org/packages/Extendy)
[![GitHub license](https://img.shields.io/github/license/jamespfluger/Extendy?color=blue)](https://github.com/jamespfluger/Extendy/blob/main/LICENSE)

## Why use Extendy?
If you find yourself constantly needing to write extension methods or tediously re-write implementations of them, then this package is right for you. Rather than doing all of that yourself, you can simply install Extendy. Now you can just use methods such as `yourVar.EqualsIgnoreCase(otherVar)` instead of the overly verbose `yourVar.Equals(someOtherVar, StringComparison.OrdinalIgnoreCase)`.

### Can I contribute?
Absolutely! Open an issue up and we'll discuss your proposal. I don't want this repo to become bloated with too many methods. They are meant to be practical and used often. More niche ones can be found elsewhere or written into your project.

### Which extenson methods are in Extendy?

There are four main sections, with the strings namespace broken into four further ones.  
I've considered consolidating them into one, but I don't want to bloat IntelliSense.


#### `Extendy.Collections`

| Method                                             | Summary                                                        |
| -------------------------------------------------- | -------------------------------------------------------------- |
| `ContainsAny<TSource, TValues>(params T[] values)` | Checks whether any of the values exist in the source           |
| `ContainsAny<T>(params T[] values)`                | Checks whether any of the values exist in the source           |
| `AddRange<TSource, TValues>(params T[] values)`    | Adds the specified values to the collection                    |
| `RemoveDuplicates<T>()`                            | Removes duplicate values from the collection                   |
| `DistinctBy<TSource, TValues>(Func keySelector)`   | Returns distinct elements from a sequence based on a function. |


#### `Extendy.DateTimes`

| Method                          | Summary                                                                                          |
| ------------------------------- | ------------------------------------------------------------------------------------------------ |
| `IsToday()`                     | Determines whether or not the input date is the same year, month, and day as the current day     |
| `IsTodayUtc()`                  | Determines whether or not the input date is the same year, month, and day as the current UTC day |
| `IsSameDay(DateTime otherDate)` | Determines whether or not the input date is the same year, month, and day as the other date      |


#### `Extendy.Enums`

| Method                       | Summary                                     |
| ---------------------------- | ------------------------------------------- |
| `ToEnum<T>()`                | Converts a string to the provided enum type |
| `ToEnum<T>(bool ignoreCase)` | Converts a string to the provided enum type |


#### `Extendy.Strings.Modification`

| Method                                                | Summary                                                                                                                                                                       |
| ----------------------------------------------------- | ----------------------------------------------------------------------------------------------------------------------------------------------------------------------------- |
| `ReplaceIgnoreCase(string oldValue, string newValue)` | Returns a new string in which all occurrences of a specified string, case agnostic, in the current instance are replaced with another specified string.                       |
| `ReplaceIgnoreCase(char oldValue, char newValue)`     | Returns a new string in which all occurrences of a specified Unicode character, case agnostic, in the current instance are replaced with another specified Unicode character. |
| `RemoveAll(string toRemove)`                          | Returns a new string in which all occurrences of toRemove in the current instance have been deleted.                                                                          |
| `RemoveAll(char toRemove)`                            | Returns a new string in which all occurrences of the toRemove char in the current instance have been deleted.                                                                 |
| `RemoveAllIgnoreCase(string toRemove)`                | Returns a new string in which all occurrences of toRemove, case agnostic, in the current instance have been deleted.                                                          |
| `RemoveAllIgnoreCase(char toRemove)`                  | Returns a new string in which all occurrences of the toRemove char, case agnostic, in the current instance have been deleted.                                                 |
| `Left(int length)`                                    | Returns the left substring of a given length from the current string object.                                                                                                  |
| `Right(int length)`                                   | Returns the right substring of a given length from the current string object.                                                                                                 |
| `Reverse()`                                           | Inverts the order of the elements in a string                                                                                                                                 |
| `TrimIgnoreCase(char trimChar)`                       | Removes all the occurrences of the given character at the start and end of the current string object, case agnostic.                                                          |
| `TrimStartIgnoreCase(char trimChar)`                  | Removes all the occurrences of the given character at the start of the current string object, case agnostic.                                                                  |
| `TrimEndIgnoreCase(char trimChar)`                    | Removes all the occurrences of the given character at the end of the current string object, case agnostic.                                                                    |
| `TrimIgnoreCase(char[] trimChars)`                    | Removes all the occurrences of a set of Unicode characters from the start and end of the current string object, case agnostic.                                                |
| `TrimStartIgnoreCase(char[] trimChars)`               | Removes all the occurrences of a set of Unicode characters from the start of the current string object, case agnostic.                                                        |
| `TrimEndIgnoreCase(char[] trimChars)`                 | Removes all the occurrences of a set of Unicode characters from the end of the current string object, case agnostic.                                                          |


#### `Extendy.Strings.Searching`

| Method                                                           | Summary                                                                                                                                                                                                                                                |
| ---------------------------------------------------------------- | ------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------ |
| `ContainsAny(string[] anyOf)`                                    | Determines whether this string occurs in anyOf or not.                                                                                                                                                                                                 |
| `ContainsAnyIgnoreCase(string[] anyOf)`                          | Determines whether this string occurs in anyOf or not, case agnostic.                                                                                                                                                                                  |
| `IndexOfIgnoreCase(string value)`                                | Reports the zero-based index of the first occurrence of the specified string in this instance, case agnostic.                                                                                                                                          |
| `IndexOfIgnoreCase(string value, int startIndex)`                | Reports the zero-based index of the first occurrence of the specified string in this instance, case agnostic. The search starts at a specified index.                                                                                                  |
| `IndexOfIgnoreCase(string value, int startIndex, int count)`     | Reports the zero-based index of the first occurrence of the specified string in this instance, case agnostic. The search starts at a specified index and examines a specified number of positions.                                                     |
| `IndexOfIgnoreCase(char value)`                                  | Reports the zero-based index of the first occurrence of the specified Unicode character in this instance, case agnostic.                                                                                                                               |
| `IndexOfIgnoreCase(char value, int startIndex)`                  | Reports the zero-based index of the first occurrence of the specified Unicode character in this instance, case agnostic. The search starts at a specified index.                                                                                       |
| `IndexOfIgnoreCase(char value, int startIndex, int count)`       | Reports the zero-based index of the first occurrence of the specified Unicode character in this instance, case agnostic. The search starts at a specified index and examines a specified number of positions.                                          |
| `LastIndexOfIgnoreCase(string value)`                            | Reports the zero-based index of the last occurrence of the specified string in this instance, case agnostic.                                                                                                                                           |
| `LastIndexOfIgnoreCase(string value, int startIndex)`            | Reports the zero-based index of the last occurrence of the specified string in this instance, case agnostic. The search starts at a specified index and works backwards through the string.                                                            |
| `LastIndexOfIgnoreCase(string value, int startIndex, int count)` | Reports the zero-based index of the last occurrence of the specified string in this instance, case agnostic. The search starts at a specified index and works backwards through the string for the specified number of character positions.            |
| `LastIndexOfIgnoreCase(char value)`                              | Reports the zero-based index of the last occurrence of the specified Unicode character in this instance, case agnostic.                                                                                                                                |
| `LastIndexOfIgnoreCase(char value, int startIndex)`              | Reports the zero-based index of the last occurrence of the specified Unicode character in this instance, case agnostic. The search starts at a specified index and works backwards through the string.                                                 |
| `LastIndexOfIgnoreCase(char value, int startIndex, int count)`   | Reports the zero-based index of the last occurrence of the specified Unicode character in this instance, case agnostic. The search starts at a specified index and works backwards through the string for the specified number of character positions. |


#### `Extendy.Strings.TypeChecks`

| Method             | Summary                                                                              |
| ------------------ | ------------------------------------------------------------------------------------ |
| `IsNumeric()`      | Determines whether this instance contains only numeric characters                    |
| `IsAlphabetic()`   | Determines whether this instance contains only alphabetic characters.                |
| `IsAlphaNumeric()` | Determines whether this instance contains only alphabetic and/or numeric characters. |
| `IsUpper()`        | Determines whether this instance contains only uppercase alphabetic characters.      |
| `IsLower()`        | Determines whether this instance contains only lowercase alphabetic characters.      |
