using System;
class Program
{
    static void Main()
    {
        Console.WriteLine("Programul calculeaza suma elementelor unui vector de n numere citite de la tastatura.");
        Console.Write("Introduceti numarul de elemente (n): ");
        int n;
        while (!int.TryParse(Console.ReadLine(), out n) || n <= 0)
        {
            Console.Write("Va rugam sa introduceti un numar intreg pozitiv pentru n: ");
        }
        Console.WriteLine($"Introduceti cele {n} numere (separate prin spatiu):");

        int suma = 0;
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
                if (!int.TryParse(input[i], out int numar))
                {
                    Console.WriteLine("Input invalid. Va rugam introduceti numere intregi.Reintroduceti vectorul:");
                    valid = false;
                    suma = 0;
                    break;
                }
                suma += numar;
            }
            if (valid) break;
        }

        Console.WriteLine($"Suma elementelor vectorului este: {suma}.");
    }
}