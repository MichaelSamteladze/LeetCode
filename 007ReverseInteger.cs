﻿namespace LeetCode._007ReverseInteger
{
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
