using System;
class Program
{
    static void Main()
    {
        Console.WriteLine("Programul sterge din vectorul de n elemente elementul de pe pozitia k.");
        int n;
        Console.WriteLine("Introduceti numarul de elemente (n): ");
        while (!int.TryParse(Console.ReadLine(), out n) || n <= 0)
        {
            Console.WriteLine("Va rugam sa introduceti un numar intreg pozitiv pentru n:");
        }
        Console.WriteLine($"Introduceti cele {n} numere separate prin spatiu:");
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

        Console.WriteLine("Introduceti pozitia k pentru stergere:");
        int k;
        while (!int.TryParse(Console.ReadLine(), out k) || k < 0 || k >= n)
        {
            Console.WriteLine($"Va rugam sa introduceti o pozitie valida k intre 0 si {n-1}:");
        }

        for (int i = k; i < n - 1; i++)
        {
            vector[i] = vector[i+1];
        }
        Console.WriteLine("Vectorul dupa stergere este:");
        for (int i = 0; i < n - 1; i++)
        {
            Console.Write(vector[i] + " ");
        }
    }
}