public class Solution {
    public int[] FindMissingAndRepeatedValues(int[][] grid)
    {
        int xorAll = 0;
        int xorArr = 0;
        int n = grid.Length;
        for (int i = 0; i < n * n; i++)
        {
            xorAll ^= i;
        }

        foreach(var array in grid)
        {
            foreach(var num in array)
            {
                xorArr ^= num;
            }
        }

        int xorResult = xorAll ^ xorArr;

        int diffBit = xorResult & -xorResult;

        int missing = 0, duplicate = 0;

        for(int i = 1; i <= n; i++)
        {
            if ((i & diffBit) == 0) missing ^= i;
            else duplicate ^= i;
        }

        foreach (var array in grid)
        {
            foreach (var num in array)
            {
                if ((num & diffBit) == 0) missing ^= num;
                else duplicate ^= num;
            }
        }

        foreach (var array in grid)
        {
            foreach (var num in array)
            {
                if (num == duplicate) return new int[] { duplicate, missing };
            }
        }
        return new int[] { missing, duplicate };
    }
}