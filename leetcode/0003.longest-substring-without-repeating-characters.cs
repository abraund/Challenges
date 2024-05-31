//https://leetcode.com/problems/longest-substring-without-repeating-characters/submissions/

namespace _0003;

using NUnit.Framework;

public class Solution
{
    public int LengthOfLongestSubstring(string s)
    {        
        var str = s.AsSpan();

        var lastSeenCharPosOffsetByOne = new int[255];

        var longestWord = 0;
        var left = 0;
        for (var right = 0; right < str.Length; right++)
        {
            var rightChar = str[right];
            var charLastSeenPos = lastSeenCharPosOffsetByOne[rightChar] - 1;
            
            if(charLastSeenPos != - 1 && charLastSeenPos >= left) {
                longestWord = Math.Max(longestWord, right - left);
                left = charLastSeenPos + 1;
            }

            lastSeenCharPosOffsetByOne[rightChar] = right + 1;
        }

        return Math.Max(longestWord, str.Length - left);
    }
}

public class Tests
{
    [Test]
    public void FirstEncounterCorrect(){
        var len = new Solution().LengthOfLongestSubstring("abcabcbb");
        Assert.That(len, Is.EqualTo(3));
    }

    [Test]
    public void ShiftingWindow(){
        var len = new Solution().LengthOfLongestSubstring("dvdf");
        Assert.That(len, Is.EqualTo(3));
    }

    [Test]
    public void Pwwkew(){
        var len = new Solution().LengthOfLongestSubstring("pwwkew");
        Assert.That(len, Is.EqualTo(3));
    }


    [Test]
    public void BigSlide(){
        var len = new Solution().LengthOfLongestSubstring("ayzbycaz");
        Assert.That(len, Is.EqualTo(5));
    }
}
