using System.Diagnostics;

namespace neetcode
{
    public class StringWrap
    {
        public string Value { get; set; }

        public StringWrap(string value)
        {
            Value = value;
        }

        public override int GetHashCode()
        {
            int hash = 17;
            foreach (var chr in Value)
            {
                hash = hash ^ chr.GetHashCode(); 
            }
            return hash;
        }

        public override bool Equals(object? obj)
        {
            return IsAnagramPerf(((StringWrap)obj).Value, Value);
        }

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

        public static implicit operator StringWrap(string str) => new StringWrap(str);
    }

    public class AnagramGroups
    {
        public List<List<string>> GroupAnagrams(string[] strs)
        {
            var baseAnagramToWord = new Dictionary<StringWrap, List<string>>();
            foreach (var str in strs)
            {
                if (baseAnagramToWord.TryGetValue(str, out var innerList))
                    innerList.Add(str);
                else
                    baseAnagramToWord[str] = new List<string>(){str};
            }

            return baseAnagramToWord.Select(x => x.Value).ToList();
        }

        [Fact]
        public void AnagramGroupsTest()
        {
            var input = new[] { "act", "pots", "tops", "cat", "stop", "hat" };
            var result = GroupAnagrams(input);
            Assert.Equal("act", result[0][0]);
            Assert.Equal("cat", result[0][1]);
        }

        [Fact]
        public void Test()
        {
            var act = new StringWrap("act");
            var cat = new StringWrap("cat");

            Assert.Equal(act.GetHashCode(), cat.GetHashCode());
        }

        [Fact]
        public void Test2()
        {
            var act = new StringWrap("eeacet").GetHashCode();
            var cat = new StringWrap("cateee").GetHashCode();

            Assert.Equal(act.GetHashCode(), cat.GetHashCode());
        }

        [Fact]
        public void Test3()
        {
            var ac = new StringWrap("ac").GetHashCode();
            var bb = new StringWrap("bb").GetHashCode();

            Assert.NotEqual(ac.GetHashCode(), bb.GetHashCode());
        }
    }
}