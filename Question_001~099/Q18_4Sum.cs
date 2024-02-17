namespace CodePractice.Question_001_099;

public class Solution_Q18
{
    public IList<IList<int>> FourSum(int[] nums, int target)
    {
        Array.Sort(nums);
        var result = new List<IList<int>>();

        for (var l1 = 0; l1 < nums.Length - 3; l1++)
        {
            for (var l2 = l1 + 1; l2 < nums.Length - 2; l2++)
            {
                int l = l2 + 1, r = nums.Length - 1;
                while (l < r)
                {
                    var total = (long)nums[l1] + nums[l2] + nums[l] + nums[r];
                    if (target == total)
                    {
                        var success = new List<int> { nums[l1], nums[l2], nums[l], nums[r] };
                        if (!result.Exists(x =>
                                x[0] == success[0] && x[1] == success[1] && x[2] == success[2] && x[3] == success[3]))
                        {
                            result.Add(success);
                        }
                    }
                    
                    if (total < target)
                    {
                        var tl = l + 1;
                        while (tl < r && nums[l] == nums[tl])
                        {
                            tl++;
                        }

                        l = tl;
                    }
                    else
                    {
                        var tr = r - 1;
                        while (l < tr && nums[r] == nums[tr])
                        {
                            tr--;
                        }

                        r = tr;
                    }
                }
            }
        }

        return result;
    }
}

[TestFixture]
public class Test_Q18
{
    [TestCase(new [] {1,0,-1,0,-2,2}, 0, new []{-2,-1,1,2,-2,0,0,2,-1,0,0,1})]
    [TestCase(new [] {2,2,2,2,2}, 8, new []{2,2,2,2})]
    [TestCase(new [] {-3,-1,0,2,4,5}, 2, new []{-3,-1,2,4})]
    [TestCase(new [] {-3,-2,-1,0,0,1,2,3}, 0, new []{-3,-2,2,3,-3,-1,1,3,-3,0,0,3,-3,0,1,2,-2,-1,0,3,-2,-1,1,2,-2,0,0,2,-1,0,0,1})]
    [TestCase(new [] {1000000000,1000000000,1000000000,1000000000}, -294967296, new int[]{})]
    public void Test(int[] input1, int input2, int[] output)
    {
        new Solution_Q18().FourSum(input1, input2).Should().BeEquivalentTo(_Convert(output));
    }

    private IList<IList<int>> _Convert(int[] input)
    {
        var result = new List<IList<int>>();
        var temp = new List<int>();
        foreach (var i in input)
        {
            temp.Add(i);
            
            if (temp.Count == 4)
            {
                result.Add(temp);
                temp = new List<int>();
            }
        }

        return result;
    }
}