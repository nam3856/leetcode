public class Solution
{
    public int MinOperations(int[] nums)
    {
        var linkedList = new LinkedList<int>();
        int count = 0;

        for (int i = 0; i < nums.Length; i++)
        {
            while (linkedList.Count > 0 && i > linkedList.First.Value + 2)
            {
                linkedList.RemoveFirst();
            }

            if ((nums[i] + linkedList.Count) % 2 == 0)
            {
                if (i + 2 >= nums.Length)
                {
                    return -1;
                }
                count++;
                linkedList.AddLast(i);
            }
        }
        return count;
    }
}