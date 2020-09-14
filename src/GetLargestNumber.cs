using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace InterviewsJuly2020
{
    public class GetLargestNumber
    {
        /// <summary>
        /// Given an array of numbers, return the biggest number. 
        /// If array is empty return 0
        /// </summary>

 
        public long Solution(long[] numbers)
        {
            return numbers.Length switch
            {
                0 => 0,
                _ => numbers.Max()
            };

        }


        [Fact]
        public void WhenArrayIsEmptyLargestNumberShouldBeZero()
        {
            long[] emptyList = new long[] { };

            var result = Solution(emptyList);
            Assert.Equal(0, result);
        }




        
        [Fact]
        public void Angles()
        {
            var first = "<<>>>>><<<>>";
            var expected = "<<<<<>>>>><<<>>>";

            var result = Solution2(first);

            Assert.Equal(expected, result);


        }

        public static string Solution2(string angles)
        {
            // Type your solution here
            var opening = new Stack<char>();
            var closing = new Stack<char>(); 
            var queue = new StringBuilder();
            var currentTag = "";

            foreach(var c in angles.ToCharArray())
            {
                if (c == '<')
                {
                    opening.Push(c);
                    currentTag = currentTag + c;
                    
                }
                else 
                { 
                    closing.Push(c);
                    currentTag = currentTag + c;
                }
                 
                if (opening.Count < closing.Count)
                {
                    opening.Push('<');
                    currentTag = '<' + currentTag;
                }
                 

                if (closing.Count == opening.Count)
                {
                    queue.Append(currentTag);
                    closing.Clear();
                    opening.Clear();
                }
            }             
            return queue.ToString();


        }

        public static string solution3(string angles)
        {
            var stack = new Stack<char>();
            var queue = new StringBuilder();

            foreach (var c in angles.ToCharArray())
            {
                if (c == '>')
                {
                    if (stack.Count() == 0)
                    {
                        queue.Append('<');
                    }
                    else
                    {
                        stack.Pop();
                    }
                    queue.Append(c);
                }
                else
                {
                    queue.Append(c);
                    stack.Push('>');
                }
            }
            while (stack.Any())
                queue.Append(stack.Pop());

            return queue.ToString();
        }
    }



}






