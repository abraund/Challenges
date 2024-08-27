using System.ComponentModel.DataAnnotations;

namespace Neetcode.LinkedList;

public class ListNode
{
    public int val;
    public ListNode next;
    public ListNode(int val = 0, ListNode next = null)
    {
        this.val = val;
        this.next = next;
    }

    public List<int> ToList()
    {
        var list = new List<int>() { val };
        if(next != null)
            list.AddRange(next.ToList());
        return list;
            
    }
}

public class ReverseALinkedList
{
    public ListNode ReverseList(ListNode head)
    {
        var nextNode = head;
        var result = (ListNode)null;
        while (nextNode != null)
        {
            result = new ListNode(nextNode.val, result);
            nextNode = nextNode.next;
        }

        return result!;
    }

    [Fact]
    public void Test1()
    {
        var result = ReverseList(new ListNode(0, new ListNode(1, new ListNode(2, new ListNode(3)))));
        Assert.Equal([3,2,1,0], result.ToList());
    }
}