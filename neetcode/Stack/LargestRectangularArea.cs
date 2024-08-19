namespace Neetcode.Stack;

public class LargestRectangleAreaSolution
{
    public int LargestRectangleArea(int[] heights)
    {
        var result = 0;
        var stack = new Stack<(int Position, int Height)>();

        for (int i = 0; i < heights.Length; i++)
        {
            if (!stack.Any() || heights[i] > stack.Peek().Height)
                stack.Push((i, heights[i]));

            while (stack.Any() && (heights[i] < stack.Peek().Height))
            {
                var resolve = stack.Pop();
                var area = resolve.Height * ((i-1) - resolve.Position + 1);
                result = Math.Max(result, area);
                
                if (!stack.Any() || heights[i] > stack.Peek().Height)
                    stack.Push((resolve.Position, heights[i]));
            }
        }

        while (stack.Any())
        {
            var resolve = stack.Pop();
            var area = resolve.Height * (heights.Length - resolve.Position);
            result = Math.Max(result, area);
        }

        return result;
    }

    [Fact]
    public void Test1()
    {
        Assert.Equal(8, LargestRectangleArea([7, 2, 2, 4]));
    }

    [Fact]
    public void Test1z()
    {
        Assert.Equal(8, LargestRectangleArea([7, 2, 4, 2]));
    }

    [Fact]
    public void Test2()
    {
        Assert.Equal(7, LargestRectangleArea([1, 3, 7]));
    }

    [Fact]
    public void Test3()
    {
        Assert.Equal(9, LargestRectangleArea([0, 9]));
    }

}