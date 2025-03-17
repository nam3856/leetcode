public class Solution
{
    public bool DivideArray(int[] nums)
    {
        var match = new HashSet<int>();

        foreach (int num in nums)
        {
            if (match.Contains(num))
            {
                match.Remove(num);
            }
            else
            {
                match.Add(num);
            }
        }
        return match.Count == 0;
    }

    
}