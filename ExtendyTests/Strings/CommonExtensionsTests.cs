using Xunit;
using Extendy.Strings.Common;
using System;

namespace Extendy.Tests.Strings.Common
{
    public class CommonExtensionsTests
    {
        [Theory]
        [InlineData("Same", "Same", true)]
        [InlineData("Different", "different", true)]
        [InlineData("SNOWMAN", "snowman", true)]
        [InlineData("Start", "starT", true)]
        [InlineData("enD", "END", true)]
        [InlineData("Seattle", "seattle", true)]
        [InlineData("", "", true)]
        [InlineData("spacesh1p", "spaceship", false)]
        [InlineData("", null, false)]
        [InlineData("null", null, false)]
        public void EqualsIgnoreCaseTest(string input1, string input2, bool expectedResult)
        {
            bool isEqual = input1.EqualsIgnoreCase(input2);
            Assert.Equal(expectedResult, isEqual);
        }

        [Theory]
        [InlineData(null, null, typeof(ArgumentNullException), "Value cannot be null. (Parameter 'source')")]
        [InlineData(null, "val", typeof(ArgumentNullException), "Value cannot be null. (Parameter 'source')")]
        public void DistinctByExceptionTest(string input1, string input2, Type expectedExceptionType, string expectedErrorMessage)
        {
            Exception thrownException = Assert.Throws(expectedExceptionType, () => input1.EqualsIgnoreCase(input2));
            Assert.NotNull(thrownException);
            Assert.Equal(expectedErrorMessage, thrownException.Message);
        }

        [Theory]
        [InlineData("Same", "Same", true)]
        [InlineData("Different", "different", true)]
        [InlineData("Portland", "port", true)]
        [InlineData("portLAND", "lAnD", true)]
        [InlineData("   Begins and ends with spaces   ", "and", true)]
        [InlineData("Spaceship", "", true)]
        [InlineData("", "", true)]
        [InlineData("Spaceship ", "Spaceship", true)]
        [InlineData("spaceship", "spaceshiP", true)]
        [InlineData("The dog is good.", ".", true)]
        [InlineData("The dog is good.", "T", true)]
        [InlineData("spacesh1p", "spaceship", false)]
        public void ContainsIgnoreCaseTest(string input1, string input2, bool expectedResult)
        {
            bool doesContain = input1.ContainsIgnoreCase(input2);
            Assert.Equal(expectedResult, doesContain);
        }

        [Theory]
        [InlineData(null, null, typeof(ArgumentNullException), "Value cannot be null. (Parameter 'source')")]
        [InlineData(null, "val", typeof(ArgumentNullException), "Value cannot be null. (Parameter 'source')")]
        [InlineData("val", null, typeof(ArgumentNullException), "Value cannot be null. (Parameter 'value')")]
        public void ContainsIgnoreCaseTestNullArguments(string input1, string input2, Type expectedExceptionType, string expectedErrorMessage)
        {
            Exception thrownException = Assert.Throws(expectedExceptionType, () => input1.ContainsIgnoreCase(input2));
            Assert.NotNull(thrownException);
            Assert.Equal(expectedErrorMessage, thrownException.Message);
        }

        [Theory]
        [InlineData("Same", "Same", true)]
        [InlineData("Different", "different", true)]
        [InlineData("Starts with this", "stArT", true)]
        [InlineData("Pumpkins", "p", true)]
        [InlineData("Evergreen", "", true)]
        [InlineData("", "", true)]
        [InlineData("spacesh1p", "spaceship", false)]
        [InlineData("Pumpkins", "s", false)]
        [InlineData("Has an EnD", "END", false)]
        [InlineData(" space", "  ", false)]
        public void StartsWithIgnoreCaseTest(string input1, string input2, bool expectedResult)
        {
            bool doesStartWith = input1.StartsWithIgnoreCase(input2);
            Assert.Equal(expectedResult, doesStartWith);
        }

        [Theory]
        [InlineData(null, null, typeof(ArgumentNullException), "Value cannot be null. (Parameter 'source')")]
        [InlineData(null, "val", typeof(ArgumentNullException), "Value cannot be null. (Parameter 'source')")]
        [InlineData("val", null, typeof(ArgumentNullException), "Value cannot be null. (Parameter 'value')")]
        public void StartsWithIgnoreCaseTestNullArguments(string input1, string input2, Type expectedExceptionType, string expectedErrorMessage)
        {
            Exception thrownException = Assert.Throws(expectedExceptionType, () => input1.StartsWithIgnoreCase(input2));
            Assert.NotNull(thrownException);
            Assert.Equal(expectedErrorMessage, thrownException.Message);
        }

        [Theory]
        [InlineData("Same", "Same", true)]
        [InlineData("Different", "different", true)]
        [InlineData("Has an EnD", "END", true)]
        [InlineData("Pumpkins", "s", true)]
        [InlineData("Evergreen", "", true)]
        [InlineData("   ", " ", true)]
        [InlineData("", "", true)]
        [InlineData("spacesh1p", "spaceship", false)]
        [InlineData("Pumpkins", "P", false)]
        [InlineData("Starts with this", "stArT", false)]
        [InlineData(" space", "  ", false)]
        public void EndsWithIgnoreCaseTest(string input1, string input2, bool expectedResult)
        {
            bool doesEndWith = input1.EndsWithIgnoreCase(input2);
            Assert.Equal(expectedResult, doesEndWith);
        }

        [Theory]
        [InlineData(null, null, typeof(ArgumentNullException), "Value cannot be null. (Parameter 'source')")]
        [InlineData(null, "val", typeof(ArgumentNullException), "Value cannot be null. (Parameter 'source')")]
        [InlineData("val", null, typeof(ArgumentNullException), "Value cannot be null. (Parameter 'value')")]
        public void EndsWithIgnoreCaseTestNullArguments(string input1, string input2, Type expectedExceptionType, string expectedErrorMessage)
        {
            Exception thrownException = Assert.Throws(expectedExceptionType, () => input1.EndsWithIgnoreCase(input2));
            Assert.NotNull(thrownException);
            Assert.Equal(expectedErrorMessage, thrownException.Message);
        }
    }
}