namespace Neetcode.BinarySearch
{
    public class TimeMap
    {
        private Dictionary<string, SortedDictionary<int, string>> _personToTimeToValue;
        private Dictionary<string, SortedSet<int>> _personToTimes;

        public TimeMap()
        {
            _personToTimeToValue = new Dictionary<string, SortedDictionary<int, string>>();
            _personToTimes = new Dictionary<string, SortedSet<int>>();
        }

        public void Set(string key, string value, int timestamp)
        {
            if (_personToTimeToValue.TryGetValue(key, out var person))
            {
                person[timestamp] = value;
                _personToTimes[key].Add(timestamp);
            }
            else
            {
                _personToTimeToValue[key] = new SortedDictionary<int, string>() { { timestamp, value } };
                _personToTimes[key] = new SortedSet<int>() { timestamp };

            }
        }

        public string Get(string key, int timestamp)
        {
            if (_personToTimes.TryGetValue(key, out var timestamps))
            {
                var almostValidTimeStamp = _personToTimes[key].GetViewBetween(0, timestamp).Max;
                if (almostValidTimeStamp == 0)
                    return "";

                return _personToTimeToValue[key][almostValidTimeStamp];
            }

            return "";
        }


        [Fact]
        public void Test1()
        {
            TimeMap timeMap = new TimeMap();
            timeMap.Set("alice", "happy", 1);
            Assert.Equal("happy", timeMap.Get("alice", 1));
            Assert.Equal("happy", timeMap.Get("alice", 2));
            timeMap.Set("alice", "sad", 3);
            Assert.Equal("sad", timeMap.Get("alice", 3));
        }

        [Fact]
        public void Test2()
        {
            TimeMap timeMap = new TimeMap();
            timeMap.Set("key1", "value1", 10);
            Assert.Equal(null, timeMap.Get("key1", 1));
            Assert.Equal("value1", timeMap.Get("key1", 10));
            Assert.Equal("value1", timeMap.Get("key1", 11));
        }

    }
}
