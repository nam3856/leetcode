public class Solution
{
    public int MinOperations(int[] nums)
    {
        int flips = 0;

        for(int i=2;i<nums.Length;i++){
            if(nums[i-2]==0){
                nums[i-2] = 1;
                nums[i-1] ^= 1;
                nums[i] ^= 1;
                flips++;
            }
        }
        if(nums.Sum() == nums.Length) return flips;
        return -1;
    }
}