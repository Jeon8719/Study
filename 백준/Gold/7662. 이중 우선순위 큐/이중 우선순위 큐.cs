using System.Text;

class Program
{
    
    static void Main(string[] args)
    {
        StringBuilder sb = new StringBuilder();
        int T = int.Parse(Console.ReadLine());

        for (int j = 0; j < T; j++)
        {
            var maxH = new PriorityQueue<(int, int)>((x, y) => y.Item1.CompareTo(x.Item1)); // Max heap
            var minH = new PriorityQueue<(int, int)>((x, y) => x.Item1.CompareTo(y.Item1)); // Min heap

            int N = int.Parse(Console.ReadLine());

            bool[] visit = new bool[N];

            for (int i = 0; i < N; i++)
            {
                string[] input = Console.ReadLine().Split();
                char cmd = input[0][0];
                int num = int.Parse(input[1]);

                if (cmd == 'I')
                {
                    maxH.Enqueue((num, i));
                    minH.Enqueue((num, i));
                    visit[i] = true;
                }
                else
                {
                    if (num == 1)
                    {
                        while (!maxH.IsEmpty() && !visit[maxH.Peek().Item2])
                        {
                            maxH.Dequeue();
                        }
                        if (!maxH.IsEmpty())
                        {
                            visit[maxH.Peek().Item2] = false;
                            maxH.Dequeue();
                        }
                    }
                    else
                    {
                        while (!minH.IsEmpty() && !visit[minH.Peek().Item2])
                        {
                            minH.Dequeue();
                        }
                        if (!minH.IsEmpty())
                        {
                            visit[minH.Peek().Item2] = false;
                            minH.Dequeue();
                        }
                    }
                }
            }

            while (!maxH.IsEmpty() && !visit[maxH.Peek().Item2])
            {
                maxH.Dequeue();
            }
            while (!minH.IsEmpty() && !visit[minH.Peek().Item2])
            {
                minH.Dequeue();
            }

            if (minH.IsEmpty() && maxH.IsEmpty())
            {
                sb.AppendLine("EMPTY");
            }
            else
            {
                sb.AppendLine($"{maxH.Peek().Item1} {minH.Peek().Item1}");
            }
        }
        Console.WriteLine( sb.ToString() );
    }
}

public class PriorityQueue<T>
{
    private List<T> data;
    private Func<T, T, int> comparer;

    public int Count => data.Count;

    public bool IsEmpty() => data.Count == 0;

    public PriorityQueue(Func<T, T, int> customComparer)
    {
        data = new List<T>();
        comparer = customComparer;
    }

    public void Enqueue(T item)
    {
        data.Add(item);
        int currentIndex = data.Count - 1;

        while (currentIndex > 0)
        {
            int parentIndex = (currentIndex - 1) / 2;
            if (comparer(data[currentIndex], data[parentIndex]) >= 0)
                break;

            SwapElements(currentIndex, parentIndex);
            currentIndex = parentIndex;
        }
    }

    public T Dequeue()
    {
        if (data.Count == 0)
            throw new InvalidOperationException("Priority queue is empty.");

        int lastIndex = data.Count - 1;
        T frontItem = data[0];
        data[0] = data[lastIndex];
        data.RemoveAt(lastIndex);

        lastIndex--;
        int parentIndex = 0;

        while (true)
        {
            int leftChildIndex = parentIndex * 2 + 1;

            if (leftChildIndex > lastIndex)
                break;

            int rightChildIndex = leftChildIndex + 1;
            if (rightChildIndex <= lastIndex && comparer(data[rightChildIndex], data[leftChildIndex]) < 0)
                leftChildIndex = rightChildIndex;

            if (comparer(data[parentIndex], data[leftChildIndex]) <= 0)
                break;

            SwapElements(parentIndex, leftChildIndex);
            parentIndex = leftChildIndex;
        }

        return frontItem;
    }

    public T Peek()
    {
        if (data.Count == 0)
            throw new InvalidOperationException("Priority queue is empty.");
        return data[0];
    }

    private void SwapElements(int index1, int index2)
    {
        T temp = data[index1];
        data[index1] = data[index2];
        data[index2] = temp;
    }
}
