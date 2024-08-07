namespace neetcode
{
    public class IsAnagram
    {
        public bool IsAnagramPerf(string s, string t)
        {
            // O(s+t)
            var charCount = new Dictionary<char, int>();
            foreach (var c in s)
            {
                if (charCount.ContainsKey(c))
                    charCount[c]++;
                else
                    charCount[c] = 1;
            }

            foreach (var c in t)
            {
                if (charCount.ContainsKey(c))
                    charCount[c]--;
                else
                    return false;
            }

            foreach (var c in charCount)
            {
                if (c.Value != 0)
                    return false;
            }

            return true;
        }

        public bool IsAnagramMem(string s, string t)
        {
            // O(1)-ish
            // nLogn on perf, some sorting algorithms O(1): they cost memory but it doesn't grow with s & t
            // on the other hand some sorting algorithms do grow, so it may be worth writing one by hand
            return s.OrderBy(x => x).ToString() == t.OrderBy(x => x).ToString();
        }


        [Fact]
        public void Racecar()
        {
            Assert.True(IsAnagramPerf("racecar", "carrace"));
            Assert.True(IsAnagramMem("racecar", "carrace"));
        }

        [Fact]
        public void Jar()
        {
            Assert.False(IsAnagramPerf("jar", "jam"));
            Assert.False(IsAnagramMem("jar", "jam"));
        }

        [Fact]
        public void Superset()
        {
            Assert.False(IsAnagramPerf("superset", "super"));
            Assert.False(IsAnagramMem("superset", "super"));
        }
    }
}