public class Solution {
    public long MostPoints(int[][] questions) {
         int n = questions.Length;
 long[] dp = new long[n + 1]; // Create a DP array with an extra space for easier indexing

 for (int i = n - 1; i >= 0; i--)
 {
     int points = questions[i][0];
     int brainpower = questions[i][1];
     // Option 1: Skip the current question
     long skip = dp[i + 1];
     // Option 2: Solve the current question
     long solve = points;
     if (i + brainpower + 1 < n)
     {
         solve += dp[i + brainpower + 1];
     }
     // Take the maximum of both options
     dp[i] = Math.Max(skip, solve);
 }

 return dp[0]; // The maximum points starting from the first question
    }
}