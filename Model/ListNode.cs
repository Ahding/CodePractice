namespace CodePractice.Model;

public class ListNode
{
    public int val;
    public ListNode next;
    public bool isNull;
    public ListNode(int val = 0, ListNode next = null) {
        this.val = val;
        this.next = next;
    }

    public ListNode(int[] array)
    {
        if (array == null || array.Length == 0)
        {
            isNull = true;
            return;
        }

        ListNode result = new (), 
            current = result;

        foreach (var num in array)
        {
            current.next = new ListNode(num);
            current = current.next;
        }

        next =  result.next.next;
        val = result.next.val;
    }
    
    public int[] ToArray()
    {
        if (isNull)
        {
            return new int[] { };
        }
        var resultList = new List<int>();
        var current = this;

        while (current != null)
        {
            resultList.Add(current.val);
            current = current.next;
        }

        return resultList.ToArray();
    }
}