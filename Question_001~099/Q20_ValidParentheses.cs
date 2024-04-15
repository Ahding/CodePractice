namespace CodePractice.Question_001_099;

public class Solution_Q20
{
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
public class Test_Q20
{
    [TestCase("()", true)]
    [TestCase("()[]{}", true)]
    [TestCase("(]", false)]
    [TestCase("{[]}", true)]
    [TestCase("([)]", false)]
    public void Test(string input, bool output)
    {
        new Solution_Q20().IsValid(input).Should().Be(output);
    }
}