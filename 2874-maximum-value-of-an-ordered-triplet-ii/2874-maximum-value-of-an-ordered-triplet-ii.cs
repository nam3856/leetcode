public class Solution {
    public long MaximumTripletValue(int[] nums) {
        int n = nums.Length;
        long res = 0, imax = 0, dmax = 0;
        for(int i=0;i<n;i++){
            res = Math.Max(res, dmax * nums[i]);
            dmax = Math.Max(dmax, imax - nums[i]);
            imax = Math.Max(imax, nums[i]);
        }
        return res;
    }
}