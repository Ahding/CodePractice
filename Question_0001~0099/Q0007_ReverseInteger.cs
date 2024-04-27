using CodePractice.Model;

namespace CodePractice.Question_0001_0099;

// Given a 32-bit signed integer, reverse digits of an integer.
// If reversing x causes the value to go outside the signed 32-bit integer range [-2^31, 2^31 - 1], then return 0.
public static class Solution_Q0007 
{
    static Solution_Q0007()
    {
        SolutionCalculation.Add(Level.Medium);
    }

    public static int Reverse(int x)
    {
        return x > 0 
            ? _ReversePositive(x)
            : x == int.MinValue
                ? 0
                : 0 - _ReversePositive(0 - x) ;
    }

    private static int _ReversePositive(int x, int y = 0)
    {
        return x > 9 
            ? _ReversePositive(x / 10, y * 10 + x % 10) 
            : y > int.MaxValue / 10
                ? 0 
                : y * 10 + x; 
    }
}

[TestFixture]
public class Test_Q0007
{
    [TestCase(123, 321)]
    [TestCase(-123, -321)]
    [TestCase(120, 21)]
    [TestCase(1534236469, 0)]
    [TestCase(-2147483648, 0)]
    public void Test(int input, int output)
    {
        Solution_Q0007.Reverse(input).Should().Be(output);
    }
}