public class Solution 
{
    public int CountPaths(int n, int[][] roads) 
    {
        const int MOD = 1_000_000_007;
        
        // 1. 인접 리스트 생성 (무방향 그래프)
        List<int[]>[] graph = new List<int[]>[n];
        for (int i = 0; i < n; i++)
        {
            graph[i] = new List<int[]>();
        }
        foreach (var road in roads)
        {
            int startNode = road[0], endNode = road[1], travelTime = road[2];
            graph[startNode].Add(new int[] { endNode, travelTime });
            graph[endNode].Add(new int[] { startNode, travelTime });
        }
        
        // 2. 다익스트라 알고리즘을 위한 초기화
        // shortestTime[i] : 노드 0에서 i까지의 최단 시간
        // pathCount[i] : 최단 시간에 도달할 수 있는 경로의 개수
        long[] shortestTime = new long[n];
        int[] pathCount = new int[n];
        for (int i = 0; i < n; i++)
        {
            shortestTime[i] = long.MaxValue;
            pathCount[i] = 0;
        }
        shortestTime[0] = 0;
        pathCount[0] = 1;
        
        // 3. PriorityQueue (요소: (time, node), 우선순위: time)
        var minHeap = new PriorityQueue<(long time, int node), long>();
        minHeap.Enqueue((0, 0), 0);  // {현재 시간, 노드 번호}
        
        // 4. 다익스트라 알고리즘 수행
        while (minHeap.Count > 0)
        {
            var top = minHeap.Dequeue();
            long currTime = top.time;
            int currNode = top.node;
            
            // 이미 더 짧은 경로가 발견된 경우 건너뛰기
            if (currTime > shortestTime[currNode])
                continue;
            
            foreach (var neighbor in graph[currNode])
            {
                int neighborNode = neighbor[0];
                int roadTime = neighbor[1];
                
                long newTime = currTime + roadTime;
                // 더 짧은 경로를 찾은 경우: 최단 시간 갱신 후 경로의 개수도 갱신
                if (newTime < shortestTime[neighborNode])
                {
                    shortestTime[neighborNode] = newTime;
                    pathCount[neighborNode] = pathCount[currNode];
                    minHeap.Enqueue((newTime, neighborNode), newTime);
                }
                // 동일한 최단 시간이 발견된 경우: 경로의 개수 누적
                else if (newTime == shortestTime[neighborNode])
                {
                    pathCount[neighborNode] = (pathCount[neighborNode] + pathCount[currNode]) % MOD;
                }
            }
        }
        
        return pathCount[n - 1];
    }
}
