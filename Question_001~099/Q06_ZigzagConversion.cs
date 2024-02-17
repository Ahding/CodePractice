using System.Text;

namespace CodePractice.Question_001_099;

public class Solution_Q6 {
    public string Convert(string s, int numRows)
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
public class Test_Q06
{
    [TestCase("PAYPALISHIRING", 3, "PAHNAPLSIIGYIR")]
    [TestCase("PAYPALISHIRING", 4, "PINALSIGYAHRPI")]
    [TestCase("A", 1, "A")]
    public void Test(string input, int length, string output)
    {
        new Solution_Q6().Convert(input, length).Should().Be(output);
    }
}