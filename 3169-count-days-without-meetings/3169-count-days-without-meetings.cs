public class Solution {
    public int CountDays(int days, int[][] meetings) {
        Array.Sort(meetings, (x, y) => x[0].CompareTo(y[0]));
        int count = 0;
        int end = meetings[0][1];

        if(meetings[0][0]>1){
            count += meetings[0][0] - 1;
        }

        foreach(var meeting in meetings){
            if(end+1 < meeting[0]){
                count += meeting[0] - end - 1;
            }
            end = meeting[1];
        }

        if(end<days){
            count += days-end;
        }
        return count;

    }
}