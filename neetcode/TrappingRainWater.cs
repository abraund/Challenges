namespace neetcode;

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

    [Fact]
    public void TrapTest()
    {
        var result = Trap([0, 2, 0, 3, 1, 0, 1, 3, 2, 1]);
        Assert.Equal(9, result);
    }
}