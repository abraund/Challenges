namespace Neetcode.SlidingWindow;

public class LongestSubstringWithoutDuplicates
{
    public int LengthOfLongestSubstring(string s)
    {
        if (string.IsNullOrEmpty(s))
            return 0;

        var longest = 1;
        var charLastSeen = new int[256];
        Array.Fill(charLastSeen, -1);

        var left = 0;
        var right = 1;
        charLastSeen[s[left]] = 0;

        while (right < s.Length)
        {
            if (charLastSeen[s[right]] >= left)
                left = charLastSeen[s[right]] + 1;

            charLastSeen[s[right]] = right;
            longest = Math.Max(longest, right - left + 1);
            right++;
        }

        return longest;
    }

    [Fact]
    public void Test1()
    {
        Assert.Equal(3, LengthOfLongestSubstring("zxyzxyz"));
    }


    [Fact]
    public void Test2()
    {
        Assert.Equal(1, LengthOfLongestSubstring("xxxx"));
    }


    [Fact]
    public void Test3()
    {
        Assert.Equal(3, LengthOfLongestSubstring("abcabcbb"));
    }

    [Fact]
    public void Test4()
    {
        Assert.Equal(1, LengthOfLongestSubstring("a"));
    }

    [Fact]
    public void Test5()
    {
        Assert.Equal(0, LengthOfLongestSubstring(""));
    }

    [Fact]
    public void Test6()
    {
        Assert.Equal(3, LengthOfLongestSubstring("dvdf"));
    }
}