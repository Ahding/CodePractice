namespace CodePractice.Question_001_099;

public class Solution_Q22
{
    public IList<string> GenerateParenthesis(int n)
    {
        var result = new List<string>();
        GenerateBracket(n, n, "", result);

        return result;
    }
    
    private void GenerateBracket(int left, int right, string current, List<string> result)
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
public class Test_Q22
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
        new Solution_Q22().GenerateParenthesis(input).Should().BeEquivalentTo(output);
    }
}