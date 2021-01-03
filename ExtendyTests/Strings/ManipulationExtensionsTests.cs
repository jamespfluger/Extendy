using Xunit;
using Extendy.Strings.Manipulation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Extendy.Tests.Strings.Manipulation
{
    public class ManipulationExtensionsTests
    {
        [Theory]
        [InlineData("Seattle", 0, "")]
        [InlineData("Seattle", 1, "S")]
        [InlineData("Seattle", 2, "Se")]
        [InlineData("Seattle", 3, "Sea")]
        [InlineData("Seattle", 4, "Seat")]
        [InlineData("Seattle", 5, "Seatt")]
        [InlineData("Seattle", 6, "Seattl")]
        [InlineData("Seattle", 7, "Seattle")]
        [InlineData("", 0, "")]
        [InlineData("\0", 0, "")]
        [InlineData("\0a", 1, "\0")]
        [InlineData("a\0", 1, "a")]
        public void LeftTest(string input, int length, string expectedResult)
        {
            string leftValue = input.Left(length);
            Assert.Equal(expectedResult, leftValue);
        }

        [Theory]
        [InlineData(null, 3, typeof(ArgumentNullException), "Value cannot be null. (Parameter 'source')")]
        [InlineData("Seattle", -1, typeof(ArgumentOutOfRangeException), "length cannot be less than zero. (Parameter 'length')")]
        [InlineData("Seattle", 8, typeof(ArgumentOutOfRangeException), "length cannot be larger than length of string. (Parameter 'length')")]
        public void LeftExceptionTest(string input, int length, Type expectedExceptionType, string expectedErrorMessage)
        {
            Exception thrownException = Assert.Throws(expectedExceptionType, () => input.Left(length));
            Assert.NotNull(thrownException);
            Assert.Equal(expectedErrorMessage, thrownException.Message);
        }

        [Theory]
        [InlineData("Seattle", 0, "")]
        [InlineData("Seattle", 1, "e")]
        [InlineData("Seattle", 2, "le")]
        [InlineData("Seattle", 3, "tle")]
        [InlineData("Seattle", 4, "ttle")]
        [InlineData("Seattle", 5, "attle")]
        [InlineData("Seattle", 6, "eattle")]
        [InlineData("Seattle", 7, "Seattle")]
        [InlineData("", 0, "")]
        [InlineData("\0", 0, "")]
        [InlineData("\0a", 1, "a")]
        [InlineData("a\0", 1, "\0")]
        public void RightTest(string input, int length, string expectedResult)
        {
            string rightValue = input.Right(length);
            Assert.Equal(expectedResult, rightValue);
        }

        [Theory]
        [InlineData(null, 3, typeof(ArgumentNullException), "Value cannot be null. (Parameter 'source')")]
        [InlineData("Seattle", -1, typeof(ArgumentOutOfRangeException), "length cannot be less than zero. (Parameter 'length')")]
        [InlineData("Seattle", 8, typeof(ArgumentOutOfRangeException), "length cannot be larger than length of string. (Parameter 'length')")]
        public void RightExceptionTest(string input, int length, Type expectedExceptionType, string expectedErrorMessage)
        {
            Exception thrownException = Assert.Throws(expectedExceptionType, () => input.Right(length));
            Assert.NotNull(thrownException);
            Assert.Equal(expectedErrorMessage, thrownException.Message);
        }

        [Theory]
        [InlineData("Seattle", "elttaeS")]
        [InlineData("", "")]
        [InlineData(" ", " ")]
        [InlineData("\0", "\0")]
        [InlineData("\0a", "a\0")]
        [InlineData("a\0", "\0a")]
        [InlineData("Les Mise\u0301rables", "selbare\u0301siM seL")]
        public void ReverseTest(string inputToReverse, string expectedReversedValue)
        {
            string reversedString = inputToReverse.Reverse();
            Assert.Equal(expectedReversedValue, reversedString);
        }

        [Theory]
        [InlineData(null, typeof(ArgumentNullException), "Value cannot be null. (Parameter 'source')")]
        public void ReverseExceptionTest(string input, Type expectedExceptionType, string expectedErrorMessage)
        {
            Exception thrownException = Assert.Throws(expectedExceptionType, () => input.Reverse());
            Assert.NotNull(thrownException);
            Assert.Equal(expectedErrorMessage, thrownException.Message);
        }

        [Theory]
        [InlineData("Seattles", 'S', "eattle")]
        [InlineData("seattleS", 's', "eattle")]
        [InlineData("SeattleS", 'S', "eattle")]
        [InlineData("seattles", 's', "eattle")]
        [InlineData("Seattles", 's', "eattle")]
        [InlineData("seattle", 'S', "eattle")]
        [InlineData("SeattlE", 'E', "Seattl")]
        [InlineData("Seattle", 'E', "Seattl")]
        [InlineData("SeattlE", 'e', "Seattl")]
        [InlineData("Seattle", 'e', "Seattl")]
        [InlineData("Rrrainr", 'r', "ain")]
        [InlineData("rRrainR", 'r', "ain")]
        [InlineData("rrainRrRrrr", 'r', "ain")]
        [InlineData("Raaan", 'a', "Raaan")]
        [InlineData("Moooo", 'O', "M")]
        [InlineData("Moooo", 'o', "M")]
        [InlineData("Moooo", 'M', "oooo")]
        [InlineData("Moooo", 'm', "oooo")]
        [InlineData("At", 'A', "t")]
        [InlineData("At", 'a', "t")]
        [InlineData("At", 'T', "A")]
        [InlineData("At", 't', "A")]
        [InlineData("J", 'J', "")]
        [InlineData("J", 'j', "")]
        [InlineData("MMMMMMMMM", 'm', "")]
        [InlineData("   EXTENDY  ", ' ', "EXTENDY")]
        [InlineData("", 'E', "")]
        [InlineData("EXTENDY", 'e', "XTENDY")]
        [InlineData("\0EXTENDY\0", '\0', "EXTENDY")]
        public void TrimIgnoreCaseTest(string inputToTrim, char trimChar, string expectedResult)
        {
            string trimmedValue = inputToTrim.TrimIgnoreCase(trimChar);
            Assert.Equal(expectedResult, trimmedValue);
        }

        [Theory]
        [InlineData("Seattles", 'S', "eattles")]
        [InlineData("seattleS", 's', "eattleS")]
        [InlineData("SeattleS", 'S', "eattleS")]
        [InlineData("seattles", 's', "eattles")]
        [InlineData("Seattles", 's', "eattles")]
        [InlineData("seattle", 'S', "eattle")]
        [InlineData("SeattlE", 'E', "SeattlE")]
        [InlineData("Seattle", 'E', "Seattle")]
        [InlineData("SeattlE", 'e', "SeattlE")]
        [InlineData("Seattle", 'e', "Seattle")]
        [InlineData("Rrrainr", 'r', "ainr")]
        [InlineData("rRrainR", 'r', "ainR")]
        [InlineData("rrainRrRrrr", 'r', "ainRrRrrr")]
        [InlineData("Raaan", 'a', "Raaan")]
        [InlineData("Moooo", 'O', "Moooo")]
        [InlineData("Moooo", 'o', "Moooo")]
        [InlineData("Moooo", 'M', "oooo")]
        [InlineData("Moooo", 'm', "oooo")]
        [InlineData("At", 'A', "t")]
        [InlineData("At", 'a', "t")]
        [InlineData("At", 'T', "At")]
        [InlineData("At", 't', "At")]
        [InlineData("J", 'J', "")]
        [InlineData("J", 'j', "")]
        [InlineData("MMMMMMMMM", 'm', "")]
        [InlineData("   EXTENDY  ", ' ', "EXTENDY  ")]
        [InlineData("", 'E', "")]
        [InlineData("EXTENDY", 'e', "XTENDY")]
        [InlineData("\0EXTENDY\0", '\0', "EXTENDY\0")]
        public void TrimStartIgnoreCaseTest(string inputToTrim, char trimChar, string expectedResult)
        {
            string trimmedValue = inputToTrim.TrimStartIgnoreCase(trimChar);
            Assert.Equal(expectedResult, trimmedValue);
        }

        [Theory]
        [InlineData("Seattles", 'S', "Seattle")]
        [InlineData("seattleS", 's', "seattle")]
        [InlineData("SeattleS", 'S', "Seattle")]
        [InlineData("seattles", 's', "seattle")]
        [InlineData("Seattles", 's', "Seattle")]
        [InlineData("seattle", 'S', "seattle")]
        [InlineData("SeattlE", 'E', "Seattl")]
        [InlineData("Seattle", 'E', "Seattl")]
        [InlineData("SeattlE", 'e', "Seattl")]
        [InlineData("Seattle", 'e', "Seattl")]
        [InlineData("Rrrainr", 'r', "Rrrain")]
        [InlineData("rRrainR", 'r', "rRrain")]
        [InlineData("rrainRrRrrr", 'r', "rrain")]
        [InlineData("Raaan", 'a', "Raaan")]
        [InlineData("Moooo", 'O', "M")]
        [InlineData("Moooo", 'o', "M")]
        [InlineData("Moooo", 'M', "Moooo")]
        [InlineData("Moooo", 'm', "Moooo")]
        [InlineData("At", 'A', "At")]
        [InlineData("At", 'a', "At")]
        [InlineData("At", 'T', "A")]
        [InlineData("At", 't', "A")]
        [InlineData("J", 'J', "")]
        [InlineData("J", 'j', "")]
        [InlineData("MMMMMMMMM", 'm', "")]
        [InlineData("   EXTENDY  ", ' ', "   EXTENDY")]
        [InlineData("", 'E', "")]
        [InlineData("EXTENDY", 'e', "EXTENDY")]
        [InlineData("\0EXTENDY\0", '\0', "\0EXTENDY")]
        public void TrimEndIgnoreCaseTest(string inputToTrim, char trimChar, string expectedResult)
        {
            string trimmedValue = inputToTrim.TrimEndIgnoreCase(trimChar);
            Assert.Equal(expectedResult, trimmedValue);
        }

        [Theory]
        [InlineData("SeattleS", new char[] { 'S' }, "eattle")]
        [InlineData("SeattleS", new char[] { 's' }, "eattle")]
        [InlineData("Seattles", new char[] { 'E' }, "Seattles")]
        [InlineData("Seattles", new char[] { 'e' }, "Seattles")]
        [InlineData("Seattles", new char[] { 'S', 'e' }, "attl")]
        [InlineData("Seattles", new char[] { 's', 'E' }, "attl")]
        [InlineData("SesattlSeEs", new char[] { 'S', 'e' }, "attl")]
        [InlineData("SesattlSeEs", new char[] { 's', 'E' }, "attl")]
        [InlineData("SeattlE", new char[] { 'S', 's', }, "eattlE")]
        [InlineData("Seattle", new char[] { 'S', 's', 'S', 's', 'S' }, "eattle")]
        [InlineData("ZzzooooMmiEs", new char[] { 'z', 'M', 'I', 'e', 'O', 'S' }, "")]
        [InlineData("ZzzooooMmiEs", new char[] { 'z', 'M', 'I', 'e', 'S' }, "oooo")]
        [InlineData("ZzzooooMmiEs", new char[] { 'M', 'I', 'e', 'S' }, "Zzzoooo")]
        [InlineData("ZzzooooMmiEs", new char[] { 'z' }, "ooooMmiEs")]
        [InlineData("Rrrainr", new char[] { 'R' }, "ain")]
        [InlineData("rRrainR", new char[] { 'r' }, "ain")]
        [InlineData("rrainRrRrrr", new char[] { 'a', 'i', 'n' }, "rrainRrRrrr")]
        [InlineData("Raaan", new char[] { 'a' }, "Raaan")]
        [InlineData("Moooo", new char[] { 'M' }, "oooo")]
        [InlineData("Moooo", new char[] { 'm' }, "oooo")]
        [InlineData("Moooo", new char[] { 'O' }, "M")]
        [InlineData("Moooo", new char[] { 'o' }, "M")]
        [InlineData("Moooo", new char[] { 'M', 'O' }, "")]
        [InlineData("Moooo", new char[] { 'm', 'o' }, "")]
        [InlineData("At", new char[] { 'A' }, "t")]
        [InlineData("At", new char[] { 'a' }, "t")]
        [InlineData("At", new char[] { 'T' }, "A")]
        [InlineData("At", new char[] { 't' }, "A")]
        [InlineData("At", new char[] { 'A', 'T' }, "")]
        [InlineData("At", new char[] { 'a', 't' }, "")]
        [InlineData("J", new char[] { 'J' }, "")]
        [InlineData("J", new char[] { 'j' }, "")]
        [InlineData("MMMMMMMMM", new char[] { 'm' }, "")]
        [InlineData("   EXTENDY  ", new char[] { ' ' }, "EXTENDY")]
        [InlineData("", new char[] { }, "")]
        [InlineData("", new char[] { ' ' }, "")]
        [InlineData("EXTENDY", new char[] { }, "EXTENDY")]
        [InlineData("C", new char[] { 'a', 'b', 'd', 'e' }, "C")]
        [InlineData("EXTENDY", new char[] { 'Y', 'd', 'N', 'e', 'T', 'x', }, "")]
        [InlineData("\0EXTENDY\0", new char[] { '\0' }, "EXTENDY")]
        [InlineData("\0EXTENDY\0", new char[] { }, "\0EXTENDY\0")]
        public void TrimIgnoreCaseCharArrayTest(string inputToTrim, char[] trimChars, string expectedResult)
        {
            string trimmedValue = inputToTrim.TrimIgnoreCase(trimChars);
            Assert.Equal(expectedResult, trimmedValue);
        }

        [Theory]
        [InlineData("SeattleS", new char[] { 'S' }, "eattleS")]
        [InlineData("SeattleS", new char[] { 's' }, "eattleS")]
        [InlineData("Seattles", new char[] { 'E' }, "Seattles")]
        [InlineData("Seattles", new char[] { 'e' }, "Seattles")]
        [InlineData("Seattles", new char[] { 'S', 'e' }, "attles")]
        [InlineData("Seattles", new char[] { 's', 'E' }, "attles")]
        [InlineData("SesattlSeEs", new char[] { 'S', 'e' }, "attlSeEs")]
        [InlineData("SesattlSeEs", new char[] { 's', 'E' }, "attlSeEs")]
        [InlineData("SeattlE", new char[] { 'S', 's', }, "eattlE")]
        [InlineData("Seattle", new char[] { 'S', 's', 'S', 's', 'S' }, "eattle")]
        [InlineData("ZzzooooMmiEs", new char[] { 'z', 'M', 'I', 'e', 'O', 'S' }, "")]
        [InlineData("ZzzooooMmiEs", new char[] { 'z', 'M', 'I', 'e', 'S' }, "ooooMmiEs")]
        [InlineData("ZzzooooMmiEs", new char[] { 'M', 'I', 'e', 'S' }, "ZzzooooMmiEs")]
        [InlineData("ZzzooooMmiEs", new char[] { 'z' }, "ooooMmiEs")]
        [InlineData("Rrrainr", new char[] { 'R' }, "ainr")]
        [InlineData("rRrainR", new char[] { 'r' }, "ainR")]
        [InlineData("rrainRrRrrr", new char[] { 'a', 'i', 'n' }, "rrainRrRrrr")]
        [InlineData("Raaan", new char[] { 'a' }, "Raaan")]
        [InlineData("Moooo", new char[] { 'M' }, "oooo")]
        [InlineData("Moooo", new char[] { 'm' }, "oooo")]
        [InlineData("Moooo", new char[] { 'O' }, "Moooo")]
        [InlineData("Moooo", new char[] { 'o' }, "Moooo")]
        [InlineData("Moooo", new char[] { 'M', 'O' }, "")]
        [InlineData("Moooo", new char[] { 'm', 'o' }, "")]
        [InlineData("At", new char[] { 'A' }, "t")]
        [InlineData("At", new char[] { 'a' }, "t")]
        [InlineData("At", new char[] { 'T' }, "At")]
        [InlineData("At", new char[] { 't' }, "At")]
        [InlineData("At", new char[] { 'A', 'T' }, "")]
        [InlineData("At", new char[] { 'a', 't' }, "")]
        [InlineData("J", new char[] { 'J' }, "")]
        [InlineData("J", new char[] { 'j' }, "")]
        [InlineData("MMMMMMMMM", new char[] { 'm' }, "")]
        [InlineData("   EXTENDY  ", new char[] { ' ' }, "EXTENDY  ")]
        [InlineData("", new char[] { }, "")]
        [InlineData("", new char[] { ' ' }, "")]
        [InlineData("EXTENDY", new char[] { }, "EXTENDY")]
        [InlineData("C", new char[] { 'a', 'b', 'd', 'e' }, "C")]
        [InlineData("EEXTENdDY", new char[] { 'Y', 'N', 'T', 'e', 'd', 'x', }, "")]
        [InlineData("\0EXTENDY\0", new char[] { '\0' }, "EXTENDY\0")]
        [InlineData("\0EXTENDY\0", new char[] { }, "\0EXTENDY\0")]
        public void TrimStartIgnoreCaseCharArrayTest(string inputToTrim, char[] trimChars, string expectedResult)
        {
            string trimmedValue = inputToTrim.TrimStartIgnoreCase(trimChars);
            Assert.Equal(expectedResult, trimmedValue);
        }


        [Theory]
        [InlineData("SeattleS", new char[] { 'S' }, "Seattle")]
        [InlineData("SeattleS", new char[] { 's' }, "Seattle")]
        [InlineData("Seattles", new char[] { 'E' }, "Seattles")]
        [InlineData("Seattles", new char[] { 'e' }, "Seattles")]
        [InlineData("Seattles", new char[] { 'S', 'e' }, "Seattl")]
        [InlineData("Seattles", new char[] { 's', 'E' }, "Seattl")]
        [InlineData("SesattlSeEs", new char[] { 'S', 'e' }, "Sesattl")]
        [InlineData("SesattlSeEs", new char[] { 's', 'E' }, "Sesattl")]
        [InlineData("SeattlE", new char[] { 'S', 's', }, "SeattlE")]
        [InlineData("Seattle", new char[] { 'S', 's', 'S', 's', 'S' }, "Seattle")]
        [InlineData("ZzzooooMmiEs", new char[] { 'z', 'M', 'I', 'e', 'O', 'S' }, "")]
        [InlineData("ZzzooooMmiEs", new char[] { 'z', 'M', 'I', 'e', 'S' }, "Zzzoooo")]
        [InlineData("ZzzooooMmiEs", new char[] { 'M', 'I', 'e', 'S' }, "Zzzoooo")]
        [InlineData("ZzzooooMmiEs", new char[] { 'z' }, "ZzzooooMmiEs")]
        [InlineData("Rrrainr", new char[] { 'R' }, "Rrrain")]
        [InlineData("rRrainR", new char[] { 'r' }, "rRrain")]
        [InlineData("rrainRrRrrr", new char[] { 'a', 'i', 'n' }, "rrainRrRrrr")]
        [InlineData("Raaan", new char[] { 'a' }, "Raaan")]
        [InlineData("Moooo", new char[] { 'M' }, "Moooo")]
        [InlineData("Moooo", new char[] { 'm' }, "Moooo")]
        [InlineData("Moooo", new char[] { 'O' }, "M")]
        [InlineData("Moooo", new char[] { 'o' }, "M")]
        [InlineData("Moooo", new char[] { 'M', 'O' }, "")]
        [InlineData("Moooo", new char[] { 'm', 'o' }, "")]
        [InlineData("At", new char[] { 'A' }, "At")]
        [InlineData("At", new char[] { 'a' }, "At")]
        [InlineData("At", new char[] { 'T' }, "A")]
        [InlineData("At", new char[] { 't' }, "A")]
        [InlineData("At", new char[] { 'A', 'T' }, "")]
        [InlineData("At", new char[] { 'a', 't' }, "")]
        [InlineData("J", new char[] { 'J' }, "")]
        [InlineData("J", new char[] { 'j' }, "")]
        [InlineData("MMMMMMMMM", new char[] { 'm' }, "")]
        [InlineData("   EXTENDY  ", new char[] { ' ' }, "   EXTENDY")]
        [InlineData("", new char[] { }, "")]
        [InlineData("", new char[] { ' ' }, "")]
        [InlineData("EXTENDY", new char[] { }, "EXTENDY")]
        [InlineData("C", new char[] { 'a', 'b', 'd', 'e' }, "C")]
        [InlineData("EXTENDY", new char[] { 'Y', 'd', 'N', 'e', 'T', 'x', }, "")]
        [InlineData("\0EXTENDY\0", new char[] { '\0' }, "\0EXTENDY")]
        [InlineData("\0EXTENDY\0", new char[] { }, "\0EXTENDY\0")]
        public void TrimEndIgnoreCaseCharArrayTest(string inputToTrim, char[] trimChars, string expectedResult)
        {
            string trimmedValue = inputToTrim.TrimEndIgnoreCase(trimChars);
            Assert.Equal(expectedResult, trimmedValue);
        }

        [Theory]
        [InlineData(null, 'a', typeof(ArgumentNullException), "Value cannot be null. (Parameter 'source')")]
        public void TrimIgnoreCaseExceptionTest(string input, char trimChar, Type expectedExceptionType, string expectedErrorMessage)
        {
            Exception thrownException = Assert.Throws(expectedExceptionType, () => input.TrimIgnoreCase(trimChar));
            Assert.NotNull(thrownException);
            Assert.Equal(expectedErrorMessage, thrownException.Message);
        }

        [Theory]
        [InlineData(null, 'a', typeof(ArgumentNullException), "Value cannot be null. (Parameter 'source')")]
        public void TrimStartIgnoreCaseExceptionTest(string input, char trimChar, Type expectedExceptionType, string expectedErrorMessage)
        {
            Exception thrownException = Assert.Throws(expectedExceptionType, () => input.TrimStartIgnoreCase(trimChar));
            Assert.NotNull(thrownException);
            Assert.Equal(expectedErrorMessage, thrownException.Message);
        }

        [Theory]
        [InlineData(null, 'a', typeof(ArgumentNullException), "Value cannot be null. (Parameter 'source')")]
        public void TrimEndIgnoreCaseExceptionTest(string input, char trimChar, Type expectedExceptionType, string expectedErrorMessage)
        {
            Exception thrownException = Assert.Throws(expectedExceptionType, () => input.TrimEndIgnoreCase(trimChar));
            Assert.NotNull(thrownException);
            Assert.Equal(expectedErrorMessage, thrownException.Message);
        }

        [Theory]
        [InlineData(null, new char[] { 'a' }, typeof(ArgumentNullException), "Value cannot be null. (Parameter 'source')")]
        [InlineData("input", null, typeof(ArgumentNullException), "Value cannot be null. (Parameter 'trimChars')")]
        [InlineData("input", null, typeof(ArgumentNullException), "Value cannot be null. (Parameter 'trimChars')")]
        public void TrimIgnoreCaseCharArrayExceptionTest(string input, char[] trimChars, Type expectedExceptionType, string expectedErrorMessage)
        {
            Exception thrownException = Assert.Throws(expectedExceptionType, () => input.TrimIgnoreCase(trimChars));
            Assert.NotNull(thrownException);
            Assert.Equal(expectedErrorMessage, thrownException.Message);
        }

        [Theory]
        [InlineData(null, new char[] { 'a' }, typeof(ArgumentNullException), "Value cannot be null. (Parameter 'source')")]
        [InlineData("input", null, typeof(ArgumentNullException), "Value cannot be null. (Parameter 'trimChars')")]
        public void TrimStartIgnoreCaseCharArrayExceptionTest(string input, char[] trimChars, Type expectedExceptionType, string expectedErrorMessage)
        {
            Exception thrownException = Assert.Throws(expectedExceptionType, () => input.TrimStartIgnoreCase(trimChars));
            Assert.NotNull(thrownException);
            Assert.Equal(expectedErrorMessage, thrownException.Message);
        }

        [Theory]
        [InlineData(null, new char[] { 'a' }, typeof(ArgumentNullException), "Value cannot be null. (Parameter 'source')")]
        [InlineData("input", null, typeof(ArgumentNullException), "Value cannot be null. (Parameter 'trimChars')")]
        public void TrimEndIgnoreCaseCharArrayExceptionTest(string input, char[] trimChars, Type expectedExceptionType, string expectedErrorMessage)
        {
            Exception thrownException = Assert.Throws(expectedExceptionType, () => input.TrimEndIgnoreCase(trimChars));
            Assert.NotNull(thrownException);
            Assert.Equal(expectedErrorMessage, thrownException.Message);
        }

        [Theory]
        [InlineData("ZoOm", "o", "a", "Zaam")]
        [InlineData("ZoOm", "oo", "yy", "Zyym")]
        [InlineData("AAAAA", "A", "b", "bbbbb")]
        [InlineData("aaaaa", "a", "b", "bbbbb")]
        [InlineData("AAAAA", "a", "B", "BBBBB")]
        [InlineData("aaaaa", "A", "B", "BBBBB")]
        [InlineData("a", "A", "B", "B")]
        [InlineData("", "o", "a", "")]
        [InlineData("", "R", "t", "")]
        [InlineData("SearRle", "R", "t", "Seattle")]
        [InlineData("SeaRrle", "r", "t", "Seattle")]
        [InlineData("Seattle", "tT", "Tt", "SeaTtle")]
        [InlineData("sleattlea", "lea", "", "stt")]
        [InlineData("Ocean", "o", "Go", "Gocean")]
        [InlineData("OceaN", "n", "Ns", "OceaNs")]
        [InlineData("Turtle", "t", "P", "PurPle")]
        [InlineData("", "Sea", "Ocean", "")]
        public void ReplaceStringTest(string inputValue, string strToReplace, string strToReplaceWith, string expectedResult)
        {
            string replacedValue = inputValue.ReplaceIgnoreCase(strToReplace, strToReplaceWith);
            Assert.Equal(expectedResult, replacedValue);
        }

        [Theory]
        [InlineData("ZoOm", 'o', 'a', "Zaam")]
        [InlineData("ZOom", 'o', 'Y', "ZYYm")]
        [InlineData("AAAAA", 'A', 'b', "bbbbb")]
        [InlineData("aaaaa", 'a', 'b', "bbbbb")]
        [InlineData("AAAAA", 'a', 'B', "BBBBB")]
        [InlineData("aaaaa", 'A', 'B', "BBBBB")]
        [InlineData("a", 'A', 'B', "B")]
        [InlineData("", 'o', 'a', "")]
        [InlineData("", 'R', 't', "")]
        [InlineData("SearRle", 'R', 't', "Seattle")]
        [InlineData("SeaRrle", 'r', 't', "Seattle")]
        [InlineData("SeaTtle", 'T', 't', "Seattle")]
        [InlineData("sleattlea", 'L', '\0', "s\0eatt\0ea")]
        [InlineData("SEa En FirE", 'E', 'e', "Sea en Fire")]
        [InlineData("OceaM", 'm', 'n', "Ocean")]
        [InlineData("Turtle", 't', 'P', "PurPle")]
        public void ReplaceCharTest(string inputValue, char charToReplace, char charToReplaceWith, string expectedResult)
        {
            string replacedValue = inputValue.ReplaceIgnoreCase(charToReplace, charToReplaceWith);
            Assert.Equal(expectedResult, replacedValue);
        }

        [Theory]
        [InlineData(null, "a", "z", typeof(ArgumentNullException), "Value cannot be null. (Parameter 'source')")]
        [InlineData("input", null, "z", typeof(ArgumentNullException), "Value cannot be null. (Parameter 'oldValue')")]
        [InlineData("input", "", "z", typeof(ArgumentException), "String cannot be of zero length.")]
        public void ReplaceIgnoreCaseStringTest(string inputValue, string strToReplace, string strToReplaceWith, Type expectedExceptionType, string expectedErrorMessage)
        {
            Exception thrownException = Assert.Throws(expectedExceptionType, () => inputValue.ReplaceIgnoreCase(strToReplace, strToReplaceWith));
            Assert.NotNull(thrownException);
            Assert.Equal(expectedErrorMessage, thrownException.Message);
        }

        [Theory]
        [InlineData(null, 'a', 'z', typeof(ArgumentNullException), "Value cannot be null. (Parameter 'source')")]
        public void ReplaceIgnoreCaseCharTest(string inputValue, char charToReplace, char charToReplaceWith, Type expectedExceptionType, string expectedErrorMessage)
        {
            Exception thrownException = Assert.Throws(expectedExceptionType, () => inputValue.ReplaceIgnoreCase(charToReplace, charToReplaceWith));
            Assert.NotNull(thrownException);
            Assert.Equal(expectedErrorMessage, thrownException.Message);
        }
    }
}
