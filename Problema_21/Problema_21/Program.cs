using System;
class Program
{
    static void Main()
    {
        Console.WriteLine("Programul determina ordinea lexicografica a doi vectori.");
        Console.Write("Introduceti dimensiunea primului vector: ");
        int n, m;
        while (!int.TryParse(Console.ReadLine(), out n) || n <= 0)
        {
            Console.Write("Dimensiunea trebuie sa fie un numar natural. Introduceti alt numar: ");
        }
        int[] vector1 = new int[n];
        Console.WriteLine("Introduceti elementele primului vector (separate prin spatiu): ");
        while (true)
        {
            string[] input = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            if (input.Length != n)
            {
                Console.WriteLine($"Va rugam introduceti exact {n} elemente. Reintroduceti vectorul: ");
                continue;
            }
            bool valid = true;
            for (int i = 0; i < n; i++)
            {
                if (!int.TryParse(input[i], out vector1[i]))
                {
                    Console.WriteLine("Input invalid. Va rugam introduceti numere intregi.Reintroduceti vectorul:");
                    valid = false;
                    break;
                }
            }
            if (valid) break;
        }

        Console.WriteLine("Introduceti dimeniunea celui de-al doilea vector: ");
        while(!int.TryParse(Console.ReadLine(), out m) || m <= 0)
        {
            Console.Write("Dimensiunea trebuie sa fie un numar natural. Introduceti alt numar: ");
        }
        int[] vector2 = new int[m];
        Console.WriteLine("Introduceti elementele celui de-al doilea vector (separate prin spatiu): ");
        while (true)
        {
            string[] input = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            if (input.Length != m)
            {
                Console.WriteLine($"Va rugam introduceti exact {m} elemente. Reintroduceti vectorul: ");
                continue;
            }
            bool valid = true;
            for (int i = 0; i < m; i++)
            {
                if (!int.TryParse(input[i], out vector2[i]))
                {
                    Console.WriteLine("Input invalid. Va rugam introduceti numere intregi.Reintroduceti vectorul:");
                    valid = false;
                    break;
                }
            }
            if (valid) break;
        }

        int rezultat =ComparareLexicografica(vector1,vector2);
        if(rezultat < 0)
            Console.WriteLine("Primul vector este inaintea celui de-al doilea vector in ordinea lexicografica.");
        else if (rezultat > 0)
            Console.WriteLine("Al doilea vector este inaintea primului vector in ordinea lexicografica.");
        else
            Console.WriteLine("Cei doi vectori sunt egali.");
    }

    private static int ComparareLexicografica(int[] vector1, int[] vector2)
    {
        int minLength = Math.Min(vector1.Length, vector2.Length);

        for(int i=0;i<vector1.Length;i++)
        {
            if (vector1[i] < vector2[i])
                return -1;
            else
                if (vector1[i] > vector2[i])
                return 1;
        }
        if(vector1.Length < vector2.Length)
            return -1;
        else
            if (vector1.Length > vector2.Length)
            return 1;
        else
            return 0;

    }
}