using CodePractice.Model;

namespace CodePractice.Question_0001_0099;

// Given an input string (s) and a pattern (p), implement regular expression matching with support for '.' and '*' where:
// '.' Matches any single character.
// '*' Matches zero or more of the preceding element.
// The matching should cover the entire input string (not partial).
public static class Solution_Q0010 
{
    static Solution_Q0010()
    {
        SolutionCalculation.Add(Level.Medium);
    }

    public static bool IsMatch(string s, string p)
    {
        var boolArrays = new bool[p.Length + 1, s.Length + 1];

        // first row: empty check for incremental string
        for (var stringIndex = 0; stringIndex < s.Length + 1; stringIndex++)
        {
            boolArrays[0, stringIndex] = stringIndex == 0;
        }
        
        // first column: incremental pattern check for string
        for (var patternIndex = 1; patternIndex < p.Length + 1; patternIndex++)
        {
            boolArrays[patternIndex, 0] = p[patternIndex - 1] == '*' && boolArrays[patternIndex - 2, 0];
        }
        
        // each pattern check for each string
        for (var patternIndex = 1; patternIndex < p.Length + 1; patternIndex++)
        {
            for (var stringIndex = 1; stringIndex < s.Length + 1; stringIndex++)
            {
                // if current pattern is '*'
                if (p[patternIndex - 1] == '*')
                {
                    // check previous pattern or previous pattern is same as current string, then check previous string
                    boolArrays[patternIndex, stringIndex] = 
                        boolArrays[patternIndex - 2, stringIndex] ||
                        ((p[patternIndex - 2] == '.' || p[patternIndex - 2] == s[stringIndex - 1]) &&
                        boolArrays[patternIndex, stringIndex - 1]);
                }
                // if current pattern is '.' or same as current string, then check previous string
                else if (p[patternIndex - 1] == '.' || p[patternIndex - 1] == s[stringIndex - 1])
                {
                    // check previous pattern and previous string
                    boolArrays[patternIndex, stringIndex] = boolArrays[patternIndex - 1, stringIndex - 1];
                }
            }
        }
        
        return boolArrays[p.Length, s.Length];
    }
    
    // try to solve with recursive
    private static string str;
    private static string pattern;
    
    public static bool IsMatchRecursive(string s, string p)
    {
        str = s;
        pattern = p;
        return GetPositionBool(s.Length, p.Length);
    }
    
    private static bool GetPositionBool(int strIndex, int patternIndex)
    {
        if (strIndex == 0 && patternIndex == 0)
        {
            return true;
        }
        
        if (patternIndex == 0)
        {
            return false;
        }
        
        if (strIndex == 0)
        {
            return pattern[patternIndex - 1] == '*' && GetPositionBool(strIndex, patternIndex - 2);
        }
        
        if (pattern[patternIndex - 1] == '*')
        {
            return GetPositionBool(strIndex, patternIndex - 2) ||
                   (pattern[patternIndex - 2] == '.' || pattern[patternIndex - 2] == str[strIndex - 1]) &&
                   GetPositionBool(strIndex - 1, patternIndex);
        }

        if (pattern[patternIndex - 1] == '.' || pattern[patternIndex - 1] == str[strIndex - 1])
        {
            return GetPositionBool(strIndex - 1, patternIndex - 1);
        }

        return false;
    }
}

[TestFixture]
public class Test_Q0010
{
    [TestCase("aa", "a", false)]
    [TestCase("aa", "a*", true)]
    [TestCase("ab", ".*", true)]
    [TestCase("abc", "a***abc", true)]
    [TestCase("abt", "a.t", true)]
    [TestCase("aab", "c*a*b", true)]
    [TestCase("aaca", "ab*a*c*a", true)]
    public void Test(string input, string regex, bool output)
    {
        Solution_Q0010.IsMatchRecursive(input, regex).Should().Be(output);
    }
}