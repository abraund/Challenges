using System.Diagnostics;

namespace neetcode;

public class Range
{
    public Range(int minimum, int maximum)
    {
        Minimum = minimum; 
        Maximum = maximum;
    }

    public int Minimum { get; set; }
    public int Maximum { get; set; }

    public override string ToString()
    {
        return $"{Minimum}-{Maximum}";
    }
}

public class LongestConsecutiveSequence
{
    public int LongestConsecutive(int[] nums)
    {
        var hash = nums.ToHashSet();
        var longestSequence = 0;
        foreach (int i in hash)
        {
            var startOfSequence = !hash.Contains(i - 1);
            if (startOfSequence)
            {
                var j = i;
                while (hash.Contains(j + 1))
                    j++;

                longestSequence = Math.Max(longestSequence, j - i + 1);
            }
        }

        return longestSequence;
    }

    [Fact]
    public void TwoChains()
    {
        var result = LongestConsecutive([1, 2, 4, 3]);
        Assert.Equal(4, result);
    }


    [Fact]
    public void MixedSequence()
    {
        var result = LongestConsecutive([2, 20, 4, 10, 3, 4, 5]);
        Assert.Equal(4, result);
    }

    [Fact]
    public void SequenceWithDuplicateNumber()
    {
        var result = LongestConsecutive([0, 3, 2, 5, 4, 6, 1, 1]);
        Assert.Equal(7, result);
    }

}