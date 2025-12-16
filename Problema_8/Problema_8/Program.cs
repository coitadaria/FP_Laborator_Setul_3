using System;
class Program
{
    static void Main()
    {
        Console.WriteLine("Programul roteste elementele unui vector cu n elemente la stanga cu o pozitie.");
        Console.Write("Introduceti numarul de elemente (n): ");
        int n;
        while(!int.TryParse(Console.ReadLine(), out n) || n <= 0)
        {
            Console.Write("Va rog introduceti un numar intreg pozitiv pentru n: ");
        }
        int[] vector = new int[n];
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

        int primul = vector[0];
        for (int i = 0; i < n - 1; i++)
        {
            vector[i] = vector[i + 1];
        }
        vector[n - 1] = primul;
        Console.WriteLine("Vectorul dupa rotire la stanga cu o pozitie este:");
        for (int i = 0; i < n; i++)
        {
            Console.Write(vector[i] + " ");
        }
    }
}