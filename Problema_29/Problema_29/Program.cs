using System;
class Program
{
    static void Main()
    {
        Console.WriteLine("Programul sorteaza un vector prin metoda Merge Sort.");
        int n;
        Console.Write("Introduceti numarul de elemente din vector: ");
        while (!int.TryParse(Console.ReadLine(), out n) || n <= 0)
        {
            Console.Write("Va rugam introduceti un numar valid de elemente: ");
        }
        int[] vector = new int[n];
        Console.WriteLine("Introduceti elementele vectorului (separate prin spatiu):");
        while (true)
        {
            string[] input = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
            if (input.Length != n)
            {
                Console.WriteLine($"Va rugam introduceti exact {n} elemente. Reintroduceti vectorul:");
                continue;
            }
            bool valid = true;
            for (int i = 0; i < n; i++)
            {
                if (!int.TryParse(input[i], out vector[i]))
                {
                    Console.WriteLine("Input invalid. Va rugam introduceti numere intregi. Reintroduceti vectorul:");
                    valid = false;
                    break;
                }
            }
            if (valid) break;
        }
        int[] vectoraux= new int[n];
        MergeSort(vector, vectoraux, 0, n - 1);

        Console.WriteLine($"Vectorul sortat este: ");
        Console.WriteLine(string.Join(" ", vector));
    }
    static void MergeSort(int[] vector, int[] vectoraux, int st, int dr)
    {
        if(st<dr)
        {
            int mijloc = (st + dr) / 2;
            MergeSort(vector, vectoraux, st, mijloc);
            MergeSort(vector, vectoraux, mijloc + 1, dr);
            Interclasare(vector, vectoraux, st, mijloc, dr);
        }
    }
    static void Interclasare(int[] vector, int[]vectoraux,int st,int mijloc,int dr)
    {
        int x = st;  //index din prima jumatate
        int y = mijloc + 1;  //index din a doua jumatate
        int k = 0;  // index in vectorul auxiliar

        while(x<=mijloc && y<=dr)
        {
            if (vector[x] < vector[y])
                vectoraux[k++] = vector[x++];
            else
                vectoraux[k++] = vector[y++];
        }
        while (x <= mijloc)
        {
            vectoraux[k++] = vector[x++];
        }
        while (y <= dr)
        {
            vectoraux[k++] = vector[y++];
        }
        for (int i = 0; i < k; i++)
        {
            vector[st + i] = vectoraux[i];
        }
    }
}