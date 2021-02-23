using System;
using System.Collections.Generic;
using System.Text;

namespace ExtendyTests.TestData
{
    public struct TestStruct
    {
        public int Id { get; set; }
        public decimal DecimalValue { get; set; }
        public char CharValue { get; set; }

        public TestStruct(int id, decimal decimalValue, char charValue)
        {
            this.Id = id;
            this.DecimalValue = decimalValue;
            this.CharValue = charValue;
        }
    }
}
