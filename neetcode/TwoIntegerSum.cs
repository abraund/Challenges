using System.Diagnostics;

namespace neetcode;

public class TwoIntegerSum
{
    public int[] TwoSum(int[] numbers, int target)
    {
        var numToPos = new Dictionary<int, int>();

        for (int i = 0; i < numbers.Length; i++)
        {
            var currentNum = numbers[i];
            var partner = target - currentNum;

            if (numToPos.TryGetValue(partner, out var partnerPos))
                return new [] {partnerPos + 1, i + 1};

            numToPos[currentNum] = i;
        }

        throw new Exception("impossible");
    }

    [Fact]
    public void IncNumber()
    {
        var result = TwoSum([1,2,3,4], 3);
        Assert.Equal([1,2], result);
    }
}