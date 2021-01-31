﻿using System;
using System.Collections.Generic;
using System.Linq;
using ExtendyTests.TestData;
using Xunit;

namespace Extendy.Collections.Tests
{
    public class EnumerableExtensionsTests
    {
        [Theory]
        [InlineData(true, new string[] { "abc" }, new string[] { "abc", "def", "geh" })]
        [InlineData(true, new string[] { "abc" }, new string[] { "abc", "abc", "geh" })]
        [InlineData(true, new string[] { "abc" }, new string[] { "abc", "abc", "abc" })]
        [InlineData(true, new string[] { "def" }, new string[] { "abc", "def", "geh" })]
        [InlineData(true, new string[] { "geh" }, new string[] { "abc", "def", "geh" })]
        [InlineData(true, new string[] { "abc", "def", "geh" }, new string[] { "def", "geh" })]
        [InlineData(true, new string[] { "abc", "def", "geh" }, new string[] { "def" })]
        [InlineData(true, new string[] { "abc", "def", "geh" }, new string[] { "abc", "abc", "geh" })]
        [InlineData(true, new string[] { "abc", "def", "geh" }, new string[] { "abc", "abc", "abc" })]
        [InlineData(false, new string[] { "abc", "def", "geh" }, new string[] { "" })]
        [InlineData(false, new string[] { "" }, new string[] { "abc", "def", "geh" })]
        [InlineData(false, new string[] { "\0" }, new string[] { "abc", "def", "geh" })]
        [InlineData(false, new string[] { null }, new string[] { "abc", "def", "geh" })]
        [InlineData(false, new string[] { "abc", "def", "geh" }, new string[] { null })]
        [InlineData(true, new string[] { null }, new string[] { "abc", null, null })]
        [InlineData(true, new string[] { null, "geh" }, new string[] { "abc", null, "geh" })]
        [InlineData(true, new string[] { "geh", null }, new string[] { "abc", null, "geh" })]
        [InlineData(false, new string[] { }, new string[] { "abc", "def", "geh" })]
        [InlineData(false, new string[] { "abc", "def", "geh" }, new string[] { })]
        [InlineData(false, new string[] { }, new string[] { })]
        public void ContainsAnyWithStringsTest(bool expectedResult, IEnumerable<object> inputCollection, object[] args)
        {
            Assert.True(new string[] { "def" }.ContainsAny("abc", "def", "geh"));
            Assert.Equal(expectedResult, inputCollection.ContainsAny(args));
            Assert.Equal(expectedResult, inputCollection.ToArray().ContainsAny(args));
            Assert.Equal(expectedResult, inputCollection.ToList().ContainsAny(args));
            Assert.Equal(expectedResult, inputCollection.ToHashSet().ContainsAny(args));
        }

        [Theory]
        [InlineData(true, new char[] { 'a' }, new char[] { 'a', 'b', 'c' })]
        [InlineData(true, new char[] { 'a' }, new char[] { 'a', 'a', 'c' })]
        [InlineData(true, new char[] { 'a' }, new char[] { 'a', 'a', 'a' })]
        [InlineData(true, new char[] { 'b' }, new char[] { 'a', 'b', 'c' })]
        [InlineData(true, new char[] { 'c' }, new char[] { 'a', 'b', 'c' })]
        [InlineData(true, new char[] { 'a', 'b', 'c' }, new char[] { 'b', 'c' })]
        [InlineData(true, new char[] { 'a', 'b', 'c' }, new char[] { 'b' })]
        [InlineData(true, new char[] { 'a', 'b', 'c' }, new char[] { 'a', 'a', 'c' })]
        [InlineData(true, new char[] { 'a', 'b', 'c' }, new char[] { 'a', 'a', 'a' })]
        [InlineData(true, new char[] { 'a', 'b', 'c' }, new char[] { 'c' })]
        [InlineData(false, new char[] { ' ' }, new char[] { 'a', 'b', 'c' })]
        [InlineData(false, new char[] { '\0' }, new char[] { 'a', 'b', 'c' })]
        [InlineData(false, new char[] { 'a', 'b', 'c' }, new char[] { '\0' })]
        [InlineData(true, new char[] { '\0' }, new char[] { 'a', '\0', '\0' })]
        [InlineData(true, new char[] { '\0', 'c' }, new char[] { 'a', '\0', 'c' })]
        [InlineData(true, new char[] { 'c', '\0' }, new char[] { 'a', '\0', 'c' })]
        [InlineData(false, new char[] { }, new char[] { 'a', 'b', 'c' })]
        [InlineData(false, new char[] { 'a', 'b', 'c' }, new char[] { })]
        [InlineData(false, new char[] { }, new char[] { })]
        public void ContainsAnyWithCharsTest(bool expectedResult, IEnumerable<char> inputCollection, char[] args)
        {
            Assert.Equal(expectedResult, inputCollection.ContainsAny(args));
            Assert.Equal(expectedResult, inputCollection.ToArray().ContainsAny(args));
            Assert.Equal(expectedResult, inputCollection.ToList().ContainsAny(args));
            Assert.Equal(expectedResult, inputCollection.ToHashSet().ContainsAny(args));
        }

