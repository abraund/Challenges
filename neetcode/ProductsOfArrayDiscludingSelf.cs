namespace neetcode;

public class ProductsOfArrayDiscludingSelf
{
    public int[] ProductExceptSelf(int[] nums)
    {
        var result  = new int[nums.Length];

        var product = 1;
        for (var i = 0; i < nums.Length; i++)
        {
            result[i] = product;
            product *= nums[i];
        }

        product = 1;
        for (var i = nums.Length - 1; i >= 0; i--)
        {
            result[i] = result[i] * product;
            product *= nums[i];
        }
        return result;
    }

    [Fact]
    public void Ascending()
    {
        var result = ProductExceptSelf([1, 2, 4, 6]);
        Assert.Equal([48, 24, 12, 8], result);
    }

    [Fact]
    public void ContainsZero()
    {
        var result = ProductExceptSelf([-1, 0, 1, 2, 3]);
        Assert.Equal([0, -6, 0, 0, 0], result);
    }
}