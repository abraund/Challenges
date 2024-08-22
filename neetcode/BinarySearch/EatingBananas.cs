namespace Neetcode.BinarySearch;

public class EatingBananas
{
    public int MinEatingSpeed(int[] piles, int h)
    {
        var result = int.MaxValue;

        for (int k = 1; k <= 1_000_000; k++)
        {
            var timeToEat = 0;
            foreach (var pile in piles)
                timeToEat += (pile / k) + (pile % k > 0 ? 1 : 0);

            if (timeToEat <= h)
                result = Math.Min(k, result);
        }

        return result;
    }

    public int MinEatingSpeedBinChop(int[] piles, int h)
    {
        var result = int.MaxValue;

        var l = 1;
        var r = 1_000_000;

        while (l <= r)
        {
            var m = l + ((r - l) / 2);

            var timeToEat = 0;
            foreach (var pile in piles)
                timeToEat += (pile / m) + (pile % m > 0 ? 1 : 0);

            if (timeToEat <= h)
            {
                r = m - 1;
                result = Math.Min(m, result);
            }
            else if (timeToEat > h)
                l = m + 1;
        }

        return result;
    }

    [Fact]
    public void Test1()
    {
        Assert.Equal(2, MinEatingSpeedBinChop([1, 4, 3, 2], 9));
    }

    [Fact]
    public void Test2()
    {
        Assert.Equal(25, MinEatingSpeedBinChop([25, 10, 23, 4], 4));
    }

}