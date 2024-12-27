namespace LeetCode._004MedianOfTwoSortedArrays
{        
    public class Solution
    {
        #region Methods
        public double FindMedianSortedArrays(int[] nums1, int[] nums2) 
        {
            var result = default(double);
            var l1 = nums1.Length;
            var l2 = nums2.Length;
            var ls = l1 + l2;
            var isNextIndexOfIntrestNeeded = ls % 2 == 0;
            var indexOfIntrest = ls / 2 -  (isNextIndexOfIntrestNeeded ? 1 : 0);

            var i1 = 0;
            var i2 = 0;

            var numberOfInterest1 = 0;
            var numberOfInterest2 = 0;

            var hasNum1 = false;
            var hasNum2 = false;
            var shouldTake1 = false;

            for (var i = 0; i <= indexOfIntrest; i++)
            {
                hasNum1 = i1 < l1;
                hasNum2 = i2 < l2;


                if(hasNum1 && hasNum2)
                {
                    shouldTake1 = nums1[i1] < nums2[i2];
                }
                else if(hasNum1)
                {
                    shouldTake1 = true;
                }
                else
                {
                    shouldTake1 = false;
                }

                if (shouldTake1)
                {
                    numberOfInterest1 = nums1[i1++];
                }
                else
                {
                    numberOfInterest1 = nums2[i2++];
                }
            }

            if(isNextIndexOfIntrestNeeded)
            {
                hasNum1 = i1 < l1;
                hasNum2 = i2 < l2;


                if (hasNum1 && hasNum2)
                {
                    shouldTake1 = nums1[i1] < nums2[i2];
                }
                else if (hasNum1)
                {
                    shouldTake1 = true;
                }
                else
                {
                    shouldTake1 = false;
                }

                if (shouldTake1)
                {
                    numberOfInterest2 = nums1[i1++];
                }
                else
                {
                    numberOfInterest2 = nums2[i2++];
                }

                result = (numberOfInterest1 + numberOfInterest2) / 2.0;
            }
            else
            {
                result = numberOfInterest1;
            }
            

            return result;
        } 
        #endregion
    }
}
