namespace LeetCode._008StringToIntegerATOI
{
    public class Solution
    {
        public int MyAtoi(string s)
        {
            var result = 0;
            var l = s.Length;            
            var position = 0;

            if (l > 0)
            {
                var c = default(char);
                var shouldSkip = true;
                while (shouldSkip)
                {
                    c = s[position];
                    shouldSkip = (c == ' ') && (++position < l);                    
                }

                if (position < l)
                {
                    c = s[position];
                    var isNegative = false;
                    if (c == '-')
                    {
                        isNegative = true;
                        ++position;
                    }
                    else if (c == '+')
                    {
                        ++position;
                    }

                    if (position < l)
                    {
                        c = s[position];
                        var shouldContinue = (c > 47 && c < 58);

                        while (shouldContinue)
                        {
                            result *= 10;
                            if (result % 10 == 0)
                            {
                                var numberToAdd = (c - 48) * (isNegative ? -1 : 1);

                                var shouldAdd = isNegative ? int.MinValue - result - numberToAdd < 0 : int.MaxValue - result - numberToAdd > 0;

                                if (shouldAdd)
                                {
                                    result += numberToAdd;
                                }
                                else
                                {
                                    if (isNegative)
                                    {
                                        result = int.MinValue;
                                    }
                                    else
                                    {
                                        result = int.MaxValue;
                                    }
                                    break;
                                }
                            }
                            else
                            {
                                if (isNegative)
                                {
                                    result = int.MinValue;
                                }
                                else
                                {
                                    result = int.MaxValue;
                                }
                                break;                                
                            }

                             ++position;
                            if(position < l)
                            {
                                c = s[position];
                                shouldContinue = (c > 47 && c < 58);
                            }
                            else
                            {
                                shouldContinue = false;
                            }
                        }
                    }
                }                
            }

            return result;
        }
    }
}
