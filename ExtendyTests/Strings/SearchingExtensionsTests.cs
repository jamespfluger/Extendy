using System;
using Extendy.Strings.Searching;
using Xunit;

namespace ExtendyTests.Strings.Searching
{
    public class SearchingExtensionsTests
    {
        [Theory]
        [InlineData("Seattle", new string[] { "atle", "ee", "Sea", "elt" }, true)]
        [InlineData("abcde", new string[] { "1", "2", "3", "d", "5" }, true)]
        [InlineData("Seattle", new string[] { "Eattle", "ee", "sea", "Tle" }, false)]
        [InlineData("Seattle", new string[] { "Att", "Ttle" }, false)]
        [InlineData("Seattle", new string[] { "Seo", "tlee" }, false)]
        [InlineData("", new string[] { "a", "b", "c", "d", "e" }, false)]
        [InlineData("Value", new string[] { }, false)]
        [InlineData("", new string[] { }, false)]
        public void ContainsAnyTest(string haystackInput, string[] needlesInput, bool expectedIndex)
        {
            bool haystackContainsNeedle = haystackInput.ContainsAny(needlesInput);
            Assert.Equal(expectedIndex, haystackContainsNeedle);
        }

        [Theory]
        [InlineData(null, new string[] { "1", "2", "3", "4", "5" }, typeof(ArgumentNullException), "Value cannot be null. (Parameter 'source')")]
        [InlineData("abcde", new string[] { "1", "2", null, "4", "5" }, typeof(ArgumentNullException), "No argument can be null. (Parameter 'anyOf')")]
        [InlineData("abcde", null, typeof(ArgumentNullException), "Value cannot be null. (Parameter 'anyOf')")]
        public void ContainsAnyExceptionTest(string haystackInput, string[] needlesInput, Type expectedExceptionType, string expectedErrorMessage)
        {
            Exception thrownException = Assert.Throws(expectedExceptionType, () => haystackInput.ContainsAny(needlesInput));
            Assert.NotNull(thrownException);
            Assert.Equal(expectedErrorMessage, thrownException.Message);
        }

        [Theory]
        [InlineData("Seattle", new string[] { "atle", "ee", "Sea", "elt" }, true)]
        [InlineData("abcde", new string[] { "1", "2", "3", "d", "5" }, true)]
        [InlineData("Seattle", new string[] { "Eattle", "ee", "sea", "Tle" }, true)]
        [InlineData("Seattle", new string[] { "Att", "Ttle" }, true)]
        [InlineData("Seattle", new string[] { "Seo", "tlee" }, false)]
        [InlineData("", new string[] { "a", "b", "c", "d", "e" }, false)]
        [InlineData("Value", new string[] { }, false)]
        [InlineData("", new string[] { }, false)]
        public void ContainsAnyIgnoreCaseTest(string haystackInput, string[] needlesInput, bool expectedIndex)
        {
            bool haystackContainsNeedle = haystackInput.ContainsAnyIgnoreCase(needlesInput);
            Assert.Equal(expectedIndex, haystackContainsNeedle);
        }

        [Theory]
        [InlineData(null, new string[] { "a", "B", "c", "D", "e" }, typeof(ArgumentNullException), "Value cannot be null. (Parameter 'source')")]
        [InlineData("abcde", new string[] { "a", "B", null, "D", "e" }, typeof(ArgumentNullException), "No argument can be null. (Parameter 'anyOf')")]
        [InlineData("abcde", null, typeof(ArgumentNullException), "Value cannot be null. (Parameter 'anyOf')")]
        public void ContainsAnyIgnoreCaseExceptionTest(string haystackInput, string[] needlesInput, Type expectedExceptionType, string expectedErrorMessage)
        {
            Exception thrownException = Assert.Throws(expectedExceptionType, () => haystackInput.ContainsAnyIgnoreCase(needlesInput));
            Assert.NotNull(thrownException);
            Assert.Equal(expectedErrorMessage, thrownException.Message);
        }

        [Theory]
        [InlineData("Seattlez", "Z", 7)]
        [InlineData("Seattlez", "z", 7)]
        [InlineData("Seattle", "S", 0)]
        [InlineData("Seattle", "s", 0)]
        [InlineData("Seattle", "T", 3)]
        [InlineData("Seattle", "t", 3)]
        [InlineData("Seatatlez", "TA", 3)]
        [InlineData("Seatatlez", "ta", 3)]
        [InlineData("Evergreen", "eV", 0)]
        [InlineData("Evergreen", "En", 7)]
        [InlineData("Seattle", "EAT", 1)]
        [InlineData("Seattle", "eat", 1)]
        [InlineData("Seattle", "SEATTLE", 0)]
        [InlineData("Seattle", "sEaTtLe", 0)]
        [InlineData("Seattle has an eat in the Eatsy", "EAT", 1)]
        [InlineData("Seattle has an eat in the Eatsy", "Eat", 1)]
        [InlineData("Seattlez", "y", -1)]
        [InlineData("", "q", -1)]
        [InlineData("\0", "Seattle", -1)]
        [InlineData("", "", 0)]
        [InlineData("", "\0", -1)]
        [InlineData("\0", "", 0)]
        [InlineData("\0", "\0", 0)]
        public void IndexOfIgnoreCaseStringTest(string inputValue, string strToFind, int expectedIndex)
        {
            int indexFound = inputValue.IndexOfIgnoreCase(strToFind);
            Assert.Equal(expectedIndex, indexFound);
            Assert.Equal(expectedIndex, inputValue.ToUpper().IndexOf(strToFind?.ToUpper()));
        }


