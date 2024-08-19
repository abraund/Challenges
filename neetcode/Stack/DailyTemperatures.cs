namespace Neetcode.Stack;

public class DailyTemperaturesSolution
{
    public int[] DailyTemperatures(int[] temperatures)
    {
        var result = new int[temperatures.Length];
        var decreasingTemps = new Stack<(int Temperature, int Position)>();

        for (int i = 0; i < temperatures.Length; i++)
        {
            while (decreasingTemps.Any() && temperatures[i] > decreasingTemps.Peek().Temperature)
            {
                var lowerTemp = decreasingTemps.Pop();
                result[lowerTemp.Position] = i - lowerTemp.Position;
            }

            decreasingTemps.Push((temperatures[i], i));
        }

        return result;
    }

    [Fact]
    public void Test1()
    {
        Assert.Equal([1, 4, 1, 2, 1, 0, 0], DailyTemperatures([30, 38, 30, 36, 35, 40, 28]));
    }

    [Fact]
    public void Test2()
    {
        Assert.Equal([0, 0, 0], DailyTemperatures([22, 21, 20]));
    }

}