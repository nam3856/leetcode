public class Solution {
    public int MaximumCount(int[] nums) {
        int pos = 0;
        int neg = 0;
        foreach(var num in nums){
            if(num < 0) neg++;
            else if (num >0) pos++;
        }
        return pos>neg?pos:neg;
    }
}