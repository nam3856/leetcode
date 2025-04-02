public class Solution {
    public long MaximumTripletValue(int[] nums) {
        int n = nums.Length;
        long res = 0, imax = 0, dmax = 0;
        for (int k = 0; k < n; k++) {
            res = Math.Max(res, dmax * nums[k]);
            dmax = Math.Max(dmax, imax - nums[k]);
            imax = Math.Max(imax, nums[k]);
        }
        return res;
    }
}