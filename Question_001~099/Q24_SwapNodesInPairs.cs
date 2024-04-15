using CodePractice.Model;

namespace CodePractice.Question_001_099;

public class Q24_SwapNodesInPairs
{
    public ListNode SwapPairs(ListNode head)
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
public class Test_Q24
{
    [TestCase(new [] {1, 2, 3, 4}, new [] {2, 1, 4, 3} )]
    [TestCase(new [] {1}, new [] {1})]
    [TestCase(new int[] {}, new int[] {})]
    public void Test(int[] input, int[] output)
    {
        new Q24_SwapNodesInPairs().SwapPairs(new ListNode(input))
            .ToArray().Should().BeEquivalentTo(output);
    }
}