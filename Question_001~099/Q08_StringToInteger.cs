using System.Text;

namespace CodePractice.Question_001_099;

public class Solution_Q8 {
    public int MyAtoi(string s)
    {
        var result = 0;
        var isFirst = true;
        var isMax = false;
        foreach (var c in s.Trim())
        {
            if (isFirst)
            {
                isFirst = false;
                if (c == '-' || c == '+')
                {
                    continue;
                }
            }

            
            if (int.TryParse(c.ToString(), out var i))
            {
                if (result > int.MaxValue / 10 || (result == int.MaxValue / 10 && i > int.MaxValue % 10))
                {
                    isMax = true;
                    break;
                }
                result = result * 10 + i;
            }
            else
            {
                break;
            }
        }

        return s.Trim().StartsWith('-')
            ? isMax 
                ? int.MinValue
                : result * -1 
            : isMax 
                ? int.MaxValue
                : result;
    }
}

[TestFixture]
public class Test_Q08
{
    [TestCase("42", 42)]
    [TestCase("   -42", -42)]
    [TestCase("4193 with words", 4193)]
    [TestCase("-91283472332", -2147483648)]
    [TestCase("2147483648", 2147483647)]
    [TestCase("9223372036854775808", 2147483647)]
    [TestCase("+-12", 0)]
    public void Test(string input, int output)
    {
        new Solution_Q8().MyAtoi(input).Should().Be(output);
    }
}