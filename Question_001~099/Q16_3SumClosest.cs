namespace CodePractice.Question_001_099;

public class Solution_Q16
{
    public int ThreeSumClosest(int[] nums, int target)
    {
        int minDifference = int.MaxValue,
            minDifferenceTotal = int.MaxValue;

        for (var index1 = 0; index1 < nums.Length - 2; index1++)
        {
            for (var index2 = index1 + 1; index2 < nums.Length - 1; index2++)
            {
                for (var index3 = index2 + 1; index3 < nums.Length; index3++)
                {
                    var total = nums[index1] + nums[index2] + nums[index3];
                    var diff = Math.Abs(total - target);
                    if (diff < minDifference)
                    {
                        minDifferenceTotal = total;
                        minDifference = diff;
                    }
                }
            }
        }

        return minDifferenceTotal;
    }
    
    public int BetterThreeSumClosest(int[] nums, int target)
    {
        Array.Sort(nums);
        int minDifference = int.MaxValue,
            minDifferenceTotal = int.MaxValue;

        for (var index = 0; index < nums.Length - 2; index++)
        {
            int left = index + 1,
                right = nums.Length - 1;

            while (right > left)
            {
                var total = nums[index] + nums[left] + nums[right];
                if (total == target)
                {
                    return total;
                }
                
                var diff = Math.Abs(total - target);
                if (minDifference > diff)
                {
                    minDifferenceTotal = total;
                    minDifference = diff;
                }

                if (total > target)
                {
                    right--;
                }
                else
                {
                    left++;
                }
            }
        }

        return minDifferenceTotal;
    }
}

[TestFixture]
public class Test_Q16
{
    [TestCase(new []{-1,2,1,-4}, 1, 2)]
    [TestCase(new []{0,0,0}, 1, 0)]
    [TestCase(new []{0,1,2}, 3, 3)]
    public void Test(int[] input, int target, int output)
    {
        new Solution_Q16().BetterThreeSumClosest(input, target).Should().Be(output);
    }
}