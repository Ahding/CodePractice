namespace CodePractice.Question_001_099;

public class Solution_Q4 {
    public double FindMedianSortedArrays(int[] nums1, int[] nums2)
    {
        var newArray = new int[nums1.Length + nums2.Length];
        Array.Copy(nums1, newArray, nums1.Length);
        Array.Copy(nums2, 0, newArray, nums1.Length, nums2.Length);
        newArray = newArray.OrderBy(x => x).ToArray();
        return newArray.Length % 2 != 0
            ? newArray[(newArray.Length - 1) / 2]
            :(double)(newArray[newArray.Length / 2] + newArray[(newArray.Length - 2) / 2]) / 2;
    }
}

[TestFixture]
public class Test_Q04
{
    [TestCase(new []{1, 3}, new[]{2}, 2)]
    [TestCase(new []{1, 2}, new[]{3, 4}, 2.5)]
    public void Test(int[] iA1, int[] iA2, double result)
    {
        new Solution_Q4().FindMedianSortedArrays(iA1, iA2).Should().Be(result);
    }
}