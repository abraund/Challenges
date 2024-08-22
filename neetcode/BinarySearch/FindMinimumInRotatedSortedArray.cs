namespace Neetcode.BinarySearch;

public class FindMinimumInRotatedSortedArray
{
    public int FindMin(int[] nums)
    {
        var l = 0;
        var r = nums.Length - 1;
        var result = int.MaxValue;

        if (nums.Length == 1)
            return nums[0];

        while (l < r)
        {
            var m = (l + r) / 2;
            result = new int[] { result, nums[m], nums[r] }.Min();

            if (nums[m] <= nums[l])
                r = m;
            else if (nums[m] >= nums[r])
                l = m + 1;
            else if (nums[l] < nums[r])
                return nums[l];
        }

        return result;
    }

    [Fact]
    public void Test1()
    {
        Assert.Equal(1, FindMin([3, 4, 5, 6, 1, 2]));
    }

    [Fact]
    public void Test2()
    {
        Assert.Equal(1, FindMin([2, 3, 4, 5, 6, 1]));
    }

    [Fact]
    public void Test3()
    {
        Assert.Equal(1, FindMin([6, 1, 2, 3, 4, 5]));
    }

    [Fact]
    public void Test4()
    {
        Assert.Equal(1, FindMin([2, 3, 4, 5, 6, 1]));
    }

    [Fact]
    public void Test5()
    {
        Assert.Equal(1, FindMin([1, 2, 3, 4, 5, 6]));
    }

    [Fact]
    public void Test6()
    {
        Assert.Equal(4, FindMin([4, 5, 6, 7]));
    }

    [Fact]
    public void Test7()
    {
        Assert.Equal(1, FindMin([1]));
    }

    [Fact]
    public void Test8()
    {
        Assert.Equal(0, FindMin([4, 5, 6, 7, 0, 1, 2]));
    }
}