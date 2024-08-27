using System.ComponentModel.DataAnnotations;

namespace Neetcode.LinkedList;

public class ReorderALinkedList
{
    public class ListNode
    {
        public int val { get; private set; }
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

    public void ReorderList(ListNode head)
    {
        var current = head;
        var count = 0;
        var nodes = new List<ListNode>();

        while (current != null)
        {
            count++;  
            nodes.Add(current);
            current = current.next;
        }

        var middle = count / 2;

        current = head;

        for (int i = 0; i < middle; i++)
        {
            if (count % 2 == 1 && i == middle - 1)
            {
                nodes[i].next.next = null;
                nodes[count - i - 1].next = nodes[i].next;
            }
            else if (i == middle - 1)
                nodes[count - i - 1].next = null;
            else
                nodes[count - i - 1].next = nodes[i].next;

            nodes[i].next = nodes[count - i - 1];
        }
    }

    [Fact]
    public void Test1()
    {
        var node = ListNode.CreateInstance([2, 4, 6, 8]);
        ReorderList(node);
        var res = node.ToList();
        Assert.Equal([2,8,4,6], res);
    }

    [Fact]
    public void Test2()
    {
        var node = ListNode.CreateInstance([2, 4, 6, 8, 10]);
        ReorderList(node);
        var res = node.ToList();
        Assert.Equal([2, 10, 4, 8, 6], res);
    }
}