using Xunit;

namespace InterviewsJuly2020
{
    public class TraverseBinaryTree
    {
        public string Solution(long[] arr)
        {
            // Type your solution here
            long left = 0;
            long right = 0;
            var current = -1;
            for (var i = 1; i < arr.Length; i++)
            {
                var data = arr[i];
                if (data == -1 || data == 0) continue;
                if (current < 0) // left 
                    left += data;
                else
                    right += data;

                current = current * -1;
            }

            if (left == right) return "";
            return (left > right) ? "Left" : "Right";

        }

        [Fact]
        public void ShouldReturnEmptyWhenSumsAreEqual()
        {
            long[] numbers = new long[] { 1, 10, 5, 1, 0, 6 };

            var result = Solution(numbers);

            Assert.Equal("", result);
        }




    }





    


}






