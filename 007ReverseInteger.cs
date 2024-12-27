using System.ComponentModel.Design;

namespace LeetCode._007ReverseInteger
{
    public class Test
    {
        #region Methods
        public void Solution()
        {
            var x = GetTest1();
            var solution = new Solution();
            var result = solution.Reverse(x);
            Console.WriteLine(result);            
        }

        int GetTest1()
        {
            return -1999999999;
        }              
        #endregion
    }
    
    public class Solution
    {
        #region Methods
        public int Reverse(int x)
        {
            var isNegative = x < 0;

            var remainder = x % 10;
            var result = remainder;
            x -= remainder;
            x /= 10;

            if (isNegative)
            {
                while (x < 0)
                {
                    remainder = x % 10;
                    result *= 10;
                    if (result % 10 != 0)
                    {
                        result = 0;
                        break;
                    }
                    result += remainder;

                    x -= remainder;
                    x /= 10;
                }
            }
            else
            {
                while (x > 0)
                {
                    remainder = x % 10;
                    result *= 10;
                    if (result % 10 != 0)
                    {
                        result = 0;
                        break;
                    }
                    result += remainder;

                    x -= remainder;
                    x /= 10;
                }
            }

            return result;
        }
        #endregion        
    }
}
