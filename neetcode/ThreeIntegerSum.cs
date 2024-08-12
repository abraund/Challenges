namespace neetcode;

public class ThreeIntegerSum
{
    public List<List<int>> ThreeSum(int[] nums)
    {
        var result = new HashSet<(int i, int j, int k)>();

        var valueToPos = new Dictionary<int, List<int>>();

        for (var i = 0; i < nums.Length; i++)
        {
            if (valueToPos.TryGetValue(nums[i], out var value))
                value.Add(i);
            else
                valueToPos[nums[i]] = new List<int>(){i};
        }

        for (var i = 0; i < nums.Length; i++)
        {
            var iVal = nums[i];
            for (var j = i + 1; j < nums.Length; j++)
            {
                var jVal = nums[j];
                var kVal = 0 - iVal - jVal;
                if (valueToPos.TryGetValue(kVal, out var kPositions))
                {
                    if (kPositions.Any(k => k > j))
                    {
                        var tupleArray = new[] { iVal, jVal, kVal };
                        Array.Sort(tupleArray);
                        result.Add((tupleArray[0], tupleArray[1], tupleArray[2]));
                    }
                }
            }
        }

        return result.Select(x => new int[]{x.i, x.j, x.k}.ToList()).ToList();
    }

    [Fact]
    public void IncNumber()
    {
        var result = ThreeSum([-1, 0, 1, 2, -1, -4]);
        Assert.Equal([[-1, 0, 1], [-1, -1, 2]], result);
    }
}