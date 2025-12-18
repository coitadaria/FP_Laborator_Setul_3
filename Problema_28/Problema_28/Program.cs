using System;

class Program
{
    static void Main()
    {
        Console.WriteLine("Programul sorteaza un vector prin metoda QuickSort.");
        int n;
        Console.WriteLine("Introduceti dimensiunea vectorului:");
        while (!int.TryParse(Console.ReadLine(), out n) || n <= 0)
        {
            Console.WriteLine("Introduceti un numar natural valid pentru dimensiunea vectorului:");
        }
        int[] vector = new int[n];
        Console.WriteLine($"Introduceti {n} numere (separate prin spatiu):");

        while (true)
        {
            string[] input = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);

            if (input.Length != n)
            {
                Console.WriteLine($"Trebuie exact {n} numere! Ati introdus {input.Length}. Reintroduceti vectorul:");
                continue;
            }

            bool valid = true;
            for (int i = 0; i < n; i++)
            {
                if (!int.TryParse(input[i], out vector[i]))
                {
                    Console.WriteLine($"'{input[i]}' invalid. Reintroduceti vectorul:");
                    valid = false;
                    break;
                }
            }

            if (valid) break;
        }
        QuickSort(vector, 0, n - 1);
        Console.WriteLine("Vectorul sortat este:");
        Console.WriteLine(string.Join(" ", vector));
    }
    static void QuickSort(int[] vector,int st,int dr)
    {
        if(st<dr)
        {
            int mijloc = Pivot(vector, st, dr);
            QuickSort(vector, st, mijloc - 1);
            QuickSort(vector, mijloc + 1, dr);
        }
    }
    static int Pivot(int[] vector,int st,int dr)
    {
        int aux = vector[st];
        while(st<dr)
        {
            while(st< dr && vector[dr] >= aux)
                dr--;
            vector[st] = vector[dr];
            while (st < dr && vector[st] <= aux)
                st++;
            vector[dr] = vector[st];
        }
        vector[st] = aux;
        return st;
    }
}