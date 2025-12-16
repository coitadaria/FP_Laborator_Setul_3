using System;
class Program
{
    static void Main()
    {
        Console.WriteLine("Programul modifica un vector cu n elemente prin eliminarea elementelor care se repeta. ");
        Console.Write("Introduceti numarul de elemente (n): ");
        int n;
        while (!int.TryParse(Console.ReadLine(), out n) || n <= 0)
        {
            Console.Write("Va rugam sa introduceti un numar intreg pozitiv pentru n: ");
        }
        int[] vector = new int[n];
        Console.WriteLine($"Introduceti cele {n} elemente ale vectorului (separate prin spatiu): ");
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


        int nouadimensiune = n;

        for (int i = 0; i < nouadimensiune; i++)
        {
            for (int j = i + 1; j < nouadimensiune; j++)
            {
                if (vector[i] == vector[j])
                {
                    for (int k = j; k < nouadimensiune - 1; k++)
                    {
                        vector[k] = vector[k + 1];
                    }
                    nouadimensiune--;
                    j--;
                }
            }
        }
        Console.WriteLine("Vectorul fara elementele care se repete este:");
        for (int i = 0; i < nouadimensiune; i++)
            Console.Write(vector[i] + " ");
    }
}