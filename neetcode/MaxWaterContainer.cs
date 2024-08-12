namespace neetcode;

public class MaxWaterContainer
{
    public int MaxArea(int[] heights)
    {
        var maxArea = 0;

        for (int left = 0; left < heights.Length; left++)
        {
            var leftHeight = heights[left];
            var leftMaxArea = 0;
            for (int right = heights.Length - 1; right > left; right--)
            {
                var rightHeight = heights[right];

                var area = Math.Min(leftHeight, rightHeight) * (right - left);
                leftMaxArea = Math.Max(leftMaxArea, area);

                if (rightHeight >= leftHeight)
                    break;
            }

            maxArea = Math.Max(maxArea, leftMaxArea);
        }
        return maxArea;
    }

    public int MaxAreaShiftWhicheverSmaller(int[] heights)
    {
        var maxArea = 0;

        var left = 0;
        var right = heights.Length - 1;

        while (left < right)
        {
            var leftHeight = heights[left];
            var rightHeight = heights[right];
            var area = Math.Min(leftHeight, rightHeight) * (right - left);
            maxArea = Math.Max(maxArea, area);
            if (leftHeight < rightHeight)
                left++;
            else
                right--;
        }

        return maxArea;
    }
    
    [Fact]
    public void Test1()
    {
        var result = MaxArea([1, 7, 2, 5, 4, 7, 3, 6]);
        Assert.Equal(36, result);
        var result2 = MaxAreaShiftWhicheverSmaller([1, 7, 2, 5, 4, 7, 3, 6]);
        Assert.Equal(36, result2);

    }

    [Fact]
    public void Test2()
    {
        var result = MaxArea([2, 2, 2]);
        Assert.Equal(4, result);
        var result2 = MaxAreaShiftWhicheverSmaller([2, 2, 2]);
        Assert.Equal(4, result2);
    }

}