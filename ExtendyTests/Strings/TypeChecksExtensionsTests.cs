using System;
using Extendy.Strings.TypeChecks;
using Xunit;

namespace Extendy.Tests.Strings.TypeChecks
{
    public class TypeChecksExtensionsTests
    {
        [Theory]
        [InlineData("12345", true)]
        [InlineData("2147483649", true)]
        [InlineData("9876543210", true)]
        [InlineData("50,000", false)]
        [InlineData("2,147,483,647", false)]
        [InlineData("-2147483649", false)]
        [InlineData("+1024", false)]
        [InlineData("-1024", false)]
        [InlineData("99,150.23", false)]
        [InlineData("1024.16", false)]
        [InlineData("1024+", false)]
        [InlineData("1024-", false)]
        [InlineData("+1024+", false)]
        [InlineData("-1024-", false)]
        [InlineData("$100.25", false)]
        [InlineData("5,0000", false)]
        [InlineData("seven", false)]
        [InlineData("\0", false)]
        [InlineData(" ", false)]
        [InlineData("", false)]
        public void IsNumericTest(string inputValue, bool expectedResult)
        {
            bool isInteger = inputValue.IsNumeric();
            Assert.Equal(expectedResult, isInteger);
        }

        [Theory]
        [InlineData(null, typeof(ArgumentNullException), "Value cannot be null. (Parameter 'source')")]
        public void IsNumericExceptionTest(string inputValue, Type expectedExceptionType, string expectedErrorMessage)
        {
            Exception thrownException = Assert.Throws(expectedExceptionType, () => inputValue.IsNumeric());
            Assert.NotNull(thrownException);
            Assert.Equal(expectedErrorMessage, thrownException.Message);
        }

        [Theory]
        [InlineData("Spaceshuttle", true)]
        [InlineData("seven", true)]
        [InlineData("seventy7", false)]
        [InlineData("Spaces do not count", false)]
        [InlineData("AlsoNotPuncuation!", false)]
        [InlineData("12345", false)]
        [InlineData("50,000", false)]
        [InlineData("99,150.23", false)]
        [InlineData("1024.16", false)]
        [InlineData("$100.25", false)]
        [InlineData("\0", false)]
        [InlineData(" ", false)]
        [InlineData("", false)]
        public void IsAlphabeticTest(string inputValue, bool expectedResult)
        {
            bool isAlphabetic = inputValue.IsAlphabetic();
            Assert.Equal(expectedResult, isAlphabetic);
        }

        [Theory]
        [InlineData(null, typeof(ArgumentNullException), "Value cannot be null. (Parameter 'source')")]
        public void IsAlphabeticExceptionTest(string inputValue, Type expectedExceptionType, string expectedErrorMessage)
        {
            Exception thrownException = Assert.Throws(expectedExceptionType, () => inputValue.IsAlphabetic());
            Assert.NotNull(thrownException);
            Assert.Equal(expectedErrorMessage, thrownException.Message);
        }

        [Theory]
        [InlineData("12345", true)]
        [InlineData("2147483649", true)]
        [InlineData("9876543210", true)]
        [InlineData("seven", true)]
        [InlineData("seventy7", true)]
        [InlineData("50,000", false)]
        [InlineData("2,147,483,647", false)]
        [InlineData("-2147483649", false)]
        [InlineData("+1024", false)]
        [InlineData("-1024", false)]
        [InlineData("99,150.23", false)]
        [InlineData("1024.16", false)]
        [InlineData("1024+", false)]
        [InlineData("1024-", false)]
        [InlineData("+1024+", false)]
        [InlineData("-1024-", false)]
        [InlineData("$100.25", false)]
        [InlineData("5,0000", false)]
        [InlineData("Spaces do not count", false)]
        [InlineData("AlsoNotPuncuation!", false)]
        [InlineData("\0", false)]
        [InlineData(" ", false)]
        [InlineData("", false)]
        public void IsAlphaNumericTest(string inputValue, bool expectedResult)
        {
            bool isAlphaNumeric = inputValue.IsAlphaNumeric();
            Assert.Equal(expectedResult, isAlphaNumeric);
        }

        [Theory]
        [InlineData(null, typeof(ArgumentNullException), "Value cannot be null. (Parameter 'source')")]
        public void IsAlphaNumericExceptionTest(string inputValue, Type expectedExceptionType, string expectedErrorMessage)
        {
            Exception thrownException = Assert.Throws(expectedExceptionType, () => inputValue.IsAlphaNumeric());
            Assert.NotNull(thrownException);
            Assert.Equal(expectedErrorMessage, thrownException.Message);
        }

        [Theory]
        [InlineData("UPPER", true)]
        [InlineData("LOw", false)]
        [InlineData("Lower", false)]
        [InlineData("evenlower", false)]
        [InlineData("SPACES ARE NOT ALLOWED", false)]
        [InlineData("PUNCTUATIONSTOPSITTOO!", false)]
        [InlineData("12345", false)]
        [InlineData("50,000", false)]
        [InlineData("99,150.23", false)]
        [InlineData("1024.16", false)]
        [InlineData("$100.25", false)]
        [InlineData("\0", false)]
        [InlineData(" ", false)]
        [InlineData("", false)]
        public void IsUpperTest(string inputValue, bool expectedResult)
        {
            bool isUpper = inputValue.IsUpper();
            Assert.Equal(expectedResult, isUpper);
        }

        [Theory]
        [InlineData(null, typeof(ArgumentNullException), "Value cannot be null. (Parameter 'source')")]
        public void IsUpperExceptionTest(string inputValue, Type expectedExceptionType, string expectedErrorMessage)
        {
            Exception thrownException = Assert.Throws(expectedExceptionType, () => inputValue.IsUpper());
            Assert.NotNull(thrownException);
            Assert.Equal(expectedErrorMessage, thrownException.Message);
        }

        [Theory]
        [InlineData("lower", true)]
        [InlineData("High", false)]
        [InlineData("HIGHEr", false)]
        [InlineData("HIGHEST", false)]
        [InlineData("spaces are not allowed", false)]
        [InlineData("puncuationstopsittoo!", false)]
        [InlineData("12345", false)]
        [InlineData("50,000", false)]
        [InlineData("99,150.23", false)]
        [InlineData("1024.16", false)]
        [InlineData("$100.25", false)]
        [InlineData("\0", false)]
        [InlineData(" ", false)]
        [InlineData("", false)]
        public void IsLowerTest(string inputValue, bool expectedResult)
        {
            bool isLower = inputValue.IsLower();
            Assert.Equal(expectedResult, isLower);
        }

        [Theory]
        [InlineData(null, typeof(ArgumentNullException), "Value cannot be null. (Parameter 'source')")]
        public void IsLowerExceptionTest(string inputValue, Type expectedExceptionType, string expectedErrorMessage)
        {
            Exception thrownException = Assert.Throws(expectedExceptionType, () => inputValue.IsLower());
            Assert.NotNull(thrownException);
            Assert.Equal(expectedErrorMessage, thrownException.Message);
        }
    }
}