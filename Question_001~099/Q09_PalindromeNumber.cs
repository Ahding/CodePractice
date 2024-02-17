using System.Text;

namespace CodePractice.Question_001_099;

public class Solution_Q9 {
    public bool IsPalindrome(int x)
    {
        if (x < 0) return false;

        var s = x.ToString();
        for (var i = 0; i < s.Length; i++)
        {
            if (s[i] != s[s.Length - 1 - i])
            {
                return false;
            }
        }

        return true;
    }
}

[TestFixture]
public class Test_Q09
{
    [TestCase(121, true)]
    [TestCase(-121, false)]
    [TestCase(10, false)]
    public void Test(int input, bool output)
    {
        new Solution_Q9().IsPalindrome(input).Should().Be(output);
    }
}