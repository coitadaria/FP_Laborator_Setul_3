using System;
class Program
{
    static void Main()
    {
        Console.WriteLine("Programul determine prima pozitie dintr-un vector de n elemente pe care apare k.");
        Console.Write("Introduceti numarul de elemente din vector (n): ");
        int n;
        while(!int.TryParse(Console.ReadLine(), out n) || n <= 0)
        {
            Console.Write("Va rugam sa introduceti un numar intreg pozitiv pentru n: ");
        }
        Console.WriteLine($"Introdu {n} numere separate prin spatiu:");

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

        Console.Write("Introduceti valoarea k: ");
        int k;
        while (!int.TryParse(Console.ReadLine(), out k))
        {
            Console.Write("Va rugam sa introduceti un numar intreg pentru k: ");
        }
        int pozitie = -1;
        for (int i = 0; i < vector.Length; i++)
        {
            if (vector[i] == k)
            {
                pozitie = i;
                break;
            }
        }
        if (pozitie != -1)
        {
            Console.WriteLine($"Prima pozitie pe care apare {k} este: {pozitie}.");
        }
        else
        {
            Console.WriteLine($"{k} nu apare in vector. Pozitia este {pozitie}.");
        }
    }
}