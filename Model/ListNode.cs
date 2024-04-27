namespace CodePractice.Model;

public class ListNode
{
    public int val;
    public ListNode next;
    public ListNode(int val = 0, ListNode next = null) {
        this.val = val;
        this.next = next;
    }

    public static ListNode FromArray(int[] array)
    {
        if (array == null || array.Length == 0)
        {
            return null;
        }

        ListNode result = new (),
            current = result;

        foreach (var num in array)
        {
            current.next = new ListNode(num);
            current = current.next;
        }

        return result.next;
    }
    
    public static ListNode[] FromArray(int[][] array)
    {
        if (array == null || array.Length == 0)
        {
            return Array.Empty<ListNode>();
        }

        var result = new ListNode[array.Length];
        for (int i = 0; i < array.Length; i++)
        {
            result[i] = FromArray(array[i]);
        }

        return result;
    }
}