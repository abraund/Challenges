namespace neetcode;

public class BuyAndSellCrypto
{
    public int MaxProfit(int[] prices)
    {
        var maxValueRightwards = new int[prices.Length];
        var currentHighValue = 0;
        for (int j = prices.Length - 1; j >= 0; j--)
        {
            var price = prices[j];
            maxValueRightwards[j] = currentHighValue = Math.Max(currentHighValue, price);
        }

        var maxProfit = 0;
        for (int i = 0; i < prices.Length; i++)
        {
            maxProfit = Math.Max(maxProfit, maxValueRightwards[i] - prices[i]);
        }
        return maxProfit;
    }

    [Fact]
    public void Test1()
    {
        Assert.Equal(6, MaxProfit([10, 1, 5, 6, 7, 1]));
    }

    [Fact]
    public void Test2()
    {
        Assert.Equal(0, MaxProfit([10, 8, 7, 5, 2]));
    }

    [Fact]
    public void Test3()
    {
        Assert.Equal(6, MaxProfit([1, 7, 1]));
    }

}