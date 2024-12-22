using System.Text;

namespace LeetCode._002AddTwoNumbers
{
    public class Test
    {
        #region Methods
        public void Solution()
        {
            (var l1, var l2) = GetTest1();

            var s = new Solution();
            var result = s.AddTwoNumbers(l1, l2);

            var sb = new StringBuilder();
            BuildHierarchyString(result, sb);
            Console.WriteLine(sb.ToString());
        }

        void BuildHierarchyString(ListNode node, StringBuilder sb)
        {
            if (node != null)
            {
                sb.Append(node.val.ToString());
                if (node.next != null)
                {
                    sb.Append(",");
                    BuildHierarchyString(node.next, sb);
                }
            }

        }

        (ListNode, ListNode) GetTest1()
        {
            var l1 = new ListNode
            {
                val = 9,
                next = new ListNode
                {
                    val = 9,
                    next = new ListNode
                    {
                        val = 9,
                        next = new ListNode
                        {
                            val = 9,
                            next = new ListNode
                            {
                                val = 9,
                                next = new ListNode
                                {
                                    val = 9,
                                    next = new ListNode
                                    {
                                        val = 9
                                    }
                                }
                            }
                        }
                    }
                }
            };
            var l2 = new ListNode
            {
                val = 9,
                next = new ListNode
                {
                    val = 9,
                    next = new ListNode
                    {
                        val = 9,
                        next = new ListNode
                        {
                            val = 9
                        }
                    }
                }
            };
            return (l1, l2);
        }
        (ListNode, ListNode) GetTest2()
        {
            var l1 = new ListNode
            {
                val = 2,
                next = new ListNode
                {
                    val = 4,
                    next = new ListNode
                    {
                        val = 3
                    }
                }
            };
            var l2 = new ListNode
            {
                val = 5,
                next = new ListNode
                {
                    val = 6,
                    next = new ListNode
                    {
                        val = 7
                    }
                }
            };
            return (l1, l2);
        }        
        #endregion
    }

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
