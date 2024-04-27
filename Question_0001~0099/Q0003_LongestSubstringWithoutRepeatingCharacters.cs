using CodePractice.Model;

namespace CodePractice.Question_0001_0099;

// Given a string, find the length of the longest substring without repeating characters.
public static class Solution_Q0003 
{
    static Solution_Q0003()
    {
        SolutionCalculation.Add(Level.Medium);
    }
    
    public static int LengthOfLongestSubstring(string s)
    {
        if(s.Length == 1)
            return 1;
        int left = 0, right = 1, maxLength = 0;
        while (right < s.Length)
        {
            for(var i = left; i < right; i++)
            {
                if(s[i] == s[right])
                {
                    left = i + 1;
                }
            }
            maxLength = Math.Max(maxLength, right - left + 1);
            right++;
        }
        return maxLength;
    }
}

[TestFixture]
public class Test_Q0003
{
    [TestCase("abcabcbb", 3)]
    [TestCase("bbbbb", 1)]
    [TestCase("pwwkew", 3)]
    public void Test(string str, int result)
    {
        Solution_Q0003.LengthOfLongestSubstring(str).Should().Be(result);
    }
}