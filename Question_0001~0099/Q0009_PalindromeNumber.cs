using System.Text;
using CodePractice.Model;

namespace CodePractice.Question_0001_0099;

// Given an integer x, return true if x is a palindrome, and false otherwise.
public static class Solution_Q0009 
{
    static Solution_Q0009()
    {
        SolutionCalculation.Add(Level.Easy);
    }

    public static bool IsPalindrome(int x)
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
public class Test_Q0009
{
    [TestCase(121, true)]
    [TestCase(-121, false)]
    [TestCase(10, false)]
    public void Test(int input, bool output)
    {
        Solution_Q0009.IsPalindrome(input).Should().Be(output);
    }
}