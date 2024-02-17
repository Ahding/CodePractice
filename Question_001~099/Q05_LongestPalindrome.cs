namespace CodePractice.Question_001_099;

public class Solution_Q5
{
    private int _maxLength;
    private string _result = "";
    
    public string LongestPalindrome(string s)
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

    private void CheckPalindrome(string s, int i, bool isDouble)
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
public class Test_Q05
{
    [TestCase("abcdefe", "efe")]
    [TestCase("babad", "bab")]
    [TestCase("cbbd", "bb")]
    public void Test(string input, string output)
    {
        new Solution_Q5().LongestPalindrome(input).Should().Be(output);
    }
}