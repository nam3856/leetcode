using System;
using System.Collections.Generic;

public class Solution {
    private bool IsPrime(int num) {
        if (num < 2) return false;
        for (int d = 2; d <= Math.Sqrt(num); d++) {
            if (num % d == 0) return false;
        }
        return true;
    }

    public int[] ClosestPrimes(int left, int right) {
        int mn_diff = int.MaxValue;
        int past_prime = -1;
        int[] pair = {-1, -1};

        for (int x = Math.Max(2, left); x <= right; x++) {
            if (IsPrime(x)) {  
                if (past_prime != -1) { 
                    int diff = x - past_prime;
                    if (diff < mn_diff) {
                        mn_diff = diff;
                        pair[0] = past_prime;
                        pair[1] = x;
                    }
                }
                past_prime = x; 
                
                if (mn_diff <= 2) return pair;
            }
        }
        return pair;
    }
}