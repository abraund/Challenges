namespace Neetcode.ArraysAndHashing;

public class IsAnagram
{

    private int[] Primes = new int[] { 2, 3, 5, 7, 11, 13, 17, 19, 23, 29,
        31, 37, 41, 43, 47, 53, 59, 61, 67, 71,
        73, 79, 83, 89, 97, 101 };


    private int GetCharValue(char c)
    {
        return Primes[c - 'a'];
    }


    public bool IsAnagramPrime(string s, string t)
    {
        if(s.Length != t.Length)
            return false;

        var sSpan = s.AsSpan();
        var tSpan = t.AsSpan();
        var sTotal = 1;
        var tTotal = 1;

        for (int i = 0; i < s.Length; i++)
        {
            sTotal *= GetCharValue(sSpan[i]);
            tTotal *= GetCharValue(tSpan[i]);
        }

        return sTotal == tTotal;
    }

    public bool IsAnagramPerf(string s, string t)
    {
        // O(s+t)
        var charCount = new Dictionary<char, int>();
        foreach (var c in s)
        {
            if (charCount.ContainsKey(c))
                charCount[c]++;
            else
                charCount[c] = 1;
        }

        foreach (var c in t)
        {
            if (charCount.ContainsKey(c))
                charCount[c]--;
            else
                return false;
        }

        // extra loop could be avoided by keeping a match count, observing back
        foreach (var c in charCount)
        {
            if (c.Value != 0)
                return false;
        }

        return true;
    }

    public bool IsAnagramMem(string s, string t)
    {
        // O(1)-ish
        // nLogn on perf, some sorting algorithms O(1): they cost memory but it doesn't grow with s & t
        // on the other hand some sorting algorithms do grow, so it may be worth writing one by hand
        return string.Join("", s.OrderBy(x => x)) == string.Join("", t.OrderBy(x => x));
    }


    [Fact]
    public void Racecar()
    {
        Assert.True(IsAnagramPerf("racecar", "carrace"));
        Assert.True(IsAnagramMem("racecar", "carrace"));
        Assert.True(IsAnagramMem("racecar", "carrace"));
    }

    [Fact]
    public void JamJar()
    {
        Assert.False(IsAnagramPerf("jar", "jam"));
        Assert.False(IsAnagramMem("jar", "jam"));
        Assert.False(IsAnagramPrime("jar", "jam"));
    }

    [Fact]
    public void Superset()
    {
        Assert.False(IsAnagramPerf("superset", "super"));
        Assert.False(IsAnagramMem("superset", "super"));
        Assert.False(IsAnagramPrime("superset", "super"));
    }
}
