namespace Neetcode.LinkedList;

public class RemoveNodeFromTheEndOfALinkedList
{
    public class ListNode
    {
        public int val;
        public ListNode next;
        public ListNode(int val = 0, ListNode next = null)
        {
            this.val = val;
            this.next = next;
        }

        private ListNode(List<int> list)
        {
            if (list == null || list.Count == 0)
            {
                throw new ArgumentException("List cannot be null or empty");
            }
            else
            {
                this.val = list[0];
                ListNode current = this;

                for (int i = 1; i < list.Count; i++)
                {
                    current.next = new ListNode(list[i]);
                    current = current.next;
                }
            }
        }

        public static ListNode CreateInstance(List<int> list)
        {
            if (list.Count == 0)
                return null;

            return new ListNode(list);
        }

        public List<int> ToList()
        {
            var list = new List<int>() { val };
            if (next != null)
                list.AddRange(next.ToList());
            return list;
        }
    }

    public ListNode RemoveNthFromEnd(ListNode head, int n)
    {
        ListNode dummy = null;
        ListNode left = head;
        ListNode right = head;

        for (int i = 0; i < n; i++)
            right = right.next;

        while (true)
        {
            if (right.next == null)
            {
                left.next = left.next.next;
                break;
            }

            left = left.next;
            right = right.next;
        }

        return head;
    }

    [Fact]
    public void Test1()
    {
        var result = RemoveNthFromEnd(ListNode.CreateInstance([1,2,3,4]), 2);
        Assert.Equal([1, 2, 4], result.ToList());
    }

    [Fact]
    public void Test2()
    {
        var result = RemoveNthFromEnd(ListNode.CreateInstance([5]), 1);
        Assert.Equal([], result.ToList());
    }
}