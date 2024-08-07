using System.Diagnostics;

namespace neetcode
{
    public class AnagramGroups
    {
        public List<List<string>> GroupAnagrams(string[] strs)
        {
            var baseAnagramToWord = new Dictionary<string, List<string>>();
            foreach (var str in strs)
            {
                var sorted = string.Join("", str.OrderBy(x => x));
                if (baseAnagramToWord.TryGetValue(sorted, out var innerList))
                {
                    innerList.Add(str);
                }
                else
                {
                    baseAnagramToWord[sorted] = new List<string>(){str};
                }
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
    }
}