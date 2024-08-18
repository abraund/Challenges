namespace Neetcode.Stack;

public class EvaluateReversePolishNotation
{
    public int EvalRPN(string[] tokens)
    {
        // neetcode guy absorbs the int parse into the other conditional loop, inline the pops, makes sense

        var stack = new Stack<int>();

        foreach (var token in tokens)
        {
            if(int.TryParse(token, out var num))
                stack.Push(num);
            else
            {
                var right = stack.Pop();
                var left = stack.Pop();
                if (token == "-")
                    stack.Push(left - right);
                else if(token == "+")
                    stack.Push(left + right);
                else if(token == "*")
                    stack.Push(left * right);
                else if(token == "/")
                    stack.Push(left / right);
            }
        }
        
        return stack.Pop();
    }

    [Fact]
    public void Test1()
    {
        Assert.Equal(5, EvalRPN(["1", "2", "+", "3", "*", "4", "-"]));
    }

}