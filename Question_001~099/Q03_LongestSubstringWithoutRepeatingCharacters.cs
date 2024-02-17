namespace CodePractice.Question_001_099;

public class Solution_Q3 {
    public int LengthOfLongestSubstring(string s)
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
public class Test_Q03
{
    [TestCase("abcabcbb", 3)]
    [TestCase("bbbbb", 1)]
    [TestCase("pwwkew", 3)]
    public void Test(string str, int result)
    {
        new Solution_Q3().LengthOfLongestSubstring(str).Should().Be(result);
    }
}