using System.Diagnostics;

namespace neetcode
{
    public class TopKElementsInList
    {
        public int[] TopKFrequent(int[] nums, int k)
        {
            var numToCount = new Dictionary<int, int>();
            
            foreach (var num in nums)
            {
                if (numToCount.TryGetValue(num, out var count))
                    numToCount[num] = ++count;
                else
                    numToCount[num] = count = 1;
            }

            var sortedCounts = new SortedSet<(int num, int count)>(
                Comparer<(int num, int count)>.Create((a, b) => b.count - a.count == 0 ? a.num - b.num : b.count - a.count));

            foreach (var entry in numToCount)
                sortedCounts.Add((entry.Key, entry.Value));

            return sortedCounts.Take(k).Select(x => x.num).ToArray();
        }

        [Fact]
        public void TopKTest()
        {
            var result = TopKFrequent([1, 2, 2, 3, 3, 3], 2);
            Assert.Equal([3, 2], result);
        }
    }
}