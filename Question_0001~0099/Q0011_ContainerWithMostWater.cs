using CodePractice.Model;

namespace CodePractice.Question_0001_0099;

// You are given an integer array height of length n.
// There are n vertical lines drawn such that the two endpoints of the ith line are (i, 0) and (i, height[i]).
// Find two lines that together with the x-axis form a container, such that the container contains the most water.
// Return the maximum amount of water a container can store.
public static class Solution_Q0011 
{
    static Solution_Q0011()
    {
        SolutionCalculation.Add(Level.Medium);
    }
    public static int MaxArea(int[] height)
    {
        var li = 0;
        var ri = height.Length - 1;
        var max = 0;
        var currentMax = 0;

        while (ri > li)
        {
            if (height[li] > height[ri])
            {
                currentMax = height[ri] * (ri - li);
                ri--;
            }
            else
            {
                currentMax = height[li] * (ri - li);
                li++;
            }

            if (max < currentMax)
            {
                max = currentMax;
            }
        }

        return max;
    }
}

[TestFixture]
public class Test_Q0011
{
    [TestCase(new [] {1,8,6,2,5,4,8,3,7}, 49)]
    [TestCase(new [] {1,1}, 1)]
    public void Test(int[] input, int output)
    {
        Solution_Q0011.MaxArea(input).Should().Be(output);
    }
}