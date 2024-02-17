namespace CodePractice.Question_001_099;

public class Solution_Q11 {
    public int MaxArea(int[] height)
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
public class Test_Q11
{
    [TestCase(new [] {1,8,6,2,5,4,8,3,7}, 49)]
    [TestCase(new [] {1,1}, 1)]
    public void Test(int[] input, int output)
    {
        new Solution_Q11().MaxArea(input).Should().Be(output);
    }
}