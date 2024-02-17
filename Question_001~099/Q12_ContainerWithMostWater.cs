namespace CodePractice.Question_001_099;

public class Solution_Q12
{
    public string IntToRoman(int num)
    {
        return _GetRoman(num / 1000, "M", null, null) +
               _GetRoman(num / 100 % 10, "C", "D", "M") +
               _GetRoman(num / 10 % 10, "X", "L", "C") +
               _GetRoman(num % 10, "I", "V", "X");
    }

    private string _GetRoman(int singleNum, string one, string five, string ten)
    {
        return singleNum switch
        {
            0 => "",
            1 => one,
            2 => $"{one}{one}",
            3 => $"{one}{one}{one}",
            4 => $"{one}{five}",
            5 => five,
            6 => $"{five}{one}",
            7 => $"{five}{one}{one}",
            8 => $"{five}{one}{one}{one}",
            9 => $"{one}{ten}"
        };
    }
}

[TestFixture]
public class Test_Q12
{
    [TestCase(3, "III")]
    [TestCase(58, "LVIII")]
    [TestCase(1994, "MCMXCIV")]
    public void Test(int input, string output)
    {
        new Solution_Q12().IntToRoman(input).Should().Be(output);
    }
}