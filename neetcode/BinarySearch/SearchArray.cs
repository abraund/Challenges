namespace Neetcode.BinarySearch;

public class SearchArraySolution
{
    //note the special characters, clever from leetcode guy,
    //he stop you using a stack to solve this problem and ensures it's a two pointer problem

    public int Search(int[] nums, int target)
    {
        var l = 0;
        var r = nums.Length - 1;

        while (l <= r)
        {
            var m = l + ((r - l) / 2);

            if (nums[m] > target)
                r = m - 1;
            else if (nums[m] < target)
                l = m + 1;
            else
                return m;
        }

        return - 1;
    }

    [Fact]
    public void Test1()
    {
        Assert.Equal(3, Search([-1, 0, 2, 4, 6, 8], 4));
    }
    
    [Fact]
    public void Test2()
    {
        Assert.Equal(-1, Search([-1, 0, 2, 4, 6, 8], 3));
    }
    
}