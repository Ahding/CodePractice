namespace CodePractice.Question_001_099;

public class Solution_Q13
{
    public int RomanToInt(string s)
    {
        var result = 0;
        var previousNum = 0;
        foreach (var c in s)
        {
            var ic = c switch
            {
                'I' => 1,
                'V' => 5,
                'X' => 10,
                'L' => 50,
                'C' => 100,
                'D' => 500,
                'M' => 1000,
            };

            if (previousNum < ic)
            {
                result -= 2 * previousNum;
            }
            result += ic;
            previousNum = ic;
        }

        return result;
    }
}

[TestFixture]
public class Test_Q13
{
    [TestCase("III", 3)]
    [TestCase("LVIII", 58)]
    [TestCase("MCMXCIV", 1994)]
    public void Test(string input, int output)
    {
        new Solution_Q13().RomanToInt(input).Should().Be(output);
    }
}