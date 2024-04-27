using CodePractice.Model;

namespace CodePractice.Question_0001_0099;

// Given the head of a linked list, reverse the nodes of the list k at a time, and return the modified list.
// k is a positive integer and is less than or equal to the length of the linked list. If the number of nodes is not a multiple of k then left-out nodes, in the end, should remain as it is.
// You may not alter the values in the list's nodes, only nodes themselves may be changed.
public static class Solution_Q0025
{
    static Solution_Q0025()
    {
        SolutionCalculation.Add(Level.Hard);
    }
    
    // other better solution
    public static ListNode ReverseKGroup(ListNode head, int k) {
        if (head == null || k == 1) {
            return head;
        }
        
        // Check if there are at least k nodes remaining in the list
        int count = 0;
        ListNode current = head;
        while (current != null && count < k) {
            current = current.next;
            count++;
        }

        if (count < k) {
            return head; // Not enough nodes to reverse
        }

        // Reverse the first k nodes in the current group
        ListNode prev = null;
        ListNode next = null;
        current = head;
        for (int i = 0; i < k; i++) {
            next = current.next;
            current.next = prev;
            prev = current;
            current = next;
        }

        // Recursively reverse the remaining part of the list
        head.next = ReverseKGroup(current, k);

        return prev; // 'prev' is now the new head of this group
    }
}


[TestFixture]
public class Test_Q25
{
    [TestCase(new[] {1, 2, 3, 4, 5}, 2, new[] {2, 1, 4, 3, 5} )]
    [TestCase(new[] {1, 2, 3, 4, 5}, 3, new[] {3, 2, 1, 4, 5} )]
    [TestCase(new[] {1, 2, 3, 4}, 2, new[] {2, 1, 4, 3} )]
    public void Test(int[] input, int k, int[] output)
    {
        Solution_Q0025.ReverseKGroup(ListNode.FromArray(input), k)
            .Should().BeEquivalentTo(ListNode.FromArray(output));
    }
}