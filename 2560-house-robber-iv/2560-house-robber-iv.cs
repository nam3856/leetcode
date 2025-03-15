public class Solution
{
    public int MinCapability(int[] nums, int k)
    {
        int minReward = 1;
        int maxReward = nums.Max();
        int totalHouses = nums.Length;

        while(minReward < maxReward)
        {
            int midReward = (minReward + maxReward) / 2;
            int possibleThefts = 0;

            for(int index = 0; index < totalHouses; index++)
            {
                if (nums[index] <= midReward)
                {
                    possibleThefts++;
                    index++;
                }
            }

            if (possibleThefts >= k) maxReward = midReward;
            else minReward=midReward+1;
        }
        return minReward;
    }
}