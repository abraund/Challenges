using System.Collections.Immutable;
using System.Reflection.Metadata.Ecma335;

namespace Neetcode.Stack;

public class CarFleetSolution
{
    public int CarFleet(int target, int[] position, int[] speed)
    {
        var result = 0;
        var carsByPosition = new List<(int Position, int TargetTime)>();

        for (int i = 0; i < position.Length; i++)
        {
            var turnsToTarget = (int)Math.Ceiling((target - position[i]) / (double)speed[i]);
            carsByPosition.Add((position[i], turnsToTarget));
        }

        carsByPosition = carsByPosition.OrderByDescending(x => x.Position).ToList();

        var lastFleetTime = 0;
        foreach (var laterCar in carsByPosition)
        {
            if (laterCar.TargetTime > lastFleetTime)
            {
                result++;
                lastFleetTime = laterCar.TargetTime;
            }
        }

        return result;
    }

    [Fact]
    public void Test1()
    {
        Assert.Equal(1, CarFleet(10, [1,4], [3,2]));
    }

    [Fact]
    public void Test2()
    {
        Assert.Equal(3, CarFleet(10, [4, 1, 0, 7], [2, 2, 1, 1]));
    }

    [Fact]
    public void Test3()
    {
        Assert.Equal(3, CarFleet(12, [10, 8, 0, 5, 3], [2, 4, 1, 1, 3]));
    }

    [Fact]
    public void Test4()
    {
        Assert.Equal(1, CarFleet(12, [10], [10]));
    }

    [Fact]
    public void Test5()
    {
        Assert.Equal(0, CarFleet(12, [], []));
    }
}