        [Theory]
        [InlineData("Seattlez", "Z", 7, 7)]
        [InlineData("Seattlez", "z", 7, 7)]
        [InlineData("Seattlez", "Z", 0, 7)]
        [InlineData("Seattlez", "z", 0, 7)]
        [InlineData("Seattle", "S", 0, 0)]
        [InlineData("Seattle", "s", 0, 0)]
        [InlineData("Seattle", "S", 1, -1)]
        [InlineData("Seattle", "s", 1, -1)]
        [InlineData("Seattle", "T", 3, 3)]
        [InlineData("Seattle", "t", 3, 3)]
        [InlineData("Seattle", "T", 4, 4)]
        [InlineData("Seattle", "t", 4, 4)]
        [InlineData("Seatatlez", "Ta", 2, 3)]
        [InlineData("Seatatlez", "tA", 2, 3)]
        [InlineData("Evergreen", "eV", 0, 0)]
        [InlineData("Evergreen", "En", 7, 7)]
        [InlineData("Seattle", "EAT", 1, 1)]
        [InlineData("Seattle", "Eat", 1, 1)]
        [InlineData("Seattle", "SEATTLE", 0, 0)]
        [InlineData("Seattle", "sEaTtLe", 0, 0)]
        [InlineData("Seattle has an eat in the Eatsy", "EAT", 2, 15)]
        [InlineData("Seattle has an eat in the Eatsy", "Eat", 2, 15)]
        [InlineData("Seattle has an eat in the Eatsy", "EAT", 29, -1)]
        [InlineData("Seattle has an eat in the Eatsy", "Eat", 29, -1)]
        [InlineData("Seattlez", "y", 0, -1)]
        [InlineData("Seattle", "", 0, 0)]
        [InlineData("", "", 0, 0)]
        [InlineData("\0", "", 0, 0)]
        [InlineData("\0", "Seattle", 0, -1)]
        [InlineData("", "\0", 0, -1)]
        [InlineData("\0", "\0", 0, 0)]
        public void IndexOfIgnoreCaseStringStartIndexTest(string inputValue, string strToFind, int startIndex, int expectedIndex)
        {
            int indexFound = inputValue.IndexOfIgnoreCase(strToFind, startIndex);
            Assert.Equal(expectedIndex, indexFound);
            Assert.Equal(expectedIndex, inputValue.ToUpper().IndexOf(strToFind?.ToUpper(), startIndex));
        }

        [Theory]
        [InlineData("Seattlez", "Z", 7, 0, -1)]
        [InlineData("Seattlez", "z", 7, 0, -1)]
        [InlineData("Seattlez", "Z", 7, 1, 7)]
        [InlineData("Seattlez", "z", 7, 1, 7)]
        [InlineData("Seattle", "S", 0, 1, 0)]
        [InlineData("Seattle", "s", 0, 1, 0)]
        [InlineData("Seattle", "S", 0, 0, -1)]
        [InlineData("Seattle", "s", 0, 0, -1)]
        [InlineData("Seattle", "S", 1, 6, -1)]
        [InlineData("Seattle", "s", 1, 6, -1)]
        [InlineData("Seattle", "T", 3, 1, 3)]
        [InlineData("Seattle", "t", 3, 1, 3)]
        [InlineData("Seattle", "T", 4, 1, 4)]
        [InlineData("Seattle", "t", 4, 1, 4)]
        [InlineData("Seatatlez", "Ta", 3, 2, 3)]
        [InlineData("Seatatlez", "tA", 3, 2, 3)]
        [InlineData("Evergreen", "eV", 0, 2, 0)]
        [InlineData("Evergreen", "En", 7, 2, 7)]
        [InlineData("Seattle", "EAT", 0, 4, 1)]
        [InlineData("Seattle", "eat", 0, 4, 1)]
        [InlineData("Seattle", "SEATTLE", 0, 7, 0)]
        [InlineData("Seattle", "sEaTtLe", 0, 7, 0)]
        [InlineData("Seattle has an eat in the Eatsy", "EAT", 2, 20, 15)]
        [InlineData("Seattle has an eat in the Eatsy", "Eat", 2, 20, 15)]
        [InlineData("Seattle has an eat in the Eatsy", "EAT", 2, 19, 15)]
        [InlineData("Seattle has an eat in the Eatsy", "Eat", 2, 19, 15)]
        [InlineData("Seattle has an eat in the Eatsy", "EAT", 23, 3, -1)]
        [InlineData("Seattle has an eat in the Eatsy", "Eat", 23, 3, -1)]
        [InlineData("Seattlez", "Y", 0, 8, -1)]
        [InlineData("Seattlez", "y", 0, 8, -1)]
        [InlineData("Seattle", "", 0, 0, 0)]
        [InlineData("", "", 0, 0, 0)]
        [InlineData("Seattle", "\0", 0, 0, -1)]
        [InlineData("\0", "Seattle", 0, 0, -1)]
        [InlineData("\0", "", 0, 1, 0)]
        [InlineData("", "\0", 0, 0, -1)]
        [InlineData("\0", "\0", 0, 1, 0)]
        public void IndexOfIgnoreCaseStringStartIndexAndCountTest(string inputValue, string strToFind, int startIndex, int count, int expectedIndex)
        {
            int indexFound = inputValue.IndexOfIgnoreCase(strToFind, startIndex, count);
            Assert.Equal(expectedIndex, indexFound);
            Assert.Equal(expectedIndex, inputValue.ToUpper().IndexOf(strToFind?.ToUpper(), startIndex, count));
        }

