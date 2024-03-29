class Program
{
    static List<int>[] graph;
    static bool[] visited;

    static void Main(string[] args)
    {
        int[] input = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
        int N = input[0]; // 정점의 개수
        int M = input[1]; // 간선의 개수
        int V = input[2]; // 시작 정점

        graph = new List<int>[N + 1];
        visited = new bool[N + 1];

        for (int i = 1; i <= N; i++)
        {
            graph[i] = new List<int>();
        }

        // 그래프 정보 입력
        for (int i = 0; i < M; i++)
        {
            int[] edge = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
            int u = edge[0];
            int v = edge[1];
            graph[u].Add(v);
            graph[v].Add(u); // 양방향 그래프이므로 반대 방향도 추가
        }

        // 각 정점의 인접 리스트를 오름차순으로 정렬
        for (int i = 1; i <= N; i++)
        {
            graph[i].Sort();
        }

        // DFS 수행
        DFS(V);
        Console.WriteLine();

        // BFS 수행
        visited = new bool[N + 1]; // BFS를 위해 visited 배열 초기화
        BFS(V);
    }

    // 깊이 우선 탐색(DFS)
    static void DFS(int v)
    {
        visited[v] = true;
        Console.Write(v + " ");

        foreach (int next in graph[v])
        {
            if (!visited[next])
                DFS(next);
        }
    }

    // 너비 우선 탐색(BFS)
    static void BFS(int start)
    {
        Queue<int> queue = new Queue<int>();
        queue.Enqueue(start);
        visited[start] = true;

        while (queue.Count > 0)
        {
            int v = queue.Dequeue();
            Console.Write(v + " ");

            foreach (int next in graph[v])
            {
                if (!visited[next])
                {
                    visited[next] = true;
                    queue.Enqueue(next);
                }
            }
        }
    }
}
