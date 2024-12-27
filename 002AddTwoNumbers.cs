namespace LeetCode._002AddTwoNumbers
{
    /*
          to solve this solution we need to use mathematics row addition method. for example:

          342
         +465
         ----
          807

        or 

         9999999
        +   9999
        --------
        10009998
    */
    public class Solution
    {
        #region Methods
        public ListNode AddTwoNumbers(ListNode l1, ListNode l2)
        {
            var result = new ListNode();
            AddPositions(l1, l2, result, false);
            return result;
        }

        void AddPositions(ListNode l1, ListNode l2, ListNode resultNode, bool hasMemory)
        {
            if (l1 != null || l2 != null)
            {
                resultNode.val =
                    (l1?.val ?? 0)
                    +
                    (l2?.val ?? 0)
                    +
                    (hasMemory ? 1 : 0);

                if (resultNode.val > 9)
                {
                    hasMemory = true;
                    resultNode.val -= 10;
                }
                else
                {
                    hasMemory = false;
                }

                if (l1?.next != null || l2?.next != null)
                {
                    resultNode.next = new ListNode();
                    AddPositions(l1?.next, l2?.next, resultNode.next, hasMemory);
                }
                else
                {
                    if (hasMemory)
                    {
                        resultNode.next = new ListNode { val = 1 };
                    }
                }
            }
        } 
        #endregion
    }

    public class ListNode
    {
        #region Properties
        public int val;
        public ListNode next;
        #endregion

        #region Constructors
        public ListNode(int val = 0, ListNode next = null)
        {
            this.val = val;
            this.next = next;
        }
        #endregion
    }
}
