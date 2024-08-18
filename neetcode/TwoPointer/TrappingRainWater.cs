namespace Neetcode.TwoPointer;

public class TrappingRainWater
{
    public int Trap(int[] heights)
    {
        var totalWater = 0;
        var heightOfWaterToWhereStarted = new Dictionary<int, int>();

        for (int i = 0; i < heights.Length; i++)
        {
            var height = heights[i];

            for (int j = 1; j <= height; j++)
            {
                // resolve jets
                if (heightOfWaterToWhereStarted.TryGetValue(j, out var start))
                {
                    totalWater += i - start;
                    heightOfWaterToWhereStarted.Remove(j);
                }

                // set jets running
                heightOfWaterToWhereStarted[j] = i + 1;
            }
        }

        return totalWater;
    }

    public int Trap2(int[] heights)
    {
        var totalWater = 0;

        var left = 0;
        var right = heights.Length - 1;
        var i = 0;

        var maxHeightLeft = 0;
        var maxHeightRight = 0;

        while (left < right)
        {
            maxHeightLeft = Math.Max(maxHeightLeft, heights[left]);
            maxHeightRight = Math.Max(maxHeightRight, heights[right]);

            totalWater += Math.Max(Math.Min(maxHeightLeft, maxHeightRight) - heights[i], 0);

            if (maxHeightLeft < maxHeightRight)
            {
                left++;
                i = left;
            }
            else
            {
                right--;
                i = right;
            }
        }

        return totalWater;
    }


    [Fact]
    public void TrapTest()
    {
        var result = Trap([0, 2, 0, 3, 1, 0, 1, 3, 2, 1]);
        Assert.Equal(9, result);
        var result2 = Trap2([0, 2, 0, 3, 1, 0, 1, 3, 2, 1]);
        Assert.Equal(9, result2);
    }
}