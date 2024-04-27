using CodePractice.Model;

namespace CodePractice.Question_0001_0099;

// Given n pairs of parentheses, write a function to generate all combinations of well-formed parentheses.
public static class Solution_Q0022
{
    static Solution_Q0022()
    {
        SolutionCalculation.Add(Level.Medium);
    }

    public static IList<string> GenerateParenthesis(int n)
    {
        var result = new List<string>();
        GenerateBracket(n, n, "", result);

        return result;
    }
    
    private static void GenerateBracket(int left, int right, string current, List<string> result)
    {
        if (left == 0 && right == 0)
        {
            result.Add(current);
            return;
        }

        if (left > 0)
        {
            GenerateBracket(left - 1, right, current + "(", result);
        }

        if (right > left)
        {
            GenerateBracket(left, right - 1, current + ")", result);
        }
    }
}

[TestFixture]
public class Test_Q0022
{
    [TestCase(4,
        new string[]
        {
            "(((())))", "((()()))", "((())())", "((()))()", "(()(()))", "(()()())", "(()())()", "(())(())", "(())()()",
            "()((()))", "()(()())", "()(())()", "()()(())", "()()()()"
        })]
    [TestCase(3, new string[] { "((()))", "(()())", "(())()", "()(())", "()()()" })]
    [TestCase(1, new string[] { "()" })]
    public void Test(int input, string[] output)
    {
        Solution_Q0022.GenerateParenthesis(input).Should().BeEquivalentTo(output);
    }
}