namespace LeetCode._003LongestSubstringWithoutRepeatingCharacters
{
    public class Test
    {
        #region Methods
        public void Solution()
        {
            var input = GetTest5();
            var s = new Solution();
            var result = s.LengthOfLongestSubstring(input);
            
            Console.WriteLine(result);
        }
        string GetTest1()
        {
            var s = "abcabcbb";
            return s;
        }
        string GetTest2()
        {
            var s = "bbbbb";
            return s;
        }
        string GetTest3()
        {
            var s = "pwwkew";
            return s;
        }

        string GetTest4()
        {
            var s = "qwertyABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789!@#$%^&*()_+-=[]{}|;:'\",.<>?/`~qwerty";
            return s;
        }

        string GetTest5()
        {
            var s = "jbpnbwwd";
            return s;
        }
        #endregion
    }

    
    public class Solution
    {
        #region Methods
        public int LengthOfLongestSubstring(string s)
        {
            var l = s.Length;
            
            var counter = 0;
            var maxCounted = 0;
            var isMatchFound = false;

            for (var i = 0; i < l; i++)
            {
                counter = 0;
                for (var j = i; j < l; j++)
                {
                    for(var k=j-1; k>=i; k--)
                    {
                        if(s[k] == s[j])
                        {
                            isMatchFound = true;
                            break;
                        }                        
                    }

                    if(isMatchFound)
                    {
                        if (counter > maxCounted)
                        {
                            maxCounted = counter;
                        }
                        counter = 0;
                        isMatchFound = false;
                        break;
                    }
                    else
                    {                        
                        ++counter;
                    }
                }

                if (counter > maxCounted)
                {
                    maxCounted = counter;
                }
            }

            if (counter > maxCounted)
            {
                maxCounted = counter;
            }

            return maxCounted;
        }
        #endregion
    }
}
