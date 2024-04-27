using CodePractice.Model;

namespace CodePractice.Question_001_099;

// You are given the heads of two sorted linked lists list1 and list2.
// Merge the two lists into one sorted list.
// The list should be made by splicing together the nodes of the first two lists.
// Return the head of the merged linked list.
public class Solution_Q0021
{
    static Solution_Q0021()
    {
        SolutionCalculation.Add(Level.Easy);
    }

    public static ListNode MergeTwoLists(ListNode list1, ListNode list2)
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
public class Test_Q0021
{
    [TestCase(new int[] {1, 2, 4}, new int[] {1, 3, 4}, new int[] {1, 1, 2, 3, 4, 4})]
    [TestCase(new int[] {}, new int[] {}, new int[] {})]
    [TestCase(new int[] {}, new int[] {0}, new int[] {0})]
    public void Test(int[] input1, int[] input2, int[] output)
    {
        var result = Solution_Q0021.MergeTwoLists(ListNode.FromArray(input1), ListNode.FromArray(input2));
        result.Should().BeEquivalentTo(ListNode.FromArray(output));
    }
}