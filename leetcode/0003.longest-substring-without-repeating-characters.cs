//https://leetcode.com/problems/longest-substring-without-repeating-characters/submissions/

namespace _0003;

using NUnit.Framework;

public class Solution
{
    public int LengthOfLongestSubstring(string str)
    {
        var charsInWindow = new int[255];
        Array.Fill(charsInWindow, -1);
        var inputStr = str.AsSpan();

        var longestWord = 0;
        var startOfWindow = 0;
        for (var endOfWindow = 0; endOfWindow < inputStr.Length; endOfWindow++)
        {
            var endChar = inputStr[endOfWindow];
            var positionCharLastSeen = charsInWindow[endChar];
            if(positionCharLastSeen != -1 || endOfWindow == inputStr.Length) {
                longestWord = Math.Max(longestWord, endOfWindow - startOfWindow);
                for(; startOfWindow <= positionCharLastSeen; startOfWindow++) {
                    charsInWindow[inputStr[startOfWindow]] = -1;
                }
                charsInWindow[endChar] = endOfWindow;
            }
            else {
                charsInWindow[endChar] = endOfWindow;
            }
        }

        var lastWord = inputStr.Length - startOfWindow;

        return Math.Max(longestWord, lastWord);
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
    public void PwwKew(){
        var len = new Solution().LengthOfLongestSubstring("pwwkew");
        Assert.That(len, Is.EqualTo(3));
    }


    [Test]
    public void BigWSlide(){
        var len = new Solution().LengthOfLongestSubstring("ayzbycaz");
        Assert.That(len, Is.EqualTo(5));
    }
}
