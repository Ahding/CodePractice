using CodePractice.Model;

namespace CodePractice.Question_0001_0099;

// Given an array of integers, return indices of the two numbers such that they add up to a specific target.
// You may assume that each input would have exactly one solution, and you may not use the same element twice.
public static class Solution_Q0001
{
    static Solution_Q0001()
    {
        SolutionCalculation.Add(Level.Easy);
    }
    
    public static int[] TwoSum(int[] nums, int target)
    {
        HashSet<int> numMap = new();
        for (var index = 0; index < nums.Length; index++)
        {
            var another = target - nums[index];
            if (numMap.Contains(another))
            {
                return new int[] { Array.IndexOf(nums, another), index };
            }
            
            if (!numMap.Contains(nums[index]))
            {
                numMap.Add(nums[index]);
            }
        }

        return new int[]{};
    }
}


[TestFixture]
public class Test_Q0001
{
    [TestCase(new []{ 2, 7, 11, 15 }, 9, new []{ 0, 1 })]
    public void Test(int[] input1, int input2, int[] output)
    {
        Solution_Q0001.TwoSum(input1, input2).Should().BeEquivalentTo(output);
    }
}