namespace neetcode
{
    public class DuplicateInteger
    {
        public bool HasDuplicate(int[] nums)
        {
            var hash = new HashSet<int>();
            foreach (var num in nums)
            {
                if (hash.Contains(num))
                    return true;
                hash.Add(num);
            }

            return false;
        }

        [Fact]
        public void AscendingNumbersWithDuplicate()
        {
            var nums = new[] { 1, 2, 3, 3 };
            Assert.True(HasDuplicate(nums));
        }

        [Fact]
        public void MixedNumbersNoDuplicate()
        {
            var nums = new[] { 1, 2, 3, 4 };
            Assert.False(HasDuplicate(nums));
        }

        [Fact]
        public void MixedNumbersWithDuplicate()
        {
            var nums = new[] { 1, 2, 3, 3 };
            Assert.True(HasDuplicate(nums));
        }
    }
}