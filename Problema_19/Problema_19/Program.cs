using System;
class Program
{
    static void Main()
    {
        Console.WriteLine("Programul determina de cate ori apare vectorul p in vectorul s.");
        // citirea datelor
        Console.Write("Introduceti dimensiunea vectorului s: ");
        int n, m;
        while (!int.TryParse(Console.ReadLine(), out n) || n <= 0)
        {
            Console.Write("Dimensiunea trebuie sa fie un numar intreg pozitiv. Introduceti alta valoare: ");
        }
        int[] s = new int[n]; // vectorul s din enunt
        Console.WriteLine("Introduceti elementele vectorului s (separate prin spatiu): ");
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
                if (!int.TryParse(input[i], out s[i]))
                {
                    Console.WriteLine("Input invalid. Va rugam introduceti numere intregi.Reintroduceti vectorul:");
                    valid = false;
                    break;
                }
            }
            if (valid) break;
        }


        Console.Write("Introduceti dimensiunea vectorului p: ");
        while (!int.TryParse(Console.ReadLine(), out m) || m <= 0 || m > n)
        {
            Console.Write("Dimensiunea trebuie sa fie un numar intreg pozitiv si mai mica sau egala decat dimensiunea lui s. Introduceti alta valoare: ");
        }
        int[] p = new int[m]; // vectorul p din enunt
        Console.WriteLine("Introduceti elementele vectorului p (separate prin spatiu): ");
        while (true)
        {
            string[] input = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            if (input.Length != m)
            {
                Console.WriteLine($"Va rugam introduceti exact {m} elemente. Reintroduceti vectorul: ");
                continue;
            }
            bool valid = true;
            for (int i = 0; i < m; i++)
            {
                if (!int.TryParse(input[i], out p[i]))
                {
                    Console.WriteLine("Input invalid. Va rugam introduceti numere intregi.Reintroduceti vectorul:");
                    valid = false;
                    break;
                }
            }
            if (valid) break;
        }

        // prelucrarea datelor
        int count = 0;
        bool estePotrivit;
        for (int i = 0; i <= n - m; i++)
        {
             estePotrivit = true;
            for (int j = 0; j < m; j++)
            {
                if (s[i + j] != p[j])
                {
                    estePotrivit = false;
                    break;
                }
            }
            if (estePotrivit)
            {
                count++;
            }
        }
        // afisarea rezultatului
        Console.WriteLine($"Vectorul p apare de {count} ori in vectorul s.");
    }
}