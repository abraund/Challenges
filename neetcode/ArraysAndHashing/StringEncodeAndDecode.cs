using System.ComponentModel.Design;
using System.Diagnostics;
using System.Text;

namespace Neetcode.ArraysAndHashing;

public class StringEncodeAndDecode
{
    private char ESCAPE = '\\';
    private char DELIMITER = ',';

    public string Encode(IList<string> strs)
    {
        var sb = new StringBuilder();
        for (var i = 0; i < strs.Count; i++)
        {
            var str = strs[i];

            for (var j = 0; j < str.Length; j++)
            {
                var letter = str[j];

                if (letter == ESCAPE)
                    sb.Append(new[] { ESCAPE, letter });
                else if (letter == DELIMITER)
                    sb.Append(new[] { ESCAPE, letter });
                else
                    sb.Append(letter);
            }
            sb.Append(DELIMITER);
        }

        return sb.ToString();
    }

    public List<string> Decode(string s)
    {
        var result = new List<string>();
        var currentWord = new StringBuilder();
        for (var i = 0; i < s.Length; i++)
        {
            var letter = s[i];
            if (letter == ESCAPE)
            {
                currentWord.Append(s[++i]);
            }
            else if (letter == DELIMITER)
            {
                result.Add(currentWord.ToString());
                currentWord = new StringBuilder();
            }
            else
            {
                currentWord.Append(letter);
            }
        }

        return result;
    }

    [Fact]
    public void EscapedDelimitedInput()
    {
        List<string> array = ["n,eet,", ",co,de", "\\l\\ove\\", "yo\\,u"];
        var encoded = Encode(array);
        var decoded = Decode(encoded);

        Assert.Equal(array, decoded);
    }

    [Fact]
    public void EmptyString()
    {
        List<string> array = [""];
        var encoded = Encode(array);
        Assert.Equal(",", encoded);
        var decoded = Decode(encoded);
        Assert.Equal(array, decoded);
    }

    [Fact]
    public void EmptyArray()
    {
        List<string> array = [];
        var encoded = Encode(array);
        Assert.Equal("", encoded);
        var decoded = Decode(encoded);
        Assert.Equal(array, decoded);
    }
}