namespace Neetcode.BinarySearch;

public class SearchMatrixSolution
{
    //note the special characters, clever from leetcode guy,
    //he stop you using a stack to solve this problem and ensures it's a two pointer problem

    public bool SearchMatrix(int[][] matrix, int target)
    {
        var l = 0;
        var r = matrix.Length - 1;

        while (l <= r)
        {
            var m = l + ((r - l) / 2);
            var found = matrix[m];

            if (found[found.Length-1] < target)
                l = m + 1;
            else if (found[0] > target)
                r = m - 1;
            else
            {
                l = 0;
                r = found.Length - 1;
                while (l <= r)
                {
                    m = l + ((r - l) / 2);
                    var innerFound = found[m];

                    if (innerFound < target)
                        l = m + 1;
                    else if (innerFound > target)
                        r = m - 1;
                    else
                        return true;

                }

                return false;
            }
        }

        return false;
    }

    [Fact]
    public void Test1()
    {
        Assert.Equal(true, SearchMatrix([[1, 2, 4, 8], [10, 11, 12, 13], [14, 20, 30, 40]], 4));
    }
    
    [Fact]
    public void Test2()
    {
        Assert.Equal(false, SearchMatrix([[1, 2, 4, 8], [10, 11, 12, 13], [14, 20, 30, 40]], 15));
    }
    
}