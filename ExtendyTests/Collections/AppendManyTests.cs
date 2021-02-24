using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Extendy.Collections;
using ExtendyTests.TestData;
using Xunit;

namespace ExtendyTests.Collections
{
    public class AppendManyTests
    {
        [Fact (DisplayName = "AppendMany - strings]")]
        public void StringsTest()
        {
            List<string> stringResult = new List<string>().AppendMany("a", 5).ToList();
            Assert.Equal(5, stringResult.Count());
            Assert.Equal(new List<string> { "a", "a", "a", "a", "a" }, stringResult);
            Assert.Same(stringResult[0], stringResult[4]);
            stringResult[0] = "b";
            Assert.Equal(new List<string> { "b", "a", "a", "a", "a" }, stringResult);
            Assert.NotSame(stringResult[0], stringResult[4]);
        }

        [Fact (DisplayName = "AppendMany - ints]")]
        public void IntegersTest()
        {
            IEnumerable<int> intResult = new List<int>().AppendMany(0, 5);
            Assert.Equal(5, intResult.Count());
            Assert.Equal(new List<int> { 0, 0, 0, 0, 0 }, intResult);
        }

        [Fact (DisplayName = "AppendMany - objects]")]
        public void ObjectsTest()
        {
            TestObject inputTestObject = new TestObject();
            List<TestObject> objectResult = new List<TestObject>().AppendMany(inputTestObject, 2).ToList();

            Assert.Equal(2, objectResult.Count);
            Assert.Equal(inputTestObject, objectResult[0]);
            Assert.Equal(inputTestObject, objectResult[1]);
            Assert.Equal(objectResult[0], objectResult[1]);
            Assert.Same(inputTestObject, objectResult[0]);
            Assert.Same(inputTestObject, objectResult[1]);
            Assert.Same(objectResult[0], objectResult[1]);

            objectResult[0].Id = 123;

            Assert.Equal(inputTestObject, objectResult[0]);
            Assert.Equal(inputTestObject, objectResult[1]);
            Assert.Equal(objectResult[0], objectResult[1]);
            Assert.Same(inputTestObject, objectResult[0]);
            Assert.Same(inputTestObject, objectResult[1]);
            Assert.Same(objectResult[0], objectResult[1]);
        }

        [Fact (DisplayName = "AppendMany - structs]")]
        public void StructsTest()
        {
            TestStruct inputTestStruct = new TestStruct();
            inputTestStruct.Id = 5;
            inputTestStruct.DecimalValue = 15;

            List<TestStruct> structResult = new List<TestStruct>().AppendMany(inputTestStruct, 3).ToList();

            Assert.Equal(3, structResult.Count);
            Assert.Equal(inputTestStruct, structResult[0]);
            Assert.Equal(inputTestStruct, structResult[1]);
            Assert.Equal(inputTestStruct, structResult[2]);
        }

        [Fact]
        public void AppendManyNullTest()
        {
            List<string> originalCollection = new List<string>();

            originalCollection = originalCollection.AppendMany(null, 3).ToList();
            Assert.Null(originalCollection[0]);
            Assert.Null(originalCollection[1]);
            Assert.Null(originalCollection[2]);
        }

        [Fact]
        public void AppendManyArgumentNullExceptionTest()
        {
            IEnumerable<int> originalCollection = null;

            Exception thrownException = Assert.Throws<ArgumentNullException>(() => originalCollection.AppendMany(0, 5));
            Assert.NotNull(thrownException);
            Assert.Equal("Value cannot be null. (Parameter 'source')", thrownException.Message);
        }

        [Fact]
        public void AppendManyArgumentOutOfRangeExceptionTest()
        {
            IEnumerable<int> originalCollection = originalCollection = new List<int>();

            Exception thrownException = Assert.Throws<ArgumentOutOfRangeException>(() => originalCollection.AppendMany(5, -1));
            Assert.NotNull(thrownException);
            Assert.Equal("Specified argument was out of the range of valid values. (Parameter 'count')", thrownException.Message);
        }
    }
}
