using System.Collections.Immutable;

namespace Neetcode.Stack;

public class GenerateParenthesisSolution
{
    public List<string> GenerateParenthesis(int n)
    {
        var results = new HashSet<string>();
        var stack = new Stack<string>();
        var open = 0;
        var closed = 0;

        Add(open, closed);

        return results.Select(x => x.ToString()).ToList();

        void Add(int open, int closed)
        {

            if (open == n && closed == n)
            {
                results.Add(stack.Peek());
                return;
            }

            if (open < n)
            {
                var preamble = stack.TryPeek(out var pre) ? pre : "";
                stack.Push(pre + "(");
                Add(open + 1, closed);
                stack.Pop();
            }

            if (open > closed)
            {
                var preamble = stack.TryPeek(out var pre) ? pre : "";
                stack.Push(pre + ")");
                Add(open, closed + 1);
                stack.Pop();
            }
        }
    }
    
    [Fact]
    public void Test1()
    {
        Assert.Equal(["((()))", "(()())", "(())()", "()(())", "()()()"], GenerateParenthesis(3));
    }

    [Fact]
    public void Test2()
    {
        Assert.Equal(["()"], GenerateParenthesis(1));
    }

}