using System.Text.RegularExpressions;

namespace CodePractice.Question_001_099;

public class Solution_Q10 {
    public bool IsMatch(string s, string p)
    {
        p = Regex.Replace(p, "\\*+", "*");
        return Regex.IsMatch(s, "^" + p + "$");
    }
}

[TestFixture]
public class Test_Q10
{
    [TestCase("aa", "a", false)]
    [TestCase("aa", "a*", true)]
    [TestCase("ab", ".*", true)]
    [TestCase("abc", "a***abc", true)]
    [TestCase("abt", "a.t", true)]
    [TestCase("aab", "c*a*b", true)]
    public void Test(string input, string regex, bool output)
    {
        new Solution_Q10().IsMatch(input, regex).Should().Be(output);
    }
}