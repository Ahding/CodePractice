using System.Text;

namespace CodePractice.Question_001_099;

public class Solution_Q7 {
    public int Reverse(int x)
    {
        return x > 0 
            ? _ReversePositive(x)
            : x == int.MinValue
                ? 0
                : 0 - _ReversePositive(0 - x) ;
    }

    private int _ReversePositive(int x, int y = 0)
    {
        return x > 9 
            ? _ReversePositive(x / 10, y * 10 + x % 10) 
            : y > int.MaxValue / 10
                ? 0 
                : y * 10 + x; 
    }
}

[TestFixture]
public class Test_Q07
{
    [TestCase(123, 321)]
    [TestCase(-123, -321)]
    [TestCase(120, 21)]
    [TestCase(1534236469, 0)]
    [TestCase(-2147483648, 0)]
    public void Test(int input, int output)
    {
        new Solution_Q7().Reverse(input).Should().Be(output);
    }
}