        [Theory]
        [InlineData(true, new int[] { 1 }, new int[] { 1, 2, 3 })]
        [InlineData(true, new int[] { 1 }, new int[] { 1, 1, 3 })]
        [InlineData(true, new int[] { 1 }, new int[] { 1, 1, 1 })]
        [InlineData(true, new int[] { 2 }, new int[] { 1, 2, 3 })]
        [InlineData(true, new int[] { 3 }, new int[] { 1, 2, 3 })]
        [InlineData(true, new int[] { 1, 2, 3 }, new int[] { 2, 3 })]
        [InlineData(true, new int[] { 1, 2, 3 }, new int[] { 2 })]
        [InlineData(true, new int[] { 1, 2, 3 }, new int[] { 1, 1, 3 })]
        [InlineData(true, new int[] { 1, 2, 3 }, new int[] { 1, 1, 1 })]
        [InlineData(false, new int[] { }, new int[] { 1, 2, 3 })]
        [InlineData(false, new int[] { 1, 2, 3 }, new int[] { })]
        [InlineData(false, new int[] { }, new int[] { })]
        public void ContainsAnyWithIntegersTest(bool expectedResult, IEnumerable<int> inputCollection, int[] args)
        {
            Assert.Equal(expectedResult, inputCollection.ContainsAny(args));
            Assert.Equal(expectedResult, inputCollection.ToArray().ContainsAny(args));
            Assert.Equal(expectedResult, inputCollection.ToList().ContainsAny(args));
            Assert.Equal(expectedResult, inputCollection.ToHashSet().ContainsAny(args));
        }

        [Theory]
        [ClassData(typeof(ContainsAnyObjectTestData))]
        public void ContainsAnyWithObjectsTest(bool expectedResult, IEnumerable<object> inputCollection, object[] args)
        {
            Assert.Equal(expectedResult, inputCollection.ContainsAny(args));
            Assert.Equal(expectedResult, inputCollection.ToArray().ContainsAny(args));
            Assert.Equal(expectedResult, inputCollection.ToList().ContainsAny(args));
            Assert.Equal(expectedResult, inputCollection.ToHashSet().ContainsAny(args));
        }

        [Theory]
        [InlineData(null, null, typeof(ArgumentNullException), "Value cannot be null. (Parameter 'source')")]
        [InlineData(null, new object[] { }, typeof(ArgumentNullException), "Value cannot be null. (Parameter 'source')")]
        [InlineData(new object[] { }, null, typeof(ArgumentNullException), "Value cannot be null. (Parameter 'values')")]
        public void ContainsAnyExceptionObjectsTest(IEnumerable<object> inputCollection, object[] args, Type expectedExceptionType, string expectedErrorMessage)
        {
            Exception thrownException = Assert.Throws(expectedExceptionType, () => inputCollection.ContainsAny(args));
            Assert.NotNull(thrownException);
            Assert.Equal(expectedErrorMessage, thrownException.Message);
        }

        [Theory]
        [InlineData(null, null, typeof(ArgumentNullException), "Value cannot be null. (Parameter 'source')")]
        [InlineData(null, new int[] { }, typeof(ArgumentNullException), "Value cannot be null. (Parameter 'source')")]
        [InlineData(new int[] { }, null, typeof(ArgumentNullException), "Value cannot be null. (Parameter 'values')")]
        public void ContainsAnyExceptionIntsTest(IEnumerable<int> inputCollection, int[] args, Type expectedExceptionType, string expectedErrorMessage)
        {
            Exception thrownException = Assert.Throws(expectedExceptionType, () => inputCollection.ContainsAny(args));
            Assert.NotNull(thrownException);
            Assert.Equal(expectedErrorMessage, thrownException.Message);
        }

