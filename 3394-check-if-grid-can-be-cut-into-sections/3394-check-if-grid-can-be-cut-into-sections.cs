public class Solution {
    public bool CheckValidCuts(int n, int[][] rectangles) {
        var xIntervals = rectangles.Select(rect => new int[] { rect[0], rect[2] }).ToArray();
        var yIntervals = rectangles.Select(rect => new int[] { rect[1], rect[3] }).ToArray();

        return Check(xIntervals) || Check(yIntervals);
    }

    private bool Check(int[][] intervals) {
        Array.Sort(intervals, (a, b) => a[0].CompareTo(b[0]));

        int sections = 0;
        int maxEnd = intervals[0][1];

        foreach (var interval in intervals) {
            if (maxEnd <= interval[0]) {
                sections++;
            }
            maxEnd = Math.Max(maxEnd, interval[1]);
        }

        return sections >= 2;
    }
}