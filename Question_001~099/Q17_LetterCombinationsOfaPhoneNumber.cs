namespace CodePractice.Question_001_099;

public class Solution_Q17
{
    public IList<string> LetterCombinations(string digits)
    {
        var result = new List<string>();
        foreach (var digit in digits)
        {
            var temp = new List<string>();
            var newValues = _GetValue(digit);
            if (result.Count == 0)
            {
                temp = newValues;
            }
            else
            {
                foreach (var oldValue in result)
                {
                    foreach (var newValue in newValues)
                    {
                        temp.Add(oldValue + newValue);
                    }
                }
            }
            
            result = temp;
        }
        
        return result;
    }

    private List<string> _GetValue(char value)
        => value switch
        {
            '2' => new List<string> { "a", "b", "c" },
            '3' => new List<string> { "d", "e", "f" },
            '4' => new List<string> { "g", "h", "i" },
            '5' => new List<string> { "j", "k", "l" },
            '6' => new List<string> { "m", "n", "o" },
            '7' => new List<string> { "p", "q", "r", "s" },
            '8' => new List<string> { "t", "u", "v" },
            '9' => new List<string> { "w", "x", "y", "z" },
            _ => new List<string>()
        };
}

[TestFixture]
public class Test_Q17
{
    [TestCase("23", new []{"ad", "ae", "af", "bd", "be", "bf", "cd", "ce", "cf"})]
    [TestCase("", new string[]{})]
    [TestCase("2", new []{"a", "b", "c"})]
    public void Test(string input, string[] output)
    {
        new Solution_Q17().LetterCombinations(input).Should().BeEquivalentTo(output.ToList());
    }
}