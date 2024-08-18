namespace neetcode;

public class MinimumWindowWithCharacters
{
    public string MinWindow(string s, string t)
    {
        var targetLength = t.Length;

        var l = 0;
        var r = 0;
        var matches = 0;
        var targetDict = t.GroupBy(x => x).ToDictionary(x => x.Key, x => x.Count());
        var matchDict = t.GroupBy(x => x).ToDictionary(x => x.Key, x => 0);
        var matchQueue = new Queue<int>();
        var result = (Left: 0, Right: s.Length); // r outside possibilty
        
        while (r < s.Length && l < s.Length && targetLength + l <= s.Length)
        {
           
            if (matches == targetLength)
            {
                result = result.Right - result.Left > r - l ? (l, r) : result;

                if (targetDict.ContainsKey(s[l]))
                {
                    var lMatches = --matchDict[s[l]];
                    if (lMatches < targetDict[s[l]])
                        matches--;

                    if (matches < targetLength)
                        r = r + 1 < s.Length ? r + 1 : r;
                }

                l++;
            }
            else
            {
                if (targetDict.ContainsKey(s[r]))
                {
                    var rMatches = matchDict[s[r]]++;

                    if(rMatches < targetDict[s[r]])
                        matches++;
                }

                if(matches != targetLength)
                    r++;
            }
        }

        return result.Right == s.Length ? "" : s.Substring(result.Left, result.Right - result.Left + 1);
    }

    [Fact]
    public void Test1()
    {
        Assert.Equal("YXAZ", MinWindow("OUZODYXAZV", "XYZ"));
    }

    [Fact]
    public void Test2()
    {
        Assert.Equal("a", MinWindow("a", "a"));
    }

    [Fact]
    public void Test3()
    {
        Assert.Equal("", MinWindow("a", "aa"));
    }

    [Fact]
    public void Test4()
    {
        Assert.Equal("COBA", MinWindow("BCOBANC", "ABC"));
    }

    [Fact]
    public void Test5()
    {
        Assert.Equal("", MinWindow("s", "a"));
    }

    [Fact]
    public void Test6()
    {
        Assert.Equal("abbbbbcdd", MinWindow("aaaaaaaaaaaabbbbbcdd", "abcdd"));
    }

    [Fact]
    public void Test7()
    {
        Assert.Equal("aa", MinWindow("aa", "aa"));
    }
}