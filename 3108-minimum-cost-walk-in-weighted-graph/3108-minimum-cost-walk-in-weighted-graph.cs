public class Solution {
    public int[] MinimumCost(int n, int[][] edges, int[][] queries) {
        // 인접 리스트 생성 (각 노드별 이웃과 가중치 정보를 저장)
        List<List<(int neighbor, int weight)>> adjList = new List<List<(int, int)>>();
        for (int i = 0; i < n; i++) {
            adjList.Add(new List<(int, int)>());
        }
        foreach (var edge in edges) {
            int u = edge[0], v = edge[1], w = edge[2];
            adjList[u].Add((v, w));
            adjList[v].Add((u, w));
        }

        bool[] visited = new bool[n];
        int[] components = new int[n];
        List<int> componentCost = new List<int>();

        int componentId = 0;
        // 방문하지 않은 각 노드에 대해 DFS를 수행하여 컴포넌트별 비용 계산
        for (int node = 0; node < n; node++) {
            if (!visited[node]) {
                componentCost.Add(GetComponentCost(node, adjList, visited, components, componentId));
                componentId++;
            }
        }

        List<int> answer = new List<int>();
        // 각 쿼리에 대해 시작점과 끝점이 같은 컴포넌트에 속하는지 확인 후 결과 저장
        foreach (var query in queries) {
            int start = query[0];
            int end = query[1];

            if (components[start] == components[end]) {
                answer.Add(componentCost[components[start]]);
            } else {
                answer.Add(-1);
            }
        }

        return answer.ToArray();
    }

    // DFS를 통해 컴포넌트의 비용을 계산하는 도우미 함수
    private int GetComponentCost(int node, List<List<(int, int)>> adjList, bool[] visited, int[] components, int componentId) {
        int currentCost = int.MaxValue; // 모든 비트가 1인 상태 (C++의 INT_MAX와 동일)
        components[node] = componentId;
        visited[node] = true;

        foreach (var (neighbor, weight) in adjList[node]) {
            // 간선 가중치와 현재 비용의 비트 AND 연산
            currentCost &= weight;
            if (!visited[neighbor]) {
                currentCost &= GetComponentCost(neighbor, adjList, visited, components, componentId);
            }
        }
        return currentCost;
    }
}
