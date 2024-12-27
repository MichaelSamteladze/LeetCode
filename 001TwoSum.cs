namespace LeetCode._001TwoSum
{
    /*     
        Step 1: Run for-cycle on each element in array
        Step 2: Calculate difference "diff" between target and current number from the for-cycle.
        Step 3: Save each element and it's index in diffIndexDictionary as (numberValue, index) pair.
        Step 4: Inside for, if we can find a key, in dictionary which equals to "diff", it means we that we've found TwoSum couple. 
        -- Step 4.1: We save current index "i" and the diffIndexDictionary[diff] value (which represents index) into result array.
    */
    public class Solution
    {
        #region Methods
        public int[] TwoSum(int[] nums, int target)
        {
            var result = new int[2];
            var diffIndexDictionary = new Dictionary<int, int>();

            for (var i = 0; i < nums.Length; i++)
            {
                var current = nums[i];

                var diff = target - current;
                if (diffIndexDictionary.ContainsKey(diff))
                {
                    result[0] = diffIndexDictionary[diff];
                    result[1] = i;
                    break;
                }
                else
                {
                    if (!diffIndexDictionary.ContainsKey(current))
                    {
                        diffIndexDictionary.Add(current, i);
                    }
                }
            }

            return result;
        } 
        #endregion
    }
}
