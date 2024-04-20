using CodePractice.Model;

namespace CodePractice.Question_001_099;

public class Q25_ReverseNodesInKGroup
{
    // my Logic ... use array
    // public ListNode ReverseKGroup(ListNode head, int k)
    // {
    //     if (head == null || head.isNull || head.next.isNull || k == 1)
    //     {
    //         return head;
    //     }
    //
    //     var array = head.ToArray();
    //     int left = 0, right = k - 1, initLeft = left, initRight = right;
    //     
    //     while (true)
    //     {
    //         (array[left], array[right]) = (array[right], array[left]);
    //         left++;
    //         right--;
    //
    //         
    //         // iterate logic
    //         if (left < right)
    //         {
    //             continue;
    //         }
    //         
    //         initLeft += k;
    //         if (initLeft >= array.Length - 1)
    //         {
    //             break;
    //         }
    //             
    //         initRight += k;
    //         if (initRight > array.Length - 1)
    //         {
    //             break;
    //         }
    //             
    //         left = initLeft;
    //         right = initRight;
    //     }
    //     
    //     return ToListNode(array);
    // }
    //
    // private ListNode ToListNode(int[] list)
    // {
    //     if (list.Count() == 0)
    //     {
    //         return new ListNode{isNull = true};
    //     }
    //
    //     ListNode result = new ListNode(), 
    //         current = result;
    //
    //     foreach (var num in list)
    //     {
    //         current.next = new ListNode(num);
    //         current = current.next;
    //     }
    //
    //     return result.next;
    // }
    
    // other better solution
    public ListNode ReverseKGroup(ListNode head, int k) {
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
        new Q25_ReverseNodesInKGroup().ReverseKGroup(new ListNode(input), k)
            .ToArray().Should().Equal(output);
    }
}