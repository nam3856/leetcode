public class Solution {
    // Union-Find를 위한 부모 배열과 깊이 배열
    private int[] parent;
    private int[] depth;

    public int[] MinimumCost(int n, int[][] edges, int[][] queries) {
        // 각 노드가 독립된 컴포넌트에 속하도록 -1로 초기화
        parent = Enumerable.Repeat(-1, n).ToArray();
        depth = new int[n]; // 기본값 0
        
        // 각 컴포넌트의 비용을 모두 1로 초기화 (비트가 모두 1인 상태 = uint.MaxValue)
        uint[] componentCost = new uint[n];
        for (int i = 0; i < n; i++) {
            componentCost[i] = uint.MaxValue;
        }
        
        // 간선 정보를 통해 연결 컴포넌트를 구성
        foreach (var edge in edges) {
            Union(edge[0], edge[1]);
        }
        
        // 각 간선에 대해 해당 간선의 가중치와 컴포넌트 비용의 비트 AND 연산 수행
        foreach (var edge in edges) {
            int root = Find(edge[0]);
            // edge[2]를 uint로 캐스팅하여 AND 연산 수행
            componentCost[root] &= (uint)edge[2];
        }
        
        List<int> answer = new List<int>();
        // 각 쿼리에 대해 시작점과 끝점이 같은 컴포넌트에 속하는지 확인
        foreach (var query in queries) {
            int start = query[0];
            int end = query[1];
            
            if (Find(start) != Find(end)) {
                answer.Add(-1);
            } else {
                int root = Find(start);
                // 결과를 int로 캐스팅하여 반환
                answer.Add((int)componentCost[root]);
            }
        }
        
        return answer.ToArray();
    }
    
    // Find 함수: 경로 압축을 적용하여 노드의 루트를 찾음
    private int Find(int node) {
        if (parent[node] == -1) return node;
        return parent[node] = Find(parent[node]);
    }
    
    // Union 함수: 두 노드의 컴포넌트를 합침 (깊이에 따라 병합)
    private void Union(int node1, int node2) {
        int root1 = Find(node1);
        int root2 = Find(node2);
        
        // 이미 같은 컴포넌트에 속해 있다면 아무 작업도 하지 않음
        if (root1 == root2) return;
        
        // 깊이가 더 낮은 트리를 깊이가 높은 트리 아래에 붙임
        if (depth[root1] < depth[root2]) {
            int temp = root1;
            root1 = root2;
            root2 = temp;
        }
        
        parent[root2] = root1;
        if (depth[root1] == depth[root2]) {
            depth[root1]++;
        }
    }
}
