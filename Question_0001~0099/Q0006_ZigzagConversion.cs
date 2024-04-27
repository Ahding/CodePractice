using System.Text;
using CodePractice.Model;

namespace CodePractice.Question_0001_0099;

// The string "PAYPALISHIRING" is written in a zigzag pattern on a given number of rows like this:
// (you may want to display this pattern in a fixed font for better legibility)
// P   A   H   N
// A P L S I I G
// Y   I   R
// And then read line by line: "PAHNAPLSIIGYIR"
// Write the code that will take a string and make this conversion given a number of rows:
// string convert(string s, int numRows);
public static class Solution_Q0006 
{
    static Solution_Q0006()
    {
        SolutionCalculation.Add(Level.Medium);
    }

    public static string Convert(string s, int numRows)
    {
        if (numRows == 1)
        {
            return s;
        }
        
        var rows = new List<string>();
        for (var i = 0; i < s.Length; i++)
        {
            if (i == 0 || (i - 1) / (numRows - 1) == 0)
            {
                rows.Add("");
            }
            
            if (i / (numRows - 1) % 2 == 0)
            {
                rows[i % (numRows - 1)] += s[i];
            }
            else
            {
                rows[numRows - 1 - i % (numRows - 1)] += s[i];
            }
        }

        var result = "";
        foreach (var value in rows)
        {
            result += value;
        }
        return result;
    }
}

[TestFixture]
public class Test_Q0006
{
    [TestCase("PAYPALISHIRING", 3, "PAHNAPLSIIGYIR")]
    [TestCase("PAYPALISHIRING", 4, "PINALSIGYAHRPI")]
    [TestCase("A", 1, "A")]
    public void Test(string input, int length, string output)
    {
        Solution_Q0006.Convert(input, length).Should().Be(output);
    }
}