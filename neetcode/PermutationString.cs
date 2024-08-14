namespace neetcode;

public class PermutationString
{
    public bool CheckInclusion(string permutation, string str)
    {
        // notes
        // leetcode guy keeps a track of matches, the target is 26, as he moves his window he checks to see if the edges are matching
        // he also pre-makes his window, as I did for a spell, not that the code came out better,
        // he does also live off a single iterator, which with fixed size works find
        // overall his code is a mess too

        var strAsSpan = str.AsSpan();
        var expectedLength = permutation.Length;

        var left = 0;
        var right = 0;
        var expectedCharCount = new int[26];
        var windowCharCount = new int[26];

        foreach (var letter in permutation)
            expectedCharCount[letter - 'a']++;

        while (right < str.Length)
        {
            windowCharCount[strAsSpan[right] - 'a']++;
            var windowSize = right - left + 1;

            var foundAllLetters = true;

            for (var i = 0; i < expectedCharCount.Length; i++)
            {
                if (expectedCharCount[i] != windowCharCount[i])
                {
                    foundAllLetters = false;
                    break;
                }
            }

            if (foundAllLetters)
                return true;

            if (windowSize == expectedLength)
            {
                windowCharCount[strAsSpan[left] - 'a']--;
                left++;
            }

            right++;
        }

        return false;
    }


    [Fact]
    public void Test1()
    {
        var result = CheckInclusion("abc", "lecabee");
        Assert.True(result);
    }

    [Fact]
    public void Test2()
    {
        var result = CheckInclusion("abc", "lecaabee");
        Assert.False(result);
    }

    [Fact]
    public void Test3()
    {
        var result = CheckInclusion("pqzhi", "ghrqpihzybre");
        Assert.True(result);
    }
}