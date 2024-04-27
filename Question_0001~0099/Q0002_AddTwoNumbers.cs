using CodePractice.Model;

namespace CodePractice.Question_0001_0099;

// You are given two non-empty linked lists representing two non-negative integers.
// The digits are stored in reverse order and each of their nodes contain a single digit.
// Add the two numbers and return it as a linked list.
// You may assume the two numbers do not contain any leading zero, except the number 0 itself.
public static class Solution_Q0002
{
    static Solution_Q0002()
    {
        SolutionCalculation.Add(Level.Medium);
    }
    
    public static ListNode AddTwoNumbers(ListNode l1, ListNode l2, bool isAddOne = false)
    {
        if (l1 == null && l2 == null && !isAddOne)
        {
            return null;
        }
        var val = (l1?.val ?? 0) + (l2?.val ?? 0) + (isAddOne ? 1 : 0);
        return new ListNode(val % 10, AddTwoNumbers(l1?.next, l2?.next, val > 9));
    }
}

[TestFixture]
public class Test_Q0002
{
    [TestCase(new []{2, 4, 3}, new []{5, 6, 4}, new []{7, 0, 8})]
    [TestCase(new []{0}, new []{0}, new []{0})]
    [TestCase(new []{9, 9, 9, 9, 9, 9, 9}, new []{9, 9, 9, 9}, new []{8, 9, 9, 9, 0, 0, 0, 1})]
    public void Test(int[] n1, int[] n2, int[] n3)
    {
        ListNode l1 = ListNode.FromArray(n1),
            l2 = ListNode.FromArray(n2),
            l3 = ListNode.FromArray(n3);
        Solution_Q0002.AddTwoNumbers(l1, l2).Should().BeEquivalentTo(l3);
    }

    
}

