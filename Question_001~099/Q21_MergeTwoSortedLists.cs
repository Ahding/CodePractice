using CodePractice.Model;

namespace CodePractice.Question_001_099;

public class Solution_Q21
{
    public ListNode MergeTwoLists(ListNode list1, ListNode list2)
    {
        var list = new List<int>();
        Concat(Concat(list, list1), list2).Sort();
        return ToListNode(list.ToArray());
    }

    private List<int> Concat(List<int> list, ListNode listNode)
    {
        if (listNode == null || listNode.isNull)
        {
            return list;
        }
        
        list.Add(listNode.val);
        var current = listNode;
        while (current.next != null)
        {
            current = current.next;
            list.Add(current.val);
        }

        return list;
    }
    
    private ListNode ToListNode(int[] array)
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
public class Test_Q21
{
    [TestCase(new int[] {1, 2, 4}, new int[] {1, 3, 4}, new int[] {1, 1, 2, 3, 4, 4})]
    [TestCase(new int[] {}, new int[] {}, new int[] {})]
    [TestCase(new int[] {}, new int[] {0}, new int[] {0})]
    public void Test(int[] input1, int[] input2, int[] output)
    {
        var result = new Solution_Q21().MergeTwoLists(new ListNode(input1), new ListNode(input2));
        result.ToArray().Should().BeEquivalentTo(output);
    }
}