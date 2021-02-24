using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Extendy.Collections;
using ExtendyTests.TestData;
using Xunit;

namespace ExtendyTests.Collections
{
    public class CreateManyTests
    {
        [Fact (DisplayName = "CreateMany - integers")]
        public void CreateManyIntegersTest()
        {
            IEnumerable<int> intResult = new List<int>().CreateMany(5);
            Assert.Equal(5, intResult.Count());
            Assert.Equal(new List<int> { 0, 0, 0, 0, 0 }, intResult);
        }

        [Fact(DisplayName = "CreateMany - objects")]
        public void CreateManyObjectsTest()
        {
            List<TestObject> objectResult = new List<TestObject>().CreateMany(3).ToList();
            Assert.Equal(3, objectResult.Count);
            Assert.NotSame(objectResult[0], objectResult[2]);
            Assert.True(objectResult.All(o => o.Id == 0 && o.Value == null));
            objectResult[0].Id = -50;
            objectResult[2].Id = 100;
            Assert.NotEqual(objectResult[0], objectResult[2]);
        }

        [Fact(DisplayName = "CreateMany - structs")]
        public void CreateManyStructsTest()
        {
            IEnumerable<TestStruct> structSet = new HashSet<TestStruct>().CreateMany(3).ToHashSet();
            Assert.Single(structSet);
            Assert.Equal(0, structSet.First().Id);
            Assert.Equal('\0', structSet.First().CharValue);
            Assert.Equal(0, structSet.First().DecimalValue);
        }

        [Fact(DisplayName = "CreateMany - decimals")]
        public void CreateManyDecimalsTest()
        {
            List<decimal> decimalList = new List<decimal> { -5m, 10m, 15m };
            decimalList = decimalList.CreateMany(5).ToList();
            Assert.Equal(-5m, decimalList[0]);
            Assert.Equal(10m, decimalList[1]);
            Assert.Equal(15m, decimalList[2]);
            Assert.True(decimalList.Skip(3).All(d => d == 0m));
        }

        [Fact]
        public void CreateManyArgumentNullExceptionTest()
        {
            IEnumerable<int> originalCollection = null;

            Exception thrownException = Assert.Throws<ArgumentNullException>(() => originalCollection.CreateMany(5));
            Assert.NotNull(thrownException);
            Assert.Equal("Value cannot be null. (Parameter 'source')", thrownException.Message);
        }

        [Fact]
        public void CreateManyArgumentOutOfRangeExceptionTest()
        {
            IEnumerable<int> originalCollection = originalCollection = new List<int>();

            Exception thrownException = Assert.Throws<ArgumentOutOfRangeException>(() => originalCollection.CreateMany(-1));
            Assert.NotNull(thrownException);
            Assert.Equal("Specified argument was out of the range of valid values. (Parameter 'count')", thrownException.Message);
        }
    }
}
