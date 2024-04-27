using CodePractice.Model;

namespace CodePractice.Question_0001_0099;

// Given a string containing digits from 2-9 inclusive, return all possible letter combinations that the number could represent.
// Return the answer in any order.
// A mapping of digit to letters (just like on the telephone buttons) is given below. Note that 1 does not map to any letters.
public static class Solution_Q0017
{
    static Solution_Q0017()
    {
        SolutionCalculation.Add(Level.Medium);
    }
    
    public static IList<string> LetterCombinations(string digits)
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

    private static List<string> _GetValue(char value)
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
        Solution_Q0017.LetterCombinations(input).Should().BeEquivalentTo(output.ToList());
    }
}