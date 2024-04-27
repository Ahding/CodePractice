using CodePractice.Model;

namespace CodePractice.Question_0001_0099;

// Roman numerals are represented by seven different symbols: I, V, X, L, C, D and M.
// Symbol       Value
// I            1
// V            5
// X            10
// L            50
// C            100
// D            500
// M            1000
// For example, 2 is written as II in Roman numeral, just two one's added together.
// 12 is written as XII, which is simply X + II.
// The number 27 is written as XXVII, which is XX + V + II.
// Roman numerals are usually written largest to smallest from left to right.
// However, the numeral for four is not IIII. Instead, the number four is written as IV.
// Because the one is before the five we subtract it making four.
// The same principle applies to the number nine, which is written as IX.
// There are six instances where subtraction is used:
// - I can be placed before V (5) and X (10) to make 4 and 9.
// - X can be placed before L (50) and C (100) to make 40 and 90.
// - C can be placed before D (500) and M (1000) to make 400 and 900.
// Given an integer, convert it to a roman numeral.
public static class Solution_Q0012
{
    static Solution_Q0012()
    {
        SolutionCalculation.Add(Level.Medium);
    }
    
    public static string IntToRoman(int num)
    {
        return _GetRoman(num / 1000, "M", null, null) +
               _GetRoman(num / 100 % 10, "C", "D", "M") +
               _GetRoman(num / 10 % 10, "X", "L", "C") +
               _GetRoman(num % 10, "I", "V", "X");
    }

    private static string _GetRoman(int singleNum, string one, string five, string ten)
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
public class Test_Q0012
{
    [TestCase(3, "III")]
    [TestCase(58, "LVIII")]
    [TestCase(1994, "MCMXCIV")]
    public void Test(int input, string output)
    {
        Solution_Q0012.IntToRoman(input).Should().Be(output);
    }
}