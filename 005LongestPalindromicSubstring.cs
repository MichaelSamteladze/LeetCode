namespace LeetCode._005LongestPalindromicSubstring
{    
    public class Solution
    {
        #region Methods
        public string LongestPalindrome(string s)
        {
            var perfectStart = 0;
            var maxLength = 1;

            var l = s.Length;

            for (var i = 0; i < l; i++)
            {
                for (var j = i; j < l; j++)
                {
                    var length = j - i + 1;

                    var isPalindrome = IsPalindrome(s, i, length);
                    if (isPalindrome)
                    {                        
                        if(length > maxLength)
                        {
                            perfectStart = i;
                            maxLength = length;                            
                        }                        
                    }
                }
            }

            return s.Substring(perfectStart, maxLength);
        }

        public bool IsPalindrome(string s, int start, int length)
        {
            var IsPalindrome = true;

            var end = start + length;
            var half = length / 2;
            var iterationNumber = 0;
            for (var i = start; i < start + half; i++)
            {
                IsPalindrome = s[i]! == s[end - (++iterationNumber)];
                if (!IsPalindrome)
                {
                    break;
                }
            }
            return IsPalindrome;
        }
        #endregion
    }

    public class SolutionWithSpans
    {
        #region Methods
        public string LongestPalindrome(string s)
        {
            var resultSpan = default(ReadOnlySpan<char>);
            var maxLength = 0;

            var l = s.Length;

            for (var i = 0; i < l; i++)
            {
                for (var j = i; j < l; j++)
                {
                    var testSpan = s.AsSpan(i, j - i + 1);
                    var isPalindrome = IsPalindrome(testSpan);
                    if (isPalindrome)
                    {
                        var palindromeLength = testSpan.Length;
                        if (palindromeLength > maxLength)
                        {
                            maxLength = palindromeLength;
                            resultSpan = testSpan;
                        }
                    }
                }
            }

            return resultSpan.ToString();
        }

        bool IsPalindrome(ReadOnlySpan<char> stringSpan)
        {
            var IsPalindrome = true;
            var l = stringSpan.Length;
            var half = l / 2;
            for (var i = 0; i < half; i++)
            {
                IsPalindrome = stringSpan[i]! == stringSpan[l - 1 - i];
                if (!IsPalindrome)
                {
                    break;
                }
            }
            return IsPalindrome;
        }
        #endregion
    }
}
