
namespace _0002;

public class ListNode
{
    public int val;
    public ListNode? next;

    public ListNode(int val = 0, ListNode? next = null)
    {
        this.val = val;
        this.next = next;
    }
}

public class Solution
{
    public ListNode? AddTwoNumbers(ListNode l1, ListNode l2)
    {
        return Recurse(l1, l2, 0);
    }

    public ListNode? Recurse(ListNode? l1, ListNode? l2, int carry)
    {
        if (l1 == null && l2 == null && carry == 0) 
            return null;

        var res = (l1?.val ?? 0) + (l2?.val ?? 0) + carry;
        var next = Recurse(l1?.next, l2?.next, res / 10);
        return new ListNode((res % 10), next);
    }
}