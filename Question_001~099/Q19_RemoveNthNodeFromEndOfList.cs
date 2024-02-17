using CodePractice.Model;

namespace CodePractice.Question_001_099;

public class Solution_Q19
{
    public ListNode RemoveNthFromEnd(ListNode head, int n)
    {
        var array = ToArray(head);
        var list = array.Reverse().ToList();

        if (list.Count >= n)
        {
            list.RemoveAt(n - 1);
        }

        list.Reverse();
        return ToListNode(list.ToArray());
    }
    
    public int[] ToArray(ListNode listNode)
    {
        if (listNode == null)
        {
            return new int[] { };
        }
        var resultList = new List<int>();
        var current = listNode;

        while (current != null)
        {
            resultList.Add(current.val);
            current = current.next;
        }

        return resultList.ToArray();
    }

    public ListNode ToListNode(int[] array)
    {
        if (array == null || array.Length == 0)
        {
            return new ListNode{isNull = true};
        }

        ListNode result = new ListNode(), 
            current = result;

        foreach (var num in array)
        {
            current.next = new ListNode(num);
            current = current.next;
        }

        return result.next;
    }
}

[TestFixture]
public class Test_Q19
{
    [TestCase(new [] {1,2,3,4,5}, 2, new []{1,2,3,5})]
    [TestCase(new [] {1}, 1, new int[]{})]
    [TestCase(new [] {1,2}, 1, new int[]{1})]
    public void Test(int[] input1, int input2, int[] output)
    {
        new Solution_Q19().RemoveNthFromEnd(new ListNode(input1), input2).ToArray().Should().BeEquivalentTo(output);
    }
}