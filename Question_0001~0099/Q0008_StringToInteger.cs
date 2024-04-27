using CodePractice.Model;

namespace CodePractice.Question_0001_0099;

// Implement the myAtoi(string s) function, which converts a string to a 32-bit signed integer (similar to C/C++'s atoi function).
// The algorithm for myAtoi(string s) is as follows:
// 1. Read in and ignore any leading whitespace.
// 2. Check if the next character (if not already at the end of the string) is '-' or '+'. Read this character in if it is either.
//    This determines if the final result is negative or positive respectively. Assume the result is positive if neither is present.
// 3. Read in next the characters until the next non-digit character or the end of the input is reached. The rest of the string is ignored.
// 4. Convert these digits into an integer (i.e. "123" -> 123, "0032" -> 32). If no digits were read, then the integer is 0.
//    Change the sign as necessary (from step 2).
// 5. If the integer is out of the 32-bit signed integer range [-2^31, 2^31 - 1], then clamp the integer so that it remains in the range.
//    Specifically, integers less than -2^31 should be clamped to -2^31, and integers greater than 2^31 - 1 should be clamped to 2^31 - 1.
// 6. Return the integer as the final result.
public static class Solution_Q0008 
{
    static Solution_Q0008()
    {
        SolutionCalculation.Add(Level.Medium);
    }

    public static int MyAtoi(string s)
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
public class Test_Q0008
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
        Solution_Q0008.MyAtoi(input).Should().Be(output);
    }
}