using CodePractice.Model;

namespace CodePractice.Question_0001_0099;

// There are two sorted arrays nums1 and nums2 of size m and n respectively.
// Find the median of the two sorted arrays. The overall run time complexity should be O(log (m+n)).
// You may assume nums1 and nums2 cannot be both empty.
public static class Solution_Q0004 
{
    static Solution_Q0004()
    {
        SolutionCalculation.Add(Level.Hard);
    }

    public static double FindMedianSortedArrays(int[] nums1, int[] nums2)
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
public class Test_Q0004
{
    [TestCase(new []{1, 3}, new[]{2}, 2)]
    [TestCase(new []{1, 2}, new[]{3, 4}, 2.5)]
    public void Test(int[] iA1, int[] iA2, double result)
    {
        Solution_Q0004.FindMedianSortedArrays(iA1, iA2).Should().Be(result);
    }
}