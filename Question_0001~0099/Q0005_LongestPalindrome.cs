using CodePractice.Model;

namespace CodePractice.Question_0001_0099;

// Given a string s, return the longest palindromic substring in s.
public static class Solution_Q0005
{
    static Solution_Q0005()
    {
        SolutionCalculation.Add(Level.Medium);
    }

    private static int _maxLength;
    private static string _result = "";
    
    public static string LongestPalindrome(string s)
    {
        _maxLength = 1;
        _result = s[0].ToString();

        for (var i = 0; i < s.Length; i++)
        {
            // single
            CheckPalindrome(s, i, false);

            // double
            CheckPalindrome(s, i, true);
        }
        return _result;
    }

    private static void CheckPalindrome(string s, int i, bool isDouble)
    {
        int l = i, r = i + (isDouble ? 1 : 0);
        while (l >= 0 && r < s.Length && s[l] == s[r])
        {
            if (r - l + 1 > _maxLength)
            {
                _maxLength = r - l + 1;
                _result = s.Substring(l, r - l + 1);
            }

            l--;
            r++;
        }
    }
}

[TestFixture]
public class Test_Q0005
{
    [TestCase("abcdefe", "efe")]
    [TestCase("babad", "bab")]
    [TestCase("cbbd", "bb")]
    public void Test(string input, string output)
    {
        Solution_Q0005.LongestPalindrome(input).Should().Be(output);
    }
}