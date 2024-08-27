namespace Neetcode.LinkedList;

public class MergeTwoSortedLinkedLists
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

    public ListNode MergeTwoLists(ListNode list1, ListNode list2)
    {
        if (list1 == null && list2 == null)
            return null;

        var i = list1;
        var j = list2;

        // neet code guy also starts with a listnode, but he considers it a dummy,
        // he considers next the start of his result
        // he returns next
        // I wonder at some point about putting the result in a list, even though I knew I would only put one thing in it, a kind of monad
        // I feel there's a thought here
        ListNode res = new ListNode();
        ListNode cur = res;

        while (i != null || j != null)
        {
            if ((i?.val ?? int.MaxValue) <= (j?.val ?? int.MaxValue))
            {
                cur.val = i.val;
                i = i.next;
            }
            else if ((i?.val ?? int.MaxValue) > (j?.val ?? int.MaxValue))
            {
                cur.val = j.val;
                j = j.next;
            }

            if (i != null || j != null)
            {
                cur.next = new ListNode();
                cur = cur.next;
            }
        }

        return res;
    }

    [Fact]
    public void Test1()
    {
        var result = MergeTwoLists(ListNode.CreateInstance([1,2,4]), ListNode.CreateInstance([1,3,5]));
        Assert.Equal([1, 1, 2, 3, 4, 5], result.ToList());
    }

    [Fact]
    public void Test2()
    {
        var result = MergeTwoLists(ListNode.CreateInstance([]), ListNode.CreateInstance([]));
        Assert.Equal([], result.ToList());
    }


    [Fact]
    public void Test3()
    {
        var result = MergeTwoLists(ListNode.CreateInstance([1]), ListNode.CreateInstance([]));
        Assert.Equal([1], result.ToList());
    }
}