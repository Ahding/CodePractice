using CodePractice.Model;

namespace CodePractice.Question_001_099;

public class Solution_Q0024
{
    static Solution_Q0024()
    {
        SolutionCalculation.Add(Level.Medium);
    }

    public static ListNode SwapPairs(ListNode head)
    {
        if (head == null || head.next == null)
        {
            return head;
        }

        var result = head.next;
        head.next = SwapPairs(result.next);
        result.next = head;

        return result;
    }
}

[TestFixture]
public class Test_Q0024
{
    [TestCase(new [] {1, 2, 3, 4}, new [] {2, 1, 4, 3} )]
    [TestCase(new [] {1}, new [] {1})]
    [TestCase(new int[] {}, new int[] {})]
    public void Test(int[] input, int[] output)
    {
        Solution_Q0024.SwapPairs(ListNode.FromArray(input)).Should().BeEquivalentTo(ListNode.FromArray(output));
    }
}