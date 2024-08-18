namespace Neetcode.TwoPointer;

public class ValidPalindrome
{
    //note the special characters, clever from leetcode guy,
    //he stop you using a stack to solve this problem and ensures it's a two pointer problem

    public bool IsPalindrome(string s)
    {
        var i = 0;
        var j = s.Length - 1;

        while (i < j)
        {
            var iChar = s[i];
            if (!char.IsLetterOrDigit(iChar))
            {
                i++;
                continue;
            }

            var jChar = s[j];
            if (!char.IsLetterOrDigit(jChar))
            {
                j--;
                continue;
            }

            if (!string.Equals(iChar.ToString(), jChar.ToString(), StringComparison.OrdinalIgnoreCase))
                return false;

            i++;
            j--;
        }

        return true;
    }

    [Fact]
    public void IncNumber()
    {
        var result = IsPalindrome("0P");
        Assert.False(result);
    }

    [Fact]
    public void SmallWithSpecial()
    {
        var result = IsPalindrome("?P");
        Assert.True(result);
    }

    [Fact]
    public void SomehowWrongPalindrome()
    {
        var result = IsPalindrome("ab");
        Assert.False(result);
    }

    [Fact]
    public void OddPalindrome()
    {
        var result = IsPalindrome("tat");
        Assert.True(result);
    }

    [Fact]
    public void EvenPalindrome()
    {
        var result = IsPalindrome("taat");
        Assert.True(result);
    }

    [Fact]
    public void OddPalindromeWithSpecialChar()
    {
        var result = IsPalindrome("tat?");
        Assert.True(result);
    }

    [Fact]
    public void EvenPalindromeWithSpecialChar()
    {
        var result = IsPalindrome("taat?");
        Assert.True(result);
    }

    [Fact]
    public void Palindrome()
    {
        var result = IsPalindrome("Was it a car or a cat I saw?");
        Assert.True(result);
    }

    [Fact]
    public void NotPalindrome()
    {
        var result = IsPalindrome("tab a cat");
        Assert.False(result);
    }
}