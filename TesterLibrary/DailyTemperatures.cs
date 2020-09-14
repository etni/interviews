using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace TesterLibrary
{
    public class DailyTemperaturesSolution
    {
        [Fact]
        public void Solve()
        {
            int[] input = { 73, 74, 75, 71, 69, 72, 76, 73 };
            int[] expected = { 1, 1, 4, 2, 1, 1, 0, 0 };
            var result = DailyTemperatures(input);

            Assert.Equal(expected, result);



        }

        public int[] DailyTemperatures(int[] T)
        {
            int[] result = new int[T.Length];

            for (var i = T.Length - 1; i >= 0; i--)
            {
                result[i] = HowLongToHigher(T, i);

            }
            return result;
        }

        public int HowLongToHigher(int[] T, int index)
        {
            var count = 0;

            var curTemp = T[index];
            var found = false;

            for (var i = index; (i + 1) < T.Length; i++)
            {
                count++;
                if (curTemp < T[i + 1])
                {
                    found = true;
                    break;
                }
            }

            return found ? count : 0;

        }
    }
}
