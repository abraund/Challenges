namespace Neetcode.Stack;

public class MinStack
{
    /*
     * Notes, leetcode guy implements this by using 2 built in stacks
     * (debateable that this is within the spirit)
     * So he's got a stack representing the value, and a stack representing the min up until that point
     * Think I prefer my own solution to be honest.
     */

    private Node? _root;

    public void Push(int val)
    {
        var rootMin = _root != null ? _root.Min : int.MaxValue;
        var min = Math.Min(rootMin, val);
        _root = new Node(val, _root!, min);
    }

    public void Pop()
    {
        _root = _root!.Next;
    }

    public int Top()
    {
        return _root!.Value;
    }

    public int GetMin()
    {
        return _root!.Min;
    }

    private class Node
    {
        public int Min { get; }
        public int Value { get; }
        public Node Next { get; }

        public Node(int value, Node next, int min)
        {
            Min = min;
            Value = value;
            Next = next;
        }
    }

    [Fact]
    public void Test1()
    {
        MinStack minStack = new MinStack();
        minStack.Push(1);
        minStack.Push(2);
        minStack.Push(0);
        Assert.Equal(0, minStack.GetMin()); // return 0
        minStack.Pop();
        Assert.Equal(2, minStack.Top());    // return 2
        Assert.Equal(1, minStack.GetMin()); // return 1
    }

}