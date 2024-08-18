namespace Neetcode.SlidingWindow;

public class LongestRepeatingSubstringWithReplacement
{
    public int CharacterReplacement(string s, int k)
    {
        var winningSubstringLength = 0;
        var left = 0;
        var right = 0;
        var charToCountInWindow = Enumerable.Range(0, 26)
            .Select(x => (char)('A' + x))
            .ToDictionary(key => key, val => 0);

        while (right < s.Length)
        {
            charToCountInWindow[s[right]]++;
            var windowSize = right - left + 1;
            var maxChars = charToCountInWindow.Values.Max();

            if (windowSize > k + maxChars)
            {
                charToCountInWindow[s[left]]--;
                left++;
            }
            else
            {
                winningSubstringLength = Math.Max(winningSubstringLength, windowSize);
            }
            right++;
        }

        return winningSubstringLength;
    }

    public int CharacterReplacement2(string s, int k)
    {
        var winningSubstringLength = 0;
        var left = 0;
        var right = 0;
        var charToCountInWindow = Enumerable.Range(0, 26)
            .Select(x => (char)('A' + x))
            .ToDictionary(key => key, val => 0);
        var maxIndividualCharCount = 0; // can be wrong

        while (right < s.Length)
        {
            charToCountInWindow[s[right]]++;
            maxIndividualCharCount = Math.Max(maxIndividualCharCount, charToCountInWindow[s[right]]);

            int windowSize = right - left + 1;
            if (windowSize > k + maxIndividualCharCount)
            {
                charToCountInWindow[s[left]]--;
                left++;
            }
            else
            {
                winningSubstringLength = Math.Max(winningSubstringLength, windowSize);
            }

            right++;
        }

        return winningSubstringLength;
    }

    [Fact]
    public void Test1()
    {
        Assert.Equal(4, CharacterReplacement("XYYX", k: 2));
        Assert.Equal(4, CharacterReplacement2("XYYX", k: 2));
    }

    [Fact]
    public void Test2()
    {
        Assert.Equal(5, CharacterReplacement("AAABABB", k: 1));
        Assert.Equal(5, CharacterReplacement2("AAABABB", k: 1));
    }

    [Fact]
    public void Test3()
    {
        Assert.Equal(3, CharacterReplacement("BAAA", k: 0));
        Assert.Equal(3, CharacterReplacement2("BAAA", k: 0));
    }

    [Fact]
    public void Test4()
    {
        Assert.Equal(5, CharacterReplacement("AABCBCBBCBB", k: 1));
        Assert.Equal(5, CharacterReplacement2("AABCBCBBCBB", k: 1));
    }
}