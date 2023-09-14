namespace CodePractice.Question_001_099;

public class Solution_Q1
{
    public int[] TwoSum(int[] nums, int target)
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
public class Test_Q1
{
    [Test]
    public void Test()
    {
        // given
        var array = new int[] { 2, 7, 11, 15 };
        var target = 9;

        // when
        var output = new Solution_Q1().TwoSum(array, target);

        // then
        var result = new int[] { 0, 1 };
        output.Should().BeEquivalentTo (result);
    }
}