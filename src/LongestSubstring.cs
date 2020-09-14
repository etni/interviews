using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace InterviewQuestions
{
    public class LongestSubstring
    {
        /* Find the Longest Substring 
         * of distinct characters 
         * 
         * */

        public long Solution(string input)
        {

            var array = input.ToCharArray();
            long result = 0;

            for (var i = 0; i < array.Length; i++)
            {
                var visited = new Dictionary<char, bool>();

                for (var j = i; j < array.Length; j++)
                {
                    if (visited.ContainsKey(array[j]))
                        break;

                    else
                    {
                        result = Math.Max(result, j - i + 1);
                        visited.Add(array[j], true);
                    }
                }
            }
            return result;
        }

        [Theory]
        [InlineData("ndNf", "nndNfdfdf")]
        [InlineData("abcdefg", "abcdefg")]
        [InlineData("bcadefg", "abcadefg")]
        [InlineData("babcA", "ababcAabd")]
        public void ShouldReturnLengthOfLongestSubstring(string expected, string input)
        {
            var result = Solution(input);
            Assert.Equal(expected.Length, result);
        }



    }
}
