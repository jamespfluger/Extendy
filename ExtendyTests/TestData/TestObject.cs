using System;

namespace ExtendyTests.TestData
{
    public class TestObject
    {
        public int Id { get; set; }
        public string Value { get; set; }

        public TestObject(int id)
        {
            this.Id = id;
            this.Value = Guid.NewGuid().ToString();
        }

        public TestObject(int id, string value)
        {
            this.Id = id;
            this.Value = value;
        }
    }
}
