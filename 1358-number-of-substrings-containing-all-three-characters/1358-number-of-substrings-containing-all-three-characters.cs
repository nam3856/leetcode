public class Solution {
    public int NumberOfSubstrings(string s) {
        int start = 0;
        int end = 0;
        int answer = 0;
        
        var abc = new int[3];

        while(end < s.Length){
            int newLetter = s[end] - 'a';

            abc[newLetter]++;

            while(abc[0]>0 && abc[1]>0 && abc[2]>0){
                answer += s.Length - end;
                int startLetter = s[start] - 'a';
                --abc[startLetter];
                start++;
            }
            end++;
        }
        return answer;
    }
}