        [Theory]
        [InlineData(new string[] { "a" }, new string[] { }, new string[] { "a" })]
        [InlineData(new string[] { }, new string[] { "b" }, new string[] { "b" })]
        [InlineData(new string[] { "a" }, new string[] { "b" }, new string[] { "a", "b" })]
        [InlineData(new string[] { "a", "c" }, new string[] { "b", "d" }, new string[] { "a", "c", "b", "d" })]
        [InlineData(new string[] { "a", "b", "c" }, new string[] { "d", "e", "f" }, new string[] { "a", "b", "c", "d", "e", "f" })]
        [InlineData(new string[] { }, new string[] { }, new string[] { })]
        [InlineData(new string[] { }, new string[] { null }, new string[] { null })]
        [InlineData(new string[] { null }, new string[] { }, new string[] { null })]
        [InlineData(new string[] { null, "a" }, new string[] { null }, new string[] { null, "a", null })]
        public void AddRangeTest(ICollection<string> originalArray, string[] listToAppend, string[] expectedArray)
        {
            HashSet<string> newList = originalArray.ToHashSet();
            newList.AddRange(listToAppend);
            Assert.Equal(expectedArray.ToHashSet(), newList);
        }

        [Theory]
        [InlineData(null, null, typeof(ArgumentNullException), "Value cannot be null. (Parameter 'source')")]
        [InlineData(null, new object[] { }, typeof(ArgumentNullException), "Value cannot be null. (Parameter 'source')")]
        [InlineData(new object[] { }, null, typeof(ArgumentNullException), "Value cannot be null. (Parameter 'values')")]
        public void AddRangeExceptionTest(ICollection<object> originalArray, object[] listToAppend, Type expectedExceptionType, string expectedErrorMessage)
        {
            Exception thrownException = Assert.Throws(expectedExceptionType, () => originalArray.AddRange(listToAppend));
            Assert.NotNull(thrownException);
            Assert.Equal(expectedErrorMessage, thrownException.Message);
        }

        [Theory]
        [InlineData(new string[] { "a", "b", "e" }, new string[] { "a", "b", "e" })]
        [InlineData(new string[] { "a", "b", "e", "e" }, new string[] { "a", "b", "e" })]
        [InlineData(new string[] { "a", "a", "b", "e" }, new string[] { "a", "b", "e" })]
        [InlineData(new string[] { null, "a", "b", "e" }, new string[] { null, "a", "b", "e" })]
        [InlineData(new string[] { "a", "b", "e", null }, new string[] { "a", "b", "e", null })]
        [InlineData(new string[] { null, "a", "b", "e", null }, new string[] { null, "a", "b", "e" })]
        [InlineData(new string[] { null, null, null }, new string[] { null })]
        [InlineData(new string[] { null, "\0" }, new string[] { null, "\0" })]
        [InlineData(new string[] { }, new string[] { })]
        public void RemoveDuplicatesTest(ICollection<string> originalArray, string[] expectedArray)
        {
            List<string> newList = originalArray.ToList();
            newList.RemoveDuplicates();
            Assert.Equal(expectedArray, newList);
        }

        [Theory]
        [InlineData(null, typeof(ArgumentNullException), "Value cannot be null. (Parameter 'source')")]
        public void RemoveDuplicatesExceptionTest(ICollection<object> originalArray, Type expectedExceptionType, string expectedErrorMessage)
        {
            Exception thrownException = Assert.Throws(expectedExceptionType, () => originalArray.RemoveDuplicates());
            Assert.NotNull(thrownException);
            Assert.Equal(expectedErrorMessage, thrownException.Message);
        }

        [Theory]
        [ClassData(typeof(DistinctByIdTestData))]
        public void DistinctByIdTest(TestObject[] originalArray, TestObject[] expectedArray)
        {
            List<TestObject> newList = originalArray.DistinctBy(i => i.Id).ToList();
            Assert.Equal(expectedArray.ToList(), newList);
        }

        [Theory]
        [ClassData(typeof(DistinctByValueTestData))]
        public void DistinctByValueTest(TestObject[] originalArray, TestObject[] expectedArray)
        {
            List<TestObject> newList = originalArray.DistinctBy(i => i.Value).ToList();
            Assert.Equal(expectedArray.ToList(), newList);
        }

        [Theory]
        [ClassData(typeof(DistinctByBothIdAndValueTestData))]
        public void DistinctByValueAndIdTest(TestObject[] originalArray, TestObject[] expectedArray)
        {
            List<TestObject> newList = originalArray.DistinctBy(i => new { i.Id, i.Value }).ToList();
            Assert.Equal(expectedArray.ToList(), newList);
        }

        [Theory]
        [InlineData(null, typeof(ArgumentNullException), "Value cannot be null. (Parameter 'source')")]
        public void DistinctByExceptionTest(IEnumerable<TestObject> originalArray, Type expectedExceptionType, string expectedErrorMessage)
        {
            Exception thrownException = Assert.Throws(expectedExceptionType, () => originalArray.DistinctBy(i => new { i.Id, i.Value }).ToList());
            Assert.NotNull(thrownException);
            Assert.Equal(expectedErrorMessage, thrownException.Message);
        }
    }
}
