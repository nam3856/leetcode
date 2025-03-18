public class Solution {
    public int LongestNiceSubarray(int[] nums) {
        int start = 0;
        int maxLength = 0;
        int bitwiseAnd = 0;
        for(int end = 0; end <nums.Length;end++){
            while((bitwiseAnd & nums[end])!=0){
                bitwiseAnd ^= nums[start];
                start++;
            }

            bitwiseAnd |= nums[end];

            maxLength = Math.Max(maxLength, end - start+1);
        }

        return maxLength;
    }
}