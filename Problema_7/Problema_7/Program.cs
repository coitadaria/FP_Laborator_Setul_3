using System;
class Program
{
    static void Main()
    {
        Console.WriteLine("Programul inverseaza ordinea elementelor dintr-un vector cu n elemente.");
        Console.Write("Introduceti numarul de elemente (n): ");
        int n;
        while (!int.TryParse(Console.ReadLine(), out n) || n <= 0)
        {
            Console.Write("Va rog introduceti un numar intreg pozitiv pentru n: ");
        }
        int[] vector = new int[n];
        Console.WriteLine("Introduceti elementele vectorului (separate prin spatiu):");
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
                if (!int.TryParse(input[i], out vector[i]))
                {
                    Console.WriteLine("Input invalid. Va rugam introduceti numere intregi.Reintroduceti vectorul:");
                    valid = false;
                    break;
                }
            }
            if (valid) break;
        }


        // Array.Reverse(vector);
        for (int i = 0; i < n / 2; i++)
        {
            int copie = vector[i];
            vector[i] = vector[n - 1 - i];
            vector[n - 1 - i] = copie;
        }
        Console.WriteLine("Vectorul inversat este:");
        for (int i = 0; i < n; i++)
        {
            Console.Write(vector[i] + " ");
        }
    }
}