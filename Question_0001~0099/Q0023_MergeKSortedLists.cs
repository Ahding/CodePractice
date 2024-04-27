using CodePractice.Model;

namespace CodePractice.Question_001_099;

// You are given an array of k linked-lists lists, each linked-list is sorted in ascending order.
// Merge all the linked-lists into one sorted linked-list and return it.
public static class Solution_Q0023
{
    static Solution_Q0023()
    {
        SolutionCalculation.Add(Level.Hard);
    }

    public static ListNode MergeKLists(ListNode[] lists)
    {
        if (lists.Length == 0)
        {
            return null;
        }

        ListNode result = lists[0];
        for (int i = 1; i < lists.Length; i++)
        {
            result = MergeTwoLists(result, lists[i]);
        }

        return result;
    }
    
    private static ListNode MergeTwoLists(ListNode list1, ListNode list2)
    {
        ListNode temp = new(0), current = temp;
        while (list1 != null && list2 != null)
        {
            if (list1.val < list2.val)
            {
                current.next = list1;
                list1 = list1.next;
            }
            else
            {
                current.next = list2;
                list2 = list2.next;
            }

            current = current.next;
        }

        current.next = list1 ?? list2;
        return temp.next;
    }
}

[TestFixture]
public class Test_Q0023
{
    [TestCase(new []{1,1,2,3,4,4,5,6}, new []{1,4,5}, new []{1,3,4}, new []{2,6})]
    [TestCase(new int[] {}, new int[] {})]
    public void Test(int[] output, params int[][] input)
    {
        Solution_Q0023.MergeKLists(ListNode.FromArray(input)).Should().BeEquivalentTo(ListNode.FromArray(output));
    }
}