namespace LeetCode._009PalindromeNumber
{
    public class Solution
    {
        public bool IsPalindrome(int x)
        {
            var isPalindrome = true;

            if (x < 0)
            {
                isPalindrome = false;
            }
            else
            {
                var mod = x % 10;
                x /= 10;
                if (x > 0)
                {
                    var l = 1;
                    var nums = new byte[10];
                    nums[0] = (byte)mod;
                    while (x > 0)
                    {
                        ++l;
                        nums[l - 1] = (byte)(x % 10);
                        x /= 10;
                    }

                    for (var i = 0; i < l / 2; i++)
                    {
                        if (nums[i] != nums[l - 1 - i])
                        {
                            isPalindrome = false;
                            break;
                        }
                    }
                }
            }

            return isPalindrome;
        }
    }
}
