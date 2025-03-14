public class Solution
{
    public int MaximumCandies(int[] candies, long k)
    {
        int maxCandies = 0;
        for (int i = 0; i < candies.Length; i++)
        {
            maxCandies = Math.Max(maxCandies, candies[i]);
        }

        int left = 0;
        int right = maxCandies;

        while(left < right)
        {
            int middle = (left + right + 1) / 2;

            if(canAllocateCandies(candies, k, middle))
            {
                left = middle;
            }
            else
            {
                right = middle - 1;
            }
        }

        return left;
    }

    private bool canAllocateCandies(int[] candies, long k, int numOfCandies)
    {
        long maxNumOfChildren = 0;

        for(int pileIndex = 0; pileIndex < candies.Length; pileIndex++)
        {
            maxNumOfChildren += candies[pileIndex] / numOfCandies;
        }

        return maxNumOfChildren >= k;
    }
}