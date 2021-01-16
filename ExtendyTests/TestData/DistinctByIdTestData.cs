using System.Collections;
using System.Collections.Generic;

namespace ExtendyTests.TestData
{
    public class DistinctByIdTestData : IEnumerable<object[]>
    {
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        public IEnumerator<object[]> GetEnumerator()
        {
            TestObject uniqueIdNum1 = new TestObject(1, "Value");
            TestObject uniqueIdNum2 = new TestObject(2, "Value");
            TestObject uniqueIdNum3 = new TestObject(3, "Value");

            TestObject uniqueValue1 = new TestObject(1, "Value1");
            TestObject uniqueValue2 = new TestObject(1, "Value2");
            TestObject uniqueValue3 = new TestObject(1, "Value3");

            TestObject uniqueCombo1 = new TestObject(1, "Value1");
            TestObject uniqueCombo2 = new TestObject(2, "Value2");
            TestObject uniqueCombo3 = new TestObject(3, "Value3");


            yield return new object[] {
                new object[]
                {
                    uniqueValue1, // 1-Value1
                    uniqueIdNum1, // 1-Value
                    uniqueIdNum2, // 2-Value
                    uniqueCombo3, // 3-Value3
                    uniqueValue3, // 1-Value3
                    uniqueIdNum3, // 3-Value
                    uniqueValue2, // 1-Value2
                    uniqueCombo1, // 1-Value1
                    uniqueCombo2, // 2-Value2
                },
                new object[]
                {
                    uniqueValue1, // 1-Value1
                    uniqueIdNum2, // 2-Value
                    uniqueCombo3, // 3-Value3
                }
            };

            yield return new object[] {
                new object[]
                {
                    uniqueIdNum1, // 1-Value
                    uniqueIdNum2, // 2-Value
                    uniqueIdNum3, // 3-Value
                    uniqueValue1, // 1-Value1
                    uniqueValue2, // 1-Value2
                    uniqueValue3, // 1-Value3
                    uniqueCombo1, // 1-Value1
                    uniqueCombo2, // 2-Value2
                    uniqueCombo3, // 3-Value3
                },
                new object[]
                {
                    uniqueIdNum1, // 1-Value
                    uniqueIdNum2, // 2-Value
                    uniqueIdNum3, // 3-Value
                }
            };

            yield return new object[] {
                new object[]
                {
                    null,
                    uniqueValue1, // 1-Value1
                    uniqueIdNum2, // 2-Value
                    null,
                    uniqueValue1, // 1-Value1
                    uniqueValue2, // 1-Value2
                    uniqueValue3, // 1-Value3
                    uniqueCombo3, // 3-Value3
                    uniqueValue3, // 1-Value3
                },
                new object[]
                {
                    null,
                    uniqueValue1, // 1-Value1
                    uniqueIdNum2, // 2-Value
                    uniqueCombo3, // 3-Value3
                }
            };

            yield return new object[] {
                new object[]
                {
                    null,
                    null,
                    null,
                    null,
                    null
                },
                new object[]
                {
                    null
                }
            };

            yield return new object[] {
                new object[]
                {
                    uniqueIdNum2, // 2-Value
                    uniqueIdNum2, // 2-Value
                    null,
                    uniqueIdNum3, // 3-Value
                    null
                },
                new object[]
                {
                    uniqueIdNum2, // 2-Value
                    null,
                    uniqueIdNum3, // 3-Value
                }
            };

            yield return new object[] {
                new object[]
                {
                    uniqueIdNum2, // 2-Value
                    uniqueIdNum3, // 3-Value
                    uniqueIdNum3, // 3-Value
                    uniqueIdNum3, // 3-Value
                    null,
                    uniqueIdNum3, // 3-Value
                },
                new object[]
                {
                    uniqueIdNum2, // 2-Value
                    uniqueIdNum3, // 3-Value
                    null
                }
            };
        }
    }
}
