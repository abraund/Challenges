namespace Neetcode.SlidingWindow;

public class SlidingWindowMaximum
{
    public int[] MaxSlidingWindow(int[] nums, int k)
    {
        var result = new int[nums.Length - k + 1];
        var r = 0;
        var l = () => r - k + 1;
        var deque = new LinkedList<int>();

        while (r < nums.Length)
        {
            while (deque.Any() && deque.Last() < nums[r])
                deque.RemoveLast();

            deque.AddLast(nums[r]);

            if (r + 1 >= k)
            {
                result[l()] = deque.First();

                if (deque.First() == nums[l()])
                    deque.RemoveFirst();
            }

            r++;
        }

        return result;
    }

    [Fact]
    public void Test1()
    {
        Assert.Equal([2, 2, 4, 4, 6], MaxSlidingWindow([1, 2, 1, 0, 4, 2, 6], 3));
    }

    [Fact]
    public void Test2()
    {
        Assert.Equal([1, -1], MaxSlidingWindow([1, -1], 1));
    }
}