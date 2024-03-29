int count = 0;
int[] NK = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
int[] arr = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
MergeSort(arr, 0, arr.Length - 1);
if (count < NK[1])
{
    Console.WriteLine(-1);
}

void MergeSort(int[] arr, int p, int r)
{
    if (p < r)
    {
        int q = (p + r) / 2;
        MergeSort(arr, p, q);
        MergeSort(arr, q + 1, r);
        Merge(arr, p, q, r);
    }
}

void Merge(int[] arr, int p, int q, int r)
{
    int i, j, k;
    int n1 = q - p + 1;
    int n2 = r - q;
    int[] L = new int[n1];
    int[] R = new int[n2];

    for (i = 0; i < n1; ++i)
        L[i] = arr[p + i];

    for (j = 0; j < n2; ++j)
        R[j] = arr[q + 1 + j];

    i = 0;
    j = 0;
    k = p;

    while (i < n1 && j < n2)
    {
        if (L[i] <= R[j])
        {
            arr[k] = L[i];
            i++;
        }
        else
        {
            arr[k] = R[j];
            j++;
        }

        count++;
        if (count == NK[1])
        {
            Console.WriteLine(arr[k]);
            return; 
        }
        k++;
    }

    while (i < n1)
    {
        arr[k] = L[i];
        i++;

        count++;
        if (count == NK[1])
        {
            Console.WriteLine(arr[k]);
            return; 
        }
        k++;
    }

    while (j < n2)
    {
        arr[k] = R[j];
        j++;

        count++;
        if (count == NK[1])
        {
            Console.WriteLine(arr[k]);
            return; 
        }
        k++;
    }
}
