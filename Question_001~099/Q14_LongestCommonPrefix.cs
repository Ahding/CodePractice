namespace CodePractice.Question_001_099;

public class Solution_Q14
{
    public string LongestCommonPrefix(string[] strs)
    {
        var prefix = "";
        for (var i = 0; i < strs[0].Length; i++)
        {
            foreach (var str in strs)
            {
                if (str.Length < i + 1 || str[i] != strs[0][i])
                {
                    return prefix;
                }
            }
            prefix += strs[0][i];
        }

        return prefix;
    }
}

[TestFixture]
public class Test_Q14
{
    [TestCase(new []{"reflower","flow","flight"}, "")]
    [TestCase(new []{"flower","flow","flight"}, "fl")]
    [TestCase(new []{"dog","racecar","car"}, "")]
    public void Test(string[] input, string output)
    {
        new Solution_Q14().LongestCommonPrefix(input).Should().Be(output);
    }
}