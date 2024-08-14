namespace neetcode;

public class PermutationString
{
    public bool CheckInclusion(string permutation, string str)
    {
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