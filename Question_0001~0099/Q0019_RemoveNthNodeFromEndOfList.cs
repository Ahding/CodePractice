using CodePractice.Model;

namespace CodePractice.Question_0001_0099;

// Given the head of a linked list, remove the nth node from the end of the list and return its head.
public static class Solution_Q0019
{
    static Solution_Q0019()
    {
        SolutionCalculation.Add(Level.Medium);
    }
    
    public static ListNode RemoveNthFromEnd(ListNode head, int n)
    {
        if (n == 0 || head == null)
        {
            return head;
        }

        // reverse first
        ListNode original = Reverse(head),
            current = original,
            prev = null;
        
        // remove n node
        if (n == 1)
        {
            return Reverse(current.next);
        }
        
        for (int i = 1; i <= n; i++)
        {
            if (i == n)
            {
                prev.next = current.next;
            }

            prev = current;
            current = current.next;
        }
        
        // reverse back
        return Reverse(original);
    }
    
    private static ListNode Reverse(ListNode head)
    {
        ListNode prev = null, 
            next = null, 
            current = head;
        while (current != null)
        {
            next = current.next;
            current.next = prev;
            prev = current;
            current = next;
        }
        return prev;
    }
}

[TestFixture]
public class Test_Q0019
{
    [TestCase(new [] {1,2,3,4,5}, 2, new []{1,2,3,5})]
    [TestCase(new [] {1}, 1, new int[]{})]
    [TestCase(new [] {1,2}, 1, new int[]{1})]
    public void Test(int[] input1, int input2, int[] output)
    {
        Solution_Q0019.RemoveNthFromEnd(ListNode.FromArray(input1), input2).Should().BeEquivalentTo(ListNode.FromArray(output));
    }
}