using Xunit;
using Extendy.Enums;
using System;
using System.Collections.Generic;
using System.Text;
using ExtendyTests.TestData;

namespace Extendy.Enums.Tests
{
    public class EnumExtensionsTests
    {
        public enum TestEnum
        {
            Local,
            Dev,
            QA,
            Sandbox,
            Production
        }

        [Theory]
        [InlineData("Local", TestEnum.Local)]
        [InlineData("Dev", TestEnum.Dev)]
        [InlineData("QA", TestEnum.QA)]
        [InlineData("Sandbox", TestEnum.Sandbox)]
        [InlineData("Production", TestEnum.Production)]
        public void ToEnumTest(string inputEnumStr, TestEnum expectedEnum)
        {
            Assert.Equal(expectedEnum, inputEnumStr.ToEnum<TestEnum>());
        }

        [Theory]
        [InlineData(null, typeof(ArgumentNullException), "Value cannot be null. (Parameter 'source')")]
        [InlineData("localhost", typeof(ArgumentException), "Requested value 'localhost' was not found.")]
        public void ToEnumExceptionTest(string inputEnumStr, Type expectedExceptionType, string expectedErrorMessage)
        {
            Exception thrownException = Assert.Throws(expectedExceptionType, () => inputEnumStr.ToEnum<TestEnum>());
            Assert.NotNull(thrownException);
            Assert.Equal(expectedErrorMessage, thrownException.Message);
        }

        [Theory]
        [InlineData("Local", TestEnum.Local)]
        [InlineData("Dev", TestEnum.Dev)]
        [InlineData("QA", TestEnum.QA)]
        [InlineData("Sandbox", TestEnum.Sandbox)]
        [InlineData("Production", TestEnum.Production)]
        [InlineData("loCal", TestEnum.Local)]
        [InlineData("dEv", TestEnum.Dev)]
        [InlineData("qa", TestEnum.QA)]
        [InlineData("SandBox", TestEnum.Sandbox)]
        [InlineData("ProdUction", TestEnum.Production)]
        public void ToEnumIgnoreCaseTest(string inputEnumStr, TestEnum expectedEnum)
        {
            Assert.Equal(expectedEnum, inputEnumStr.ToEnum<TestEnum>(true));
        }

        [Theory]
        [InlineData(null, typeof(ArgumentNullException), "Value cannot be null. (Parameter 'source')")]
        [InlineData("localhost", typeof(ArgumentException), "Requested value 'localhost' was not found.")]
        public void ToEnumIgnoreCaseExceptionTest(string inputEnumStr, Type expectedExceptionType, string expectedErrorMessage)
        {
            Exception thrownException = Assert.Throws(expectedExceptionType, () => inputEnumStr.ToEnum<TestEnum>(true));
            Assert.NotNull(thrownException);
            Assert.Equal(expectedErrorMessage, thrownException.Message);
        }
    }
}