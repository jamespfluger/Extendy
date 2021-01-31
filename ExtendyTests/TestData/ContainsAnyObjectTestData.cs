using System.Collections;
using System.Collections.Generic;

namespace ExtendyTests.TestData
{
    public class ContainsAnyObjectTestData : IEnumerable<object[]>
    {
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        public IEnumerator<object[]> GetEnumerator()
        {
            TestObject obj1 = new TestObject(1);
            TestObject obj2 = new TestObject(1);
            TestObject obj3 = new TestObject(3, "Data");
            TestObject obj4 = new TestObject(4, "Data");
            TestObject obj5 = new TestObject(5, "Data");
            TestObject obj6 = new TestObject(5, "Data");
            TestObject obj7 = new TestObject(5, "Data");

            yield return new object[] { true, new object[] { obj1 }, new object[] { obj1, obj3, obj4 } };
            yield return new object[] { true, new object[] { obj1 }, new object[] { obj1, obj2 } };
            yield return new object[] { false, new object[] { obj1 }, new object[] { obj2, obj3, obj4 } };
            yield return new object[] { true, new object[] { obj5 }, new object[] { obj6, obj7, obj5 } };
            yield return new object[] { false, new object[] { obj5 }, new object[] { obj6, obj7 } };
            yield return new object[] { true, new object[] { obj1, obj3 }, new object[] { obj1, obj4 } };
            yield return new object[] { true, new object[] { obj1 }, new object[] { obj1, obj2 } };
            yield return new object[] { false, new object[] { obj1, obj2 }, new object[] { obj3 } };
            yield return new object[] { false, new object[] { obj1 }, new object[] { obj2, obj3, obj4 } };
            yield return new object[] { false, new object[] { obj5 }, new object[] { obj3, obj4 } };
            yield return new object[] { true, new object[] { obj5, obj6, obj7, obj2, obj1, obj3 }, new object[] { obj3, obj4 } };

            yield return new object[] { false, new object[] { new TestObject(1) }, new object[] { obj1, obj2, obj3, obj4, obj5, obj6, obj7 } };
            yield return new object[] { false, new object[] { new TestObject(1, "Data") }, new object[] { obj1, obj2, obj3, obj4, obj5, obj6, obj7 } };
            yield return new object[] { false, new object[] { new TestObject(1, "Data") }, new object[] { new TestObject(1, "Data") } };
            yield return new object[] { false, new object[] { new TestObject(1, "Data") }, new object[] { new TestObject(1, "Data"), new TestObject(1, "Data") } };
            yield return new object[] { false, new object[] { new TestObject(1, "Data"), new TestObject(1, "Data") }, new object[] { new TestObject(1, "Data") } };
            yield return new object[] { false, new object[] { new TestObject(5, "Data"), new TestObject(1, "Data") }, new object[] { new TestObject(5, "Data"), obj5, obj6, obj7 } };
            yield return new object[] { false, new object[] { new TestObject(5, "Data"), new TestObject(5, "Data"), obj5, obj6, obj7 }, new object[] { null, new TestObject(5, "Data") } };
            yield return new object[] { true, new object[] { new TestObject(5, "Data"), new TestObject(5, "Data"), obj5, obj6, null }, new object[] { null, new TestObject(5, "Data") } };
            yield return new object[] { false, new object[] { new TestObject(5, "Data"), new TestObject(5, "Data"), obj5, obj6, obj7 }, new object[] { null, null, null } };
            yield return new object[] { false, new object[] { obj1 }, new object[] { null } };
            yield return new object[] { false, new object[] { null }, new object[] { obj1 } };
            yield return new object[] { true, new object[] { new TestObject(5, "Data"), null }, new object[] { null, null, null } };
            yield return new object[] { true, new object[] { null }, new object[] { null, null, null } };
            yield return new object[] { true, new object[] { null }, new object[] { null } };
            yield return new object[] { false, new object[] { null }, new object[] { } };
            yield return new object[] { false, new object[] { }, new object[] { } };
            yield return new object[] { true, new object[] { null, null, null }, new object[] { null, null, null } };
        }
    }
}
