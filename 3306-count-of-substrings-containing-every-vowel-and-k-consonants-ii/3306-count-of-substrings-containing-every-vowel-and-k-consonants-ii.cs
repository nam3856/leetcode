public class Solution
{
    public long CountOfSubstrings(string word, int k)
    {
        // 최소 k개 이상인 경우와 최소 k+1개 이상인 경우의 차이를 구함으로써
        // 정확히 k개의 자음을 포함하는 부분문자열의 개수를 계산
        return AtLeastK(word, k) - AtLeastK(word, k + 1);
    }

    private long AtLeastK(string word, int k)
    {
        int n = word.Length;
        long count = 0;
        int start = 0, end = 0;
        var vowelCount = new Dictionary<char, int>();
        int consonantCount = 0;

        while (end < n)
        {
            char newLetter = word[end];

            if (isVowel(newLetter))
            {
                if (!vowelCount.ContainsKey(newLetter))
                {
                    vowelCount[newLetter] = 0;
                }
                vowelCount[newLetter]++;
            }
            else
            {
                consonantCount++;
            }

            // 윈도우 내에 모든 모음이 포함되어 있고, 자음이 k개 이상이면 조건을 만족
            while (vowelCount.Count == 5 && consonantCount >= k)
            {
                // 현재 윈도우 [start, end]가 조건을 만족하면, end부터 끝까지의 모든 부분문자열이 유효함
                count += n - end;
                char startLetter = word[start];
                if (isVowel(startLetter))
                {
                    vowelCount[startLetter]--;
                    if (vowelCount[startLetter] == 0)
                    {
                        vowelCount.Remove(startLetter);
                    }
                }
                else
                {
                    consonantCount--;
                }
                start++;
            }

            end++;
        }

        return count;
    }

    internal bool isVowel(char c)
    {
        return c == 'a' || c == 'e' || c == 'i' || c == 'o' || c == 'u';
    }
}
