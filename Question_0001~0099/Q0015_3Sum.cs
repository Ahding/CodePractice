using CodePractice.Model;

namespace CodePractice.Question_0001_0099;

// Given an integer array nums, return all the triplets [nums[i], nums[j], nums[k]] such that i != j, i != k, and j != k,
// and nums[i] + nums[j] + nums[k] == 0.
// Notice that the solution set must not contain duplicate triplets.
public static class Solution_Q0015
{
    static Solution_Q0015()
    {
        SolutionCalculation.Add(Level.Medium);
    }
    
    public static IList<IList<int>> ThreeSum(int[] nums)
    {
        var result = new List<IList<int>>();
        if (nums.Length <= 2)
        {
            return result;
        }
        
        Array.Sort(nums);
        int start = 0, left, right, target;
        while (start < nums.Length - 2)
        {
            target = nums[start] * -1;
            left = start + 1;
            right = nums.Length - 1;

            while (left < right)
            {
                if (nums[left] + nums[right] > target)
                {
                    --right;
                }
                else if (nums[left] + nums[right] < target)
                {
                    ++left;
                }
                else
                {
                    var oneSolution = new List<int> { nums[start], nums[left], nums[right] };
                    result.Add(oneSolution);
                    
                    while (left < right && nums[left] == oneSolution[1])
                    {
                        ++left;
                    }
                    while (left < right && nums[right] == oneSolution[2])
                    {
                        --right;
                    }
                }
            }
            
            var currentStart = nums[start];
            while (start < nums.Length - 2 && nums[start] == currentStart)
            {
                ++start;
            }
        }
        return result;
    }
}

[TestFixture]
public class Test_Q0015
{
    [TestCase(new []{-1,0,1,2,-1,4}, new []{-1,-1,2}, new []{-1,0,1})]
    [TestCase(new []{0,1,1})]
    [TestCase(new []{0,0,0}, new []{0,0,0})]
    public void Test(int[] input, params int[][] output)
    {
        Solution_Q0015.ThreeSum(input).Should().BeEquivalentTo(output);
    }
}