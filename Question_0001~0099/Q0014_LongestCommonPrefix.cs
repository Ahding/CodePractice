using CodePractice.Model;

namespace CodePractice.Question_0001_0099;

// Write a function to find the longest common prefix string amongst an array of strings.
// If there is no common prefix, return an empty string "".
public static class Solution_Q0014
{
    static Solution_Q0014()
    {
        SolutionCalculation.Add(Level.Easy);
    }
    
    public static string LongestCommonPrefix(string[] strs)
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
public class Test_Q0014
{
    [TestCase(new []{"reflower","flow","flight"}, "")]
    [TestCase(new []{"flower","flow","flight"}, "fl")]
    [TestCase(new []{"dog","racecar","car"}, "")]
    public void Test(string[] input, string output)
    {
        Solution_Q0014.LongestCommonPrefix(input).Should().Be(output);
    }
}