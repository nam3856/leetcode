public class Solution
{
    public int MinZeroArray(int[] nums, int[][] queries)
    {
        int n = nums.Length;
        int left = 0;
        int right = queries.Length;

        if (!CurrentIndexZero(nums, queries, right)) return -1;

        while (left <= right)
        {
            int middle = left + (right - left) / 2;
            if (CurrentIndexZero(nums, queries, middle))
            {
                right = middle - 1;
            }
            else
            {
                left = middle + 1;
            }
        }

        return left;
    }

    private bool CurrentIndexZero(int[] nums, int[][] queries, int k)
    {
        int n = nums.Length;
        int sum = 0;
        var differenceArray = new int[n + 1];

        for (int queryIndex = 0; queryIndex < k; queryIndex++)
        {
            int left = queries[queryIndex][0], right = queries[queryIndex][1], val = queries[queryIndex][2];

            differenceArray[left] += val;
            differenceArray[right + 1] -= val;
        }

        for (int numIndex = 0; numIndex < n; numIndex++)
        {
            sum += differenceArray[numIndex];
            if (sum < nums[numIndex]) return false;
        }
        return true;
    }
}