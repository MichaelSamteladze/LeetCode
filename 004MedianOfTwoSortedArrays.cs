using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode._004MedianOfTwoSortedArrays
{
    public class Test
    {
        #region Methods
        public void Solution()
        {
            (var nums1, var nums2) = GetTest4();
            var result = new Solution().FindMedianSortedArrays(nums1, nums2);                
            Console.WriteLine(result);
        }

        (int[], int[]) GetTest1()
        {        
            var nums1 = new int[] { 1,3 };
            var nums2 = new int[] { 2 };
            return (nums1, nums2);
        }

        (int[], int[]) GetTest2()
        {
            var nums1 = new int[] { 1, 2 };
            var nums2 = new int[] { 3, 4 };
            return (nums1, nums2);
        }

        (int[], int[]) GetTest3()
        {
            var nums1 = new int[] { 3, 5 };
            var nums2 = new int[] { 7, 8, 9, 17, 29, 32, 45, 55 };
            return (nums1, nums2);
        }

        (int[], int[]) GetTest4()
        {
            var nums1 = new int[] { 3, 5, 8, 29, 32, 45 };
            var nums2 = new int[] { 7, 9, 17, 55 };
            return (nums1, nums2);
        }
        #endregion
    }
    
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
