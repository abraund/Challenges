namespace Neetcode.BinarySearch
{
    public class MedianOfTwoSortedArrays
    {
        // need to think less about m, and more about the partion,
        // what does m + n represent, the left partition? is it inclusive, is it not?

        public double FindMedianSortedArrays(int[] arr1, int[] arr2)
        {
            var lit = arr1.Length < arr2.Length ? arr1 : arr2;
            var big = arr2.Length > arr1.Length ? arr2 : arr1;

            var l = 0;
            var r = lit.Length - 1;
            var halfLength = (lit.Length + big.Length) / 2; // 4:3->3, 4:4->4

            while (true)
            {
                var m = (l + r) / 2; // 4:3->1 (equal, other side should take 2), 3:3->1 (little is greedy)
                var n = halfLength - m - 1; // 4:3->2 (too much), 4:4->2 (too much)

                // x x _ _ / x x x _
                // x x _ _ / x _ _
                // x x _ / x _
                // x x _ / x _ _

                var l1 = lit[m];
                var l2 = lit[m + 1];
                var r1 = lit[n - 1];
                var r2 = lit[n];


                if (l1 < r1 && l1 > r2)
                    return l1;

                if (r1 > l1 && r1 < l2)
                    return r1;
            }
        }

        [Fact]
        public void Test2()
        {
            //Assert.Equal(1, FindMedianSortedArrays([1, 2, 3, 4], [3, 4, 5]));
            Assert.Equal(1, FindMedianSortedArrays([1, 2, 3, 4], [2, 3, 4, 5]));
        }

        [Fact]
        public void Test2a()
        {
            Assert.Equal(1, FindMedianSortedArrays([1, 2, 3, 4], [3, 4, 5]));
            //Assert.Equal(1, FindMedianSortedArrays([1, 2, 3, 4], [2, 3, 4, 5]));
        }

        [Fact]
        public void Test1()
        {
            Assert.Equal(1, FindMedianSortedArrays([1, 2], [3]));
        }

        [Fact]
        public void Test3()
        {
            Assert.Equal(1, FindMedianSortedArrays([1, 2], [3, 4, 5, 6, 7, 8, 9, 10]));
        }
    }
}
