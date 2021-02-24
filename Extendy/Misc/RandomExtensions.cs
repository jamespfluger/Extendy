using System;
using System.Collections.Generic;
using System.Text;

namespace Extendy.Misc
{
    public static class RandomExtensions
    {
        /// <summary>
        /// Returns a random boolean.
        /// </summary>
        /// <returns>A random boolean value.</returns>
        public static bool NextBool(this Random source)
        {
            return source.Next(2) == 0;
        }

        /// <summary>
        /// Returns a random boolean weighted on the probability of the boolean being true.
        /// </summary>
        /// <param name="percentage">The probability as a percentage between 0->100 of a random boolean being true.</param>
        /// <returns>Either true or false, based on the probability provided.</returns>
        public static bool NextBool(this Random source, double percentage)
        {
            return source.NextDouble() < percentage / 100.0;
        }
    }
}
