namespace Neetcode.BinarySearch;

public class FindTargetInRotatedSortedArray
{
    public int Search(int[] nums, int target)
    {
        var l = 0;
        var r = nums.Length - 1;

        while (l <= r)
        {
            var m = (l + r) / 2;

            if (nums[m] == target)
                return m;

            if (nums[l] == nums[r])
                return -1;

            if (nums[l] < nums[m] && target >= nums[l] && target < nums[m]) // upward slope & contained
                r = m;
            else if (nums[m] < nums[r] && target > nums[m] && target <= nums[r]) // upwarde slope & contained
                l = m + 1;
            else if (nums[l] > nums[m]) // downward slope
                r = m;
            else if (nums[m] > nums[r]) // downward slope
                l = m + 1;
            else if (target < nums[m])
                r = m;
            else if(target > nums[m])
                l = m + 1;

        }

        return -1;
    }

    [Fact]
    public void Test1()
    {
        Assert.Equal(4, Search([3, 4, 5, 6, 1, 2], 1));
    }

    [Fact]
    public void Test2()
    {
        Assert.Equal(-1, Search([3, 5, 6, 0, 1, 2], 4));
    }

    [Fact]
    public void Test3()
    {
        Assert.Equal(4, Search([4, 5, 6, 7, 0, 1, 2], 0));
    }

    [Fact]
    public void Test4()
    {
        Assert.Equal(4, Search([4, 5, 6, 7, 0, 1, 2], 0));
    }

    [Fact]
    public void Test5()
    {
        Assert.Equal(0, Search([3, 5, 1], 3));
    }
}