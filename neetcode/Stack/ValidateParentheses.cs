using System.Linq;

namespace Neetcode.Stack;

public class ValidateParentheses
{
    public bool IsValid(string s)
    {
        var brackets = new Dictionary<char, char>()
        {
            {'{', '}'},
            {'[', ']'},
            {'(', ')'},
        };

        var openStack = new Stack<char>();

        foreach (var character in s)
        {
            if (brackets.ContainsKey(character))
                openStack.Push(character);

            if (brackets.ContainsValue(character))
            {
                if (!openStack.TryPop(out var openingChar) || brackets[openingChar] != character)
                    return false;
            }
        }

        if (openStack.Any())
            return false;

        return true;
    }

    [Fact]
    public void Test1()
    {
        Assert.True(IsValid("[]"));
    }

    [Fact]
    public void Test2()
    {
        Assert.False(IsValid("]"));
    }

    [Fact]
    public void Test3()
    {
        Assert.False(IsValid("["));
    }
}