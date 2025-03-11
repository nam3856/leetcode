public class Solution {
    public int NumberOfSubstrings(string s) {
        int start = 0;
        int end = 0;
        int answer = 0;
        
        var abc = new Dictionary<char, int>();

        while(end < s.Length){
            char newLetter = s[end];

            if(!abc.ContainsKey(newLetter)){
                abc.Add(newLetter,0);
            }
            abc[newLetter]++;

            while(abc.Count==3){
                answer += s.Length - end;
                char startLetter = s[start];
                if(--abc[startLetter]==0){
                    abc.Remove(startLetter);
                }
                start++;
            }
            end++;
        }
        return answer;
    }
}