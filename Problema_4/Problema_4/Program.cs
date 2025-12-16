using System;
class Program
{
    static void Main()
    {
        Console.WriteLine("Programul determina cea mai mica si cea mai mare valoare dintr-un vector si de cate ori apar acestea.");
        Console.Write("Introduceti numarul de elemente din vector (n): ");
        int n;
        while (!int.TryParse(Console.ReadLine(), out n) || n <= 0)
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

        int min = int.MaxValue, max = int.MinValue;
        int countMin = 0, countMax = 0;
        for (int i = 0; i < n; i++)
        {
            if (vector[i] < min)
            {
                min = vector[i];
                countMin = 1;
            }
            else
                if (vector[i] == min)
                countMin++;
            if (vector[i] > max)
            {
                max = vector[i];
                countMax = 1;
            }
            else
                if (vector[i] == max)
                countMax++;
        }
        Console.WriteLine($"Cea mai mica valoare este {min} si apare de {countMin} ori.");
        Console.WriteLine($"Cea mai mare valoare este {max} si apare de {countMax} ori.");
    }
}