using CodePractice.Model;

namespace CodePractice.Question_001_099;

public class Solution_Q2
{
    public ListNode AddTwoNumbers(ListNode l1, ListNode l2, bool isAddOne = false)
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
public class Test_Q02
{
    [TestCase(new []{2, 4, 3}, new []{5, 6, 4}, new []{7, 0, 8})]
    [TestCase(new []{0}, new []{0}, new []{0})]
    [TestCase(new []{9, 9, 9, 9, 9, 9, 9}, new []{9, 9, 9, 9}, new []{8, 9, 9, 9, 0, 0, 0, 1})]
    public void Test(int[] n1, int[] n2, int[] n3)
    {
        ListNode l1 = new (n1),
            l2 = new (n2),
            l3 = new (n3);
        new Solution_Q2().AddTwoNumbers(l1, l2).Should().BeEquivalentTo(l3);
    }

    
}

