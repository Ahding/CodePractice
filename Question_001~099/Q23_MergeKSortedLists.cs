using CodePractice.Model;

namespace CodePractice.Question_001_099;

public class Q23_MergeKSortedLists
{
    public ListNode MergeKLists(ListNode[] lists)
    {
        var list = new List<int>();
        foreach (var node in lists)
        {
            if (node.isNull)
            {
                continue;
            }
            
            var current = node;
            while (current != null)
            {
                list.Add(current.val);
                current = current.next;
            }
        }
        
        list.Sort();
        return ToListNode(list);
    }
    
    private ListNode ToListNode(List<int> list)
    {
        if (list == null || list.Count == 0)
        {
            return new ListNode{isNull = true};
        }

        ListNode result = new ListNode(), 
            current = result;

        foreach (var num in list)
        {
            current.next = new ListNode(num);
            current = current.next;
        }

        return result.next;
    }
}

[TestFixture]
public class Test_Q23
{
    [TestCase(new []{1,1,2,3,4,4,5,6}, new []{1,4,5}, new []{1,3,4}, new []{2,6})]
    [TestCase(new int[] {}, new int[] {})]
    public void Test(int[] output, params int[][] input)
    {
        new Q23_MergeKSortedLists().MergeKLists(input.Select(x => new ListNode(x)).ToArray())
            .ToArray().Should().BeEquivalentTo(output);
    }
}