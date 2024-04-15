namespace CodePractice.Question_001_099;

public class Solution_Q15
{
    public IList<IList<int>> ThreeSum(int[] nums)
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
public class Test_Q15
{
    [TestCase(new []{-1,0,1,2,-1,4}, new []{-1,-1,2}, new []{-1,0,1})]
    [TestCase(new []{0,1,1})]
    [TestCase(new []{0,0,0}, new []{0,0,0})]
    public void Test(int[] input, params int[][] output)
    {
        new Solution_Q15().ThreeSum(input).Select(x => x.ToArray()).ToArray().Should().BeEquivalentTo(output);
    }
}