        [Theory]
        [InlineData("Seattlez", 'Z', 7)]
        [InlineData("Seattlez", 'z', 7)]
        [InlineData("Seattle", 'S', 0)]
        [InlineData("Seattle", 's', 0)]
        [InlineData("Seattle", 'T', 3)]
        [InlineData("Seattle", 't', 3)]
        [InlineData("Seattle", 'E', 1)]
        [InlineData("Seattle", 'e', 1)]
        [InlineData("Seattlez", 'Y', -1)]
        [InlineData("Seattlez", 'y', -1)]
        [InlineData("", 'q', -1)]
        [InlineData("Seattle", '\0', -1)]
        [InlineData("", '\0', -1)]
        [InlineData("\0", '\0', 0)]
        public void IndexOfIgnoreCaseCharTest(string inputValue, char charToFind, int expectedIndex)
        {
            int indexFound = inputValue.IndexOfIgnoreCase(charToFind);
            Assert.Equal(expectedIndex, indexFound);
            Assert.Equal(expectedIndex, inputValue.ToUpper().IndexOf(char.ToUpper(charToFind)));
        }

        [Theory]
        [InlineData("Seattle", 'E', 1, 1)]
        [InlineData("Seattle", 'e', 1, 1)]
        [InlineData("Seattlez", 'Z', 7, 7)]
        [InlineData("Seattlez", 'z', 0, 7)]
        [InlineData("Seattle", 'S', 0, 0)]
        [InlineData("Seattle", 's', 0, 0)]
        [InlineData("Seattle", 'S', 1, -1)]
        [InlineData("Seattle", 's', 1, -1)]
        [InlineData("Seattle", 'T', 0, 3)]
        [InlineData("Seattle", 't', 0, 3)]
        [InlineData("Seattle", 'T', 3, 3)]
        [InlineData("Seattle", 't', 3, 3)]
        [InlineData("Seattle", 'T', 4, 4)]
        [InlineData("Seattle", 't', 4, 4)]
        [InlineData("Seattle", 'T', 5, -1)]
        [InlineData("Seattle", 't', 5, -1)]
        [InlineData("SeattleSound", 'E', 2, 6)]
        [InlineData("SeattleSound", 'e', 2, 6)]
        [InlineData("SeattleSound", 'E', 12, -1)]
        [InlineData("SeattleSound", 'e', 12, -1)]
        [InlineData("Seattlez", 'Y', 0, -1)]
        [InlineData("Seattlez", 'y', 0, -1)]
        [InlineData("Seattle", '\0', 0, -1)]
        [InlineData("", '\0', 0, -1)]
        [InlineData("\0", '\0', 0, 0)]
        public void IndexOfIgnoreCaseCharStartIndexTest(string inputValue, char charToFind, int startIndex, int expectedIndex)
        {
            int indexFound = inputValue.IndexOfIgnoreCase(charToFind, startIndex);
            Assert.Equal(expectedIndex, indexFound);
            Assert.Equal(expectedIndex, inputValue.ToUpper().IndexOf(char.ToUpper(charToFind), startIndex));
        }

        [Theory]
        [InlineData("Seattle", 'E', 1, 2, 1)]
        [InlineData("SeattleZ", 'Z', 7, 0, -1)]
        [InlineData("SeattleZ", 'z', 7, 0, -1)]
        [InlineData("SeattleZ", 'Z', 7, 1, 7)]
        [InlineData("SeattleZ", 'z', 7, 1, 7)]
        [InlineData("SeattleZ", 'Z', 0, 8, 7)]
        [InlineData("SeattleZ", 'z', 0, 8, 7)]
        [InlineData("Seattle", 'S', 0, 1, 0)]
        [InlineData("Seattle", 's', 0, 1, 0)]
        [InlineData("SeatTle", 'S', 1, 1, -1)]
        [InlineData("Seattle", 's', 1, 1, -1)]
        [InlineData("SeatTle", 'T', 0, 4, 3)]
        [InlineData("SeatTle", 't', 0, 4, 3)]
        [InlineData("SeatTle", 'T', 0, 5, 3)]
        [InlineData("SeatTle", 't', 0, 5, 3)]
        [InlineData("SeatTle", 'T', 3, 1, 3)]
        [InlineData("SeatTle", 't', 3, 1, 3)]
        [InlineData("SeatTle", 'T', 4, 1, 4)]
        [InlineData("SeatTle", 't', 4, 1, 4)]
        [InlineData("SeatTle", 'T', 5, 1, -1)]
        [InlineData("SeatTle", 't', 5, 1, -1)]
        [InlineData("SeattleSound", 'E', 2, 10, 6)]
        [InlineData("SeattleSound", 'e', 2, 10, 6)]
        [InlineData("SeattleSound", 'E', 7, 5, -1)]
        [InlineData("SeattleSound", 'e', 7, 5, -1)]
        [InlineData("Seattlez", 'Y', 0, 1, -1)]
        [InlineData("Seattlez", 'y', 0, 1, -1)]
        [InlineData("Seattle", '\0', 0, 0, -1)]
        [InlineData("", '\0', 0, 0, -1)]
        [InlineData("\0", '\0', 0, 1, 0)]
        public void IndexOfIgnoreCaseCharStartIndexAndCountTest(string inputValue, char charToFind, int startIndex, int count, int expectedIndex)
        {
            int indexFound = inputValue.IndexOfIgnoreCase(charToFind, startIndex, count);
            Assert.Equal(expectedIndex, indexFound);
            Assert.Equal(expectedIndex, inputValue.ToUpper().IndexOf(char.ToUpper(charToFind), startIndex, count));
        }

        [Theory]
        [InlineData(null, "Seattle", typeof(ArgumentNullException), "Value cannot be null. (Parameter 'source')")]
        [InlineData(null, "\0", typeof(ArgumentNullException), "Value cannot be null. (Parameter 'source')")]
        [InlineData(null, null, typeof(ArgumentNullException), "Value cannot be null. (Parameter 'source')")]
        public void IndexOfIgnoreCaseStringExceptionTest(string inputValue, string strToFind, Type expectedExceptionType, string expectedErrorMessage)
        {
            Exception thrownException = Assert.Throws(expectedExceptionType, () => inputValue.IndexOfIgnoreCase(strToFind));
            Assert.NotNull(thrownException);
            Assert.Equal(expectedErrorMessage, thrownException.Message);
        }

        [Theory]
        [InlineData(null, "Seattle", 3, typeof(ArgumentNullException), "Value cannot be null. (Parameter 'source')")]
        [InlineData(null, "\0", 0, typeof(ArgumentNullException), "Value cannot be null. (Parameter 'source')")]
        [InlineData(null, null, 0, typeof(ArgumentNullException), "Value cannot be null. (Parameter 'source')")]
        [InlineData("Seattle", null, 3, typeof(ArgumentNullException), "Value cannot be null. (Parameter 'value')")]
        [InlineData("\0", null, 0, typeof(ArgumentNullException), "Value cannot be null. (Parameter 'value')")]
        [InlineData("", null, 0, typeof(ArgumentNullException), "Value cannot be null. (Parameter 'value')")]
        [InlineData("Seattle", "sea", -1, typeof(ArgumentOutOfRangeException), "Index was out of range. Must be non-negative and less than the size of the collection. (Parameter 'startIndex')")]
        [InlineData("Seattle", "le", 8, typeof(ArgumentOutOfRangeException), "Index was out of range. Must be non-negative and less than the size of the collection. (Parameter 'startIndex')")]
        public void IndexOfIgnoreCaseStringStartIndexExceptionTest(string inputValue, string strToFind, int startIndex, Type expectedExceptionType, string expectedErrorMessage)
        {
            Exception thrownException = Assert.Throws(expectedExceptionType, () => inputValue.IndexOfIgnoreCase(strToFind, startIndex));
            Assert.NotNull(thrownException);
            Assert.Equal(expectedErrorMessage, thrownException.Message);
        }

        [Theory]
        [InlineData(null, "Seattle", 0, 3, typeof(ArgumentNullException), "Value cannot be null. (Parameter 'source')")]
        [InlineData(null, "\0", 0, 1, typeof(ArgumentNullException), "Value cannot be null. (Parameter 'source')")]
        [InlineData(null, null, 0, 0, typeof(ArgumentNullException), "Value cannot be null. (Parameter 'source')")]
        [InlineData("Seattle", null, 0, 3, typeof(ArgumentNullException), "Value cannot be null. (Parameter 'value')")]
        [InlineData("\0", null, 0, 1, typeof(ArgumentNullException), "Value cannot be null. (Parameter 'value')")]
        [InlineData("", null, 0, 0, typeof(ArgumentNullException), "Value cannot be null. (Parameter 'value')")]
        [InlineData("Seattle", "sea", -1, 0, typeof(ArgumentOutOfRangeException), "Index was out of range. Must be non-negative and less than the size of the collection. (Parameter 'startIndex')")]
        [InlineData("Seattle", "le", 8, 0, typeof(ArgumentOutOfRangeException), "Index was out of range. Must be non-negative and less than the size of the collection. (Parameter 'startIndex')")]
        [InlineData("Seattle", "sea", 0, 20, typeof(ArgumentOutOfRangeException), "Count must be positive and count must refer to a location within the string/array/collection. (Parameter 'count')")]
        [InlineData("Seattle", "le", 3, -1, typeof(ArgumentOutOfRangeException), "Count must be positive and count must refer to a location within the string/array/collection. (Parameter 'count')")]
        public void IndexOfIgnoreCaseStringStartIndexAndCountExceptionTest(string inputValue, string strToFind, int startIndex, int count, Type expectedExceptionType, string expectedErrorMessage)
        {
            Exception thrownException = Assert.Throws(expectedExceptionType, () => inputValue.IndexOfIgnoreCase(strToFind, startIndex, count));
            Assert.NotNull(thrownException);
            Assert.Equal(expectedErrorMessage, thrownException.Message);
        }

        [Theory]
        [InlineData(null, 'c', typeof(ArgumentNullException), "Value cannot be null. (Parameter 'source')")]
        [InlineData(null, '\0', typeof(ArgumentNullException), "Value cannot be null. (Parameter 'source')")]
        public void IndexOfIgnoreCaseCharExceptionTest(string inputValue, char charToFind, Type expectedExceptionType, string expectedErrorMessage)
        {
            Exception thrownException = Assert.Throws(expectedExceptionType, () => inputValue.IndexOfIgnoreCase(charToFind));
            Assert.NotNull(thrownException);
            Assert.Equal(expectedErrorMessage, thrownException.Message);
        }

        [Theory]
        [InlineData(null, 'c', 0, typeof(ArgumentNullException), "Value cannot be null. (Parameter 'source')")]
        [InlineData(null, '\0', 0, typeof(ArgumentNullException), "Value cannot be null. (Parameter 'source')")]
        [InlineData("Seattle", 'a', -1, typeof(ArgumentOutOfRangeException), "Index was out of range. Must be non-negative and less than the size of the collection. (Parameter 'startIndex')")]
        [InlineData("Seattle", 'a', 8, typeof(ArgumentOutOfRangeException), "Index was out of range. Must be non-negative and less than the size of the collection. (Parameter 'startIndex')")]
        public void IndexOfIgnoreCaseCharStartIndexExceptionTest(string inputValue, char charToFind, int startIndex, Type expectedExceptionType, string expectedErrorMessage)
        {
            Exception thrownException = Assert.Throws(expectedExceptionType, () => inputValue.IndexOfIgnoreCase(charToFind, startIndex));
            Assert.NotNull(thrownException);
            Assert.Equal(expectedErrorMessage, thrownException.Message);
        }

        [Theory]
        [InlineData(null, 'c', 0, 0, typeof(ArgumentNullException), "Value cannot be null. (Parameter 'source')")]
        [InlineData(null, '\0', 0, 0, typeof(ArgumentNullException), "Value cannot be null. (Parameter 'source')")]
        [InlineData("Seattle", 'a', -1, 0, typeof(ArgumentOutOfRangeException), "Index was out of range. Must be non-negative and less than the size of the collection. (Parameter 'startIndex')")]
        [InlineData("Seattle", 'a', 8, 0, typeof(ArgumentOutOfRangeException), "Index was out of range. Must be non-negative and less than the size of the collection. (Parameter 'startIndex')")]
        [InlineData("Seattle", 'a', 0, -1, typeof(ArgumentOutOfRangeException), "Count must be positive and count must refer to a location within the string/array/collection. (Parameter 'count')")]
        [InlineData("Seattle", 'a', 3, 20, typeof(ArgumentOutOfRangeException), "Count must be positive and count must refer to a location within the string/array/collection. (Parameter 'count')")]
        public void IndexOfIgnoreCaseCharStartIndexAndCountExceptionTest(string inputValue, char charToFind, int startIndex, int count, Type expectedExceptionType, string expectedErrorMessage)
        {
            Exception thrownException = Assert.Throws(expectedExceptionType, () => inputValue.IndexOfIgnoreCase(charToFind, startIndex, count));
            Assert.NotNull(thrownException);
            Assert.Equal(expectedErrorMessage, thrownException.Message);
        }

        [Theory]
        [InlineData("SeattlE", "E", 6)]
        [InlineData("SeattlE", "e", 6)]
        [InlineData("Seattle", "S", 0)]
        [InlineData("Seattle", "s", 0)]
        [InlineData("Seattle", "T", 4)]
        [InlineData("Seattle", "t", 4)]
        [InlineData("Seatatale", "Ta", 5)]
        [InlineData("Seatatale", "tA", 5)]
        [InlineData("Evergreen", "eV", 0)]
        [InlineData("Evergreen", "En", 7)]
        [InlineData("Seattle", "EAT", 1)]
        [InlineData("Seattle", "eat", 1)]
        [InlineData("Seattle", "SEATTLE", 0)]
        [InlineData("Seattle", "sEaTtLe", 0)]
        [InlineData("Seattle has an eat in the Eatsy", "EAT", 26)]
        [InlineData("Seattle has an eat in the Eatsy", "eAT", 26)]
        [InlineData("Seattlez", "y", -1)]
        [InlineData("", "q", -1)]
        [InlineData("\0", "Seattle", -1)]
        [InlineData("", "", 0)]
        [InlineData("", "\0", -1)]
        [InlineData("\0", "", 0)]
        [InlineData("\0", "\0", 0)]
        public void LastIndexOfIgnoreCaseStringTest(string inputValue, string strToFind, int expectedIndex)
        {
            int indexFound = inputValue.LastIndexOfIgnoreCase(strToFind);
            Assert.Equal(expectedIndex, indexFound);
            Assert.Equal(expectedIndex, inputValue.ToUpper().LastIndexOf(strToFind?.ToUpper()));
        }

        [Theory]
        [InlineData("Seattlez", "Z", 7, 7)]
        [InlineData("Seattlez", "z", 7, 7)]
        [InlineData("Seattlez", "Z", 0, -1)]
        [InlineData("Seattlez", "z", 0, -1)]
        [InlineData("Seattle", "S", 0, 0)]
        [InlineData("Seattle", "s", 0, 0)]
        [InlineData("Seattle", "S", 1, 0)]
        [InlineData("Seattle", "s", 1, 0)]
        [InlineData("Seattle", "T", 3, 3)]
        [InlineData("Seattle", "t", 3, 3)]
        [InlineData("Seattle", "T", 4, 4)]
        [InlineData("Seattle", "t", 4, 4)]
        [InlineData("Evergreen", "eV", 1, 0)]
        [InlineData("Evergreen", "En", 8, 7)]
        [InlineData("Seattle", "EAT", 3, 1)]
        [InlineData("Seattle", "Eat", 3, 1)]
        [InlineData("Seattle", "SEATTLE", 0, -1)]
        [InlineData("Seattle", "sEaTtLe", 0, -1)]
        [InlineData("Seatatale takes ta Rain", "Ta", 2, -1)]
        [InlineData("Seatatale takes ta Rain", "tA", 2, -1)]
        [InlineData("Seatatale takes ta Rain", "Ta", 13, 10)]
        [InlineData("Seatatale takes ta Rain", "tA", 13, 10)]
        [InlineData("Seattle has an eat in the Eatsy", "EAT", 23, 15)]
        [InlineData("Seattle has an eat in the Eatsy", "Eat", 23, 15)]
        [InlineData("Seattle has an eat in the Eatsy", "EAT", 2, -1)]
        [InlineData("Seattle has an eat in the Eatsy", "Eat", 2, -1)]
        [InlineData("Seattlez", "y", 7, -1)]
        [InlineData("Seattle", "", 0, 0)]
        [InlineData("", "", 0, 0)]
        [InlineData("\0", "", 0, 0)]
        [InlineData("\0", "Seattle", 0, -1)]
        [InlineData("", "\0", 0, -1)]
        [InlineData("\0", "\0", 0, 0)]
        public void LastIndexOfIgnoreCaseStringStartIndexTest(string inputValue, string strToFind, int startIndex, int expectedIndex)
        {
            int indexFound = inputValue.LastIndexOfIgnoreCase(strToFind, startIndex);
            Assert.Equal(expectedIndex, indexFound);
            Assert.Equal(expectedIndex, inputValue.ToUpper().LastIndexOf(strToFind?.ToUpper(), startIndex));
        }

        [Theory]
        [InlineData("Seattlez", "Z", 7, 0, -1)]
        [InlineData("Seattlez", "z", 7, 0, -1)]
        [InlineData("Seattlez", "Z", 7, 1, 7)]
        [InlineData("Seattlez", "z", 7, 1, 7)]
        [InlineData("Seattle", "S", 0, 1, 0)]
        [InlineData("Seattle", "s", 0, 1, 0)]
        [InlineData("Seattle", "S", 0, 0, -1)]
        [InlineData("Seattle", "s", 0, 0, -1)]
        [InlineData("Seattle", "E", 6, 1, 6)]
        [InlineData("Seattle", "e", 6, 1, 6)]
        [InlineData("Seattle", "E", 7, 1, -1)]
        [InlineData("Seattle", "e", 7, 1, -1)]
        [InlineData("Seattle", "T", 3, 1, 3)]
        [InlineData("Seattle", "t", 3, 1, 3)]
        [InlineData("Seattle", "T", 4, 1, 4)]
        [InlineData("Seattle", "t", 4, 1, 4)]
        [InlineData("Evergreen", "eV", 1, 2, 0)]
        [InlineData("Evergreen", "En", 8, 2, 7)]
        [InlineData("Evergreen", "eV", 1, 1, -1)]
        [InlineData("Evergreen", "En", 8, 1, -1)]
        [InlineData("Seattle", "EAT", 4, 4, 1)]
        [InlineData("Seattle", "eat", 4, 4, 1)]
        [InlineData("Seattle", "SEATTLE", 6, 7, 0)]
        [InlineData("Seattle", "sEaTtLe", 6, 7, 0)]
        [InlineData("Seatatale takes ta Rain", "Ta", 3, 1, -1)]
        [InlineData("Seatatale takes ta Rain", "tA", 3, 1, -1)]
        [InlineData("Seatatale takes ta Rain", "Ta", 13, 4, 10)]
        [InlineData("Seatatale takes ta Rain", "tA", 13, 4, 10)]
        [InlineData("Seattle has an eat in the Eatsy", "EAT", 17, 3, 15)]
        [InlineData("Seattle has an eat in the Eatsy", "Eat", 17, 3, 15)]
        [InlineData("Seattle has an eat in the Eatsy", "EAT", 2, 3, -1)]
        [InlineData("Seattle has an eat in the Eatsy", "Eat", 2, 3, -1)]
        [InlineData("Seattlez", "Y", 7, 7, -1)]
        [InlineData("Seattlez", "y", 7, 7, -1)]
        [InlineData("Seattle", "", 0, 1, 0)]
        [InlineData("Seattle", "", 0, 0, 0)]
        [InlineData("", "", 0, 1, 0)]
        [InlineData("", "", 0, 0, 0)]
        [InlineData("\0", "", 0, 1, 0)]
        [InlineData("\0", "", 0, 0, 0)]
        [InlineData("Seattle", "\0", 0, 0, -1)]
        [InlineData("\0", "Seattle", 0, 0, -1)]
        [InlineData("", "\0", 0, 1, -1)]
        [InlineData("", "\0", 0, 0, -1)]
        [InlineData("\0", "\0", 0, 1, 0)]
        [InlineData("\0", "\0", 0, 0, -1)]
        public void LastIndexOfIgnoreCaseStringStartIndexAndCountTest(string inputValue, string strToFind, int startIndex, int count, int expectedIndex)
        {
            int indexFound = inputValue.LastIndexOfIgnoreCase(strToFind, startIndex, count);
            Assert.Equal(expectedIndex, indexFound);
            Assert.Equal(expectedIndex, inputValue.ToUpper().LastIndexOf(strToFind?.ToUpper(), startIndex, count));
        }

        [Theory]
        [InlineData("Seattlez", 'Z', 7)]
        [InlineData("Seattlez", 'z', 7)]
        [InlineData("Seattle", 'S', 0)]
        [InlineData("Seattle", 's', 0)]
        [InlineData("Seattle", 'T', 4)]
        [InlineData("Seattle", 't', 4)]
        [InlineData("Seattle", 'E', 6)]
        [InlineData("Seattle", 'e', 6)]
        [InlineData("Seattlez", 'Y', -1)]
        [InlineData("Seattlez", 'y', -1)]
        [InlineData("Seattle", '\0', -1)]
        [InlineData("Seattle ", ' ', 7)]
        [InlineData(" Seattle", ' ', 0)]
        [InlineData("\0", 'q', -1)]
        [InlineData(" ", ' ', 0)]
        [InlineData(" ", '\0', -1)]
        [InlineData("", '\0', -1)]
        [InlineData("\0", '\0', 0)]
        public void LastIndexOfIgnoreCaseCharTest(string inputValue, char charToFind, int expectedIndex)
        {
            int indexFound = inputValue.LastIndexOfIgnoreCase(charToFind);
            Assert.Equal(expectedIndex, indexFound);
            Assert.Equal(expectedIndex, inputValue.ToUpper().LastIndexOf(char.ToUpper(charToFind)));
        }

        [Theory]
        [InlineData("Seattle", 'E', 6, 6)]
        [InlineData("Seattle", 'e', 6, 6)]
        [InlineData("Seattlez", 'Z', 7, 7)]
        [InlineData("Seattlez", 'z', 7, 7)]
        [InlineData("Seattle", 'S', 0, 0)]
        [InlineData("Seattle", 's', 0, 0)]
        [InlineData("Seattle", 'S', 1, 0)]
        [InlineData("Seattle", 's', 1, 0)]
        [InlineData("Seattle", 'T', 0, -1)]
        [InlineData("Seattle", 't', 0, -1)]
        [InlineData("Seattle", 'T', 3, 3)]
        [InlineData("Seattle", 't', 3, 3)]
        [InlineData("Seattle", 'T', 4, 4)]
        [InlineData("Seattle", 't', 4, 4)]
        [InlineData("Seattle", 'T', 5, 4)]
        [InlineData("Seattle", 't', 5, 4)]
        [InlineData("Seattle", 'Y', 6, -1)]
        [InlineData("Seattle", 'y', 6, -1)]
        [InlineData("Seattle ", ' ', 7, 7)]
        [InlineData(" Seattle", ' ', 0, 0)]
        [InlineData("Seattle", '\0', 0, -1)]
        [InlineData("\0", 'q', 0, -1)]
        [InlineData(" ", ' ', 0, 0)]
        [InlineData(" ", '\0', 0, -1)]
        [InlineData("", '\0', 0, -1)]
        [InlineData("\0", '\0', 0, 0)]
        public void LastIndexOfIgnoreCaseStartIndexTest(string inputValue, char charToFind, int startIndex, int expectedIndex)
        {
            int indexFound = inputValue.LastIndexOfIgnoreCase(charToFind, startIndex);
            Assert.Equal(expectedIndex, indexFound);
            Assert.Equal(expectedIndex, inputValue.ToUpper().LastIndexOf(char.ToUpper(charToFind), startIndex));
        }

        [Theory]
        [InlineData("Seattle", 'E', 1, 2, 1)]
        [InlineData("SeattleZ", 'Z', 7, 1, 7)]
        [InlineData("SeattleZ", 'z', 7, 1, 7)]
        [InlineData("SeattleZ", 'Z', 7, 8, 7)]
        [InlineData("SeattleZ", 'z', 7, 8, 7)]
        [InlineData("SeattleZ", 'Z', 6, 7, -1)]
        [InlineData("SeattleZ", 'z', 6, 7, -1)]
        [InlineData("SeattleZ", 'Z', 0, 1, -1)]
        [InlineData("SeattleZ", 'z', 0, 1, -1)]
        [InlineData("Seattle", 'S', 0, 1, 0)]
        [InlineData("Seattle", 's', 0, 1, 0)]
        [InlineData("SeatTle", 'S', 1, 2, 0)]
        [InlineData("Seattle", 's', 1, 2, 0)]
        [InlineData("SeatTle", 'L', 1, 1, -1)]
        [InlineData("Seattle", 'l', 1, 1, -1)]
        [InlineData("SeatTle", 'T', 6, 3, 4)]
        [InlineData("SeatTle", 't', 6, 3, 4)]
        [InlineData("SeatTle", 'T', 6, 4, 4)]
        [InlineData("SeatTle", 't', 6, 4, 4)]
        [InlineData("SeatTle", 'T', 4, 1, 4)]
        [InlineData("SeatTle", 't', 4, 1, 4)]
        [InlineData("SeatTle", 'T', 3, 1, 3)]
        [InlineData("SeatTle", 't', 3, 1, 3)]
        [InlineData("Seattle", 'Y', 6, 7, -1)]
        [InlineData("Seattle", 'y', 6, 7, -1)]
        [InlineData("Seattle ", ' ', 7, 8, 7)]
        [InlineData(" Seattle", ' ', 7, 8, 0)]
        [InlineData("Seattle", '\0', 0, 1, -1)]
        [InlineData("\0", 'q', 0, 1, -1)]
        [InlineData(" ", ' ', 0, 1, 0)]
        [InlineData(" ", '\0', 0, 1, -1)]
        [InlineData("", '\0', 0, 0, -1)]
        [InlineData("\0", '\0', 0, 1, 0)]
        public void LastIndexOfIgnoreCaseStartIndexAndCountTest(string inputValue, char charToFind, int startIndex, int count, int expectedIndex)
        {
            int indexFound = inputValue.LastIndexOfIgnoreCase(charToFind, startIndex, count);
            Assert.Equal(expectedIndex, indexFound);
            Assert.Equal(expectedIndex, inputValue.ToUpper().LastIndexOf(char.ToUpper(charToFind), startIndex, count));
        }

        [Theory]
        [InlineData(null, "Seattle", typeof(ArgumentNullException), "Value cannot be null. (Parameter 'source')")]
        [InlineData(null, "\0", typeof(ArgumentNullException), "Value cannot be null. (Parameter 'source')")]
        [InlineData(null, null, typeof(ArgumentNullException), "Value cannot be null. (Parameter 'source')")]
        public void LastIndexOfIgnoreCaseStringExceptionTest(string inputValue, string strToFind, Type expectedExceptionType, string expectedErrorMessage)
        {
            Exception thrownException = Assert.Throws(expectedExceptionType, () => inputValue.LastIndexOfIgnoreCase(strToFind));
            Assert.NotNull(thrownException);
            Assert.Equal(expectedErrorMessage, thrownException.Message);
        }

        [Theory]
        [InlineData(null, "Seattle", 3, typeof(ArgumentNullException), "Value cannot be null. (Parameter 'source')")]
        [InlineData(null, "\0", 0, typeof(ArgumentNullException), "Value cannot be null. (Parameter 'source')")]
        [InlineData(null, null, 0, typeof(ArgumentNullException), "Value cannot be null. (Parameter 'source')")]
        [InlineData("Seattle", null, 3, typeof(ArgumentNullException), "Value cannot be null. (Parameter 'value')")]
        [InlineData("\0", null, 0, typeof(ArgumentNullException), "Value cannot be null. (Parameter 'value')")]
        [InlineData("", null, 0, typeof(ArgumentNullException), "Value cannot be null. (Parameter 'value')")]
        [InlineData("Seattle", "sea", -1, typeof(ArgumentOutOfRangeException), "Index was out of range. Must be non-negative and less than the size of the collection. (Parameter 'startIndex')")]
        [InlineData("Seattle", "le", 8, typeof(ArgumentOutOfRangeException), "Index was out of range. Must be non-negative and less than the size of the collection. (Parameter 'startIndex')")]
        public void LastIndexOfIgnoreCaseStringStartIndexExceptionTest(string inputValue, string strToFind, int startIndex, Type expectedExceptionType, string expectedErrorMessage)
        {
            Exception thrownException = Assert.Throws(expectedExceptionType, () => inputValue.LastIndexOfIgnoreCase(strToFind, startIndex));
            Assert.NotNull(thrownException);
            Assert.Equal(expectedErrorMessage, thrownException.Message);
        }

        [Theory]
        [InlineData(null, "Seattle", 0, 3, typeof(ArgumentNullException), "Value cannot be null. (Parameter 'source')")]
        [InlineData(null, "\0", 0, 1, typeof(ArgumentNullException), "Value cannot be null. (Parameter 'source')")]
        [InlineData(null, null, 0, 0, typeof(ArgumentNullException), "Value cannot be null. (Parameter 'source')")]
        [InlineData("Seattle", null, 0, 3, typeof(ArgumentNullException), "Value cannot be null. (Parameter 'value')")]
        [InlineData("\0", null, 0, 1, typeof(ArgumentNullException), "Value cannot be null. (Parameter 'value')")]
        [InlineData("", null, 0, 0, typeof(ArgumentNullException), "Value cannot be null. (Parameter 'value')")]
        [InlineData("Seattle", "sea", -1, 0, typeof(ArgumentOutOfRangeException), "Index was out of range. Must be non-negative and less than the size of the collection. (Parameter 'startIndex')")]
        [InlineData("Seattle", "le", 8, 0, typeof(ArgumentOutOfRangeException), "Index was out of range. Must be non-negative and less than the size of the collection. (Parameter 'startIndex')")]
        [InlineData("Seattle", "sea", 0, 20, typeof(ArgumentOutOfRangeException), "Count must be positive and count must refer to a location within the string/array/collection. (Parameter 'count')")]
        [InlineData("Seattle", "le", 3, -1, typeof(ArgumentOutOfRangeException), "Count must be positive and count must refer to a location within the string/array/collection. (Parameter 'count')")]
        public void LastIndexOfIgnoreCaseStringStartIndexAndCountExceptionTest(string inputValue, string strToFind, int startIndex, int count, Type expectedExceptionType, string expectedErrorMessage)
        {
            Exception thrownException = Assert.Throws(expectedExceptionType, () => inputValue.LastIndexOfIgnoreCase(strToFind, startIndex, count));
            Assert.NotNull(thrownException);
            Assert.Equal(expectedErrorMessage, thrownException.Message);
        }

        [Theory]
        [InlineData(null, 'c', typeof(ArgumentNullException), "Value cannot be null. (Parameter 'source')")]
        [InlineData(null, '\0', typeof(ArgumentNullException), "Value cannot be null. (Parameter 'source')")]
        public void LastIndexOfIgnoreCaseCharExceptionTest(string inputValue, char charToFind, Type expectedExceptionType, string expectedErrorMessage)
        {
            Exception thrownException = Assert.Throws(expectedExceptionType, () => inputValue.LastIndexOfIgnoreCase(charToFind));
            Assert.NotNull(thrownException);
            Assert.Equal(expectedErrorMessage, thrownException.Message);
        }

        [Theory]
        [InlineData(null, 'c', 0, typeof(ArgumentNullException), "Value cannot be null. (Parameter 'source')")]
        [InlineData(null, '\0', 0, typeof(ArgumentNullException), "Value cannot be null. (Parameter 'source')")]
        [InlineData("Seattle", 'a', -1, typeof(ArgumentOutOfRangeException), "Index was out of range. Must be non-negative and less than the size of the collection. (Parameter 'startIndex')")]
        [InlineData("Seattle", 'a', 8, typeof(ArgumentOutOfRangeException), "Index was out of range. Must be non-negative and less than the size of the collection. (Parameter 'startIndex')")]
        public void LastIndexOfIgnoreCaseCharStartIndexExceptionTest(string inputValue, char charToFind, int startIndex, Type expectedExceptionType, string expectedErrorMessage)
        {
            Exception thrownException = Assert.Throws(expectedExceptionType, () => inputValue.LastIndexOfIgnoreCase(charToFind, startIndex));
            Assert.NotNull(thrownException);
            Assert.Equal(expectedErrorMessage, thrownException.Message);
        }

        [Theory]
        [InlineData(null, 'c', 0, 0, typeof(ArgumentNullException), "Value cannot be null. (Parameter 'source')")]
        [InlineData(null, '\0', 0, 0, typeof(ArgumentNullException), "Value cannot be null. (Parameter 'source')")]
        [InlineData("Seattle", 'a', -1, 0, typeof(ArgumentOutOfRangeException), "Index was out of range. Must be non-negative and less than the size of the collection. (Parameter 'startIndex')")]
        [InlineData("Seattle", 'a', 8, 0, typeof(ArgumentOutOfRangeException), "Index was out of range. Must be non-negative and less than the size of the collection. (Parameter 'startIndex')")]
        [InlineData("Seattle", 'a', 0, -1, typeof(ArgumentOutOfRangeException), "Count must be positive and count must refer to a location within the string/array/collection. (Parameter 'count')")]
        [InlineData("Seattle", 'a', 3, 20, typeof(ArgumentOutOfRangeException), "Count must be positive and count must refer to a location within the string/array/collection. (Parameter 'count')")]
        public void LastIndexOfIgnoreCaseCharStartIndexAndCountExceptionTest(string inputValue, char charToFind, int startIndex, int count, Type expectedExceptionType, string expectedErrorMessage)
        {
            Exception thrownException = Assert.Throws(expectedExceptionType, () => inputValue.LastIndexOfIgnoreCase(charToFind, startIndex, count));
            Assert.NotNull(thrownException);
            Assert.Equal(expectedErrorMessage, thrownException.Message);
        }
    }
}
