using System;
using System.Collections.Generic;
using System.Text;
using Extendy.Misc;
using Xunit;

namespace ExtendyTests.Misc
{
    public class RandomExtensionsTests
    {
        [Fact(DisplayName = "NextBool")]
        public void NextBoolTest()
        {
            // Manually specifying a seed guarantees the Random object generates the same data
            Random generator = new Random(100);

            Assert.False(generator.NextBool());
            Assert.True(generator.NextBool());
            Assert.False(generator.NextBool());
            Assert.False(generator.NextBool());
            Assert.True(generator.NextBool());
            Assert.False(generator.NextBool());
            Assert.False(generator.NextBool());
            Assert.False(generator.NextBool());
            Assert.True(generator.NextBool());
            Assert.True(generator.NextBool());
        }

        [Fact(DisplayName = "NextBool - with probability")]
        public void NextBoolProbabilityTest()
        {
            // Manually specifying a seed guarantees the Random object generates the same data
            Random generator = new Random(100);

            // Check for high probability of a true value
            for (int i=0; i<100; i++)
                Assert.True(generator.NextBool(99.99));

            // Check for low probability of a true value
            for (int i=0; i<100; i++)
                Assert.False(generator.NextBool(0.01));

            // Check for medium probability of a true value
            Assert.False(generator.NextBool());
            Assert.True(generator.NextBool());
            Assert.True(generator.NextBool());
            Assert.False(generator.NextBool());
            Assert.True(generator.NextBool());
            Assert.True(generator.NextBool());
            Assert.False(generator.NextBool());
            Assert.True(generator.NextBool());
            Assert.True(generator.NextBool());
            Assert.False(generator.NextBool());
        }
    }
}
