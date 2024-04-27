using CodePractice.Model;

namespace CodePractice.Question_0001_0099;

// Given a string s containing just the characters '(', ')', '{', '}', '[' and ']', determine if the input string is valid.
// An input string is valid if:
// Open brackets must be closed by the same type of brackets.
// Open brackets must be closed in the correct order.
// Every close bracket has a corresponding open bracket of the same type.
public class Solution_Q0020
{
    static Solution_Q0020()
    {
        SolutionCalculation.Add(Level.Easy);
    }

    public bool IsValid(string s)
    {
        var keys = new Dictionary<char, char>
        {
            { '(', ')' },
            { '[', ']' },
            { '{', '}' },
            { ')', 'n' },
            { ']', 'n' },
            { '}', 'n' }
        };

        var exist = new List<char>();
        foreach (var c in s)
        {
            if (exist.Count > 0 && c == exist[^1])
            {
                exist.RemoveAt(exist.Count - 1);
                continue;
            }
            
            if (keys.TryGetValue(c, out var key))
            {
                exist.Add(key);
            }
        }

        return exist.Count == 0;
    }
}

[TestFixture]
public class Test_Q0020
{
    [TestCase("()", true)]
    [TestCase("()[]{}", true)]
    [TestCase("(]", false)]
    [TestCase("{[]}", true)]
    [TestCase("([)]", false)]
    public void Test(string input, bool output)
    {
        new Solution_Q0020().IsValid(input).Should().Be(output);
    }
}