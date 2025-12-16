using System;
class Program
{
    static void Main()
    {
        Console.WriteLine("Programul insereaza valoarea e in vectorul de n elemente pe pozitia k.");
        int n;
        Console.WriteLine("Introduceti numarul de elemente (n): ");
        while (!int.TryParse(Console.ReadLine(), out n) || n <= 0)
        {
            Console.WriteLine("Va rugam sa introduceti un numar intreg pozitiv pentru n:");
        }
        Console.WriteLine($"Introduceti cele {n} numere separate prin spatiu:");
        
        int[] vector = new int[n+1];

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


        Console.WriteLine("Introduceti valoarea e de inserat:");
        int e;
        while (!int.TryParse(Console.ReadLine(), out e))
        {
            Console.WriteLine("Va rugam sa introduceti un numar intreg valid pentru e:");
        }
        Console.WriteLine("Introduceti pozitia k unde doriti sa inserati valoarea e:");
        int k;
        while (!int.TryParse(Console.ReadLine(), out k) || k < 0 || k > n)
        {
            Console.WriteLine($"Va rugam sa introduceti o pozitie valida k intre 0 si {n}:");
        }

        for (int i = n - 1; i >= k; i--)
        {
            vector[i+1] = vector[i];
        }
        vector[k] = e;
        Console.WriteLine("Vectorul dupa inserare este:");
        for (int i = 0; i <= n; i++)
        {
            Console.Write(vector[i] + " ");
        }
    }
}