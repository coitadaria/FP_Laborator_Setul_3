using System;
class Program
{
    static void Main()
    {
        Console.WriteLine("Programul determina pozitiile dintr-un vector pe care apar cel mai mic si cel mai mare element al vectorului.");
        Console.Write("Introduceti numarul de elemente din vector (n): ");
        int n;
        while (!int.TryParse(Console.ReadLine(), out n) || n <= 0)
        {
            Console.Write("Va rugam sa introduceti un numar intreg pozitiv pentru n: ");
        }
        Console.WriteLine($"Introdu {n} numere separate prin spatiu:");
        int[] v = new int[n];
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
                if (!int.TryParse(input[i], out v[i]))
                {
                    Console.WriteLine("Input invalid. Va rugam introduceti numere intregi.Reintroduceti vectorul:");
                    valid = false;
                    break;
                }
            }
            if (valid) break;
        }

        int min, max, pozMin, pozMax;

        if (n % 2 == 0)
        {
            if (v[0] < v[1])
            {
                min = v[0];
                pozMin = 0;
                max = v[1];
                pozMax = 1;
            }
            else
            {
                min = v[1];
                pozMin = 1;
                max = v[0];
                pozMax = 0;
            }
        }
        else
        {
            min = max = v[0];
            pozMin = pozMax = 0;
        }
        int inceput;
        if (n % 2 == 0)
            inceput = 2;
        else
            inceput = 1;
        for (int i = inceput; i < n; i += 2)
        {
            if (v[i] < v[i + 1])
            {
                if (v[i] < min)
                {
                    min = v[i];
                    pozMin = i;
                }

                if (v[i + 1] > max)
                {
                    max = v[i + 1];
                    pozMax = i + 1;
                }
            }
            else
            {
                if (v[i + 1] < min)
                {
                    min = v[i + 1];
                    pozMin = i + 1;
                }

                if (v[i] > max)
                {
                    max = v[i];
                    pozMax = i;
                }
            }
        }
        Console.WriteLine($"Minimul este {min} si se afla pe pozitia {pozMin}.");
        Console.WriteLine($"Maximul este {max} si se afla pe pozitia {pozMax}.");
    }
}