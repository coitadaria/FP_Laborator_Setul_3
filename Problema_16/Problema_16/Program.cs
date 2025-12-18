using System;
class Program
{
    static void Main()
    {
        Console.WriteLine("Programul determina cel mai mare divizor comun al elementelor vectorului cu n elemente.");
        Console.Write("Introduceti numarul de elemente (n): ");
        int n;
        while(!int.TryParse(Console.ReadLine(), out n) || n <= 0)
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


        int cmmdcrezultat = vector[0];
        for (int i = 1; i < n; i++)
        {
            cmmdcrezultat = Cmmdc(cmmdcrezultat, vector[i]);
        }

        Console.WriteLine($"Cel mai mare divizor comun al elementelor vectorului este: {cmmdcrezultat}.");
    }

    private static int Cmmdc(int a, int b) // algoritmul lui Euclid
    {
        int r = a % b;
        while(r != 0)
        {
            a = b;
            b = r;
            r = a % b;
        }
        return b;
    }
}