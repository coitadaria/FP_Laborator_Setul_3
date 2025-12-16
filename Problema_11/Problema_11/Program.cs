using System;
class Program
{
    static void Main()
    {
        Console.WriteLine("Programul determina toate numerele prime mai mici sau elage cu n (ciurul lui Eratostene).");
        Console.Write("Introduceti un numar natural n: ");
        int n;
        while (!int.TryParse(Console.ReadLine(), out n) || n < 0)
        {
            Console.Write("Input invalid. Va rugam introduceti un numar natural: ");
        }
        bool[] estePrim = new bool[n + 1];

        for (int i = 2; i <= n; i++)
        {
            estePrim[i] = true;
        }
        if(n== 0) estePrim[0] = false;
        if (n == 1) estePrim[1] = false;

        for(int i=2;i*i<=n;i++)
        {
            if (estePrim[i])
            {
                for (int j = i * i; j <= n; j += i)
                {
                    estePrim[j] = false;
                }
            }
        }

        Console.WriteLine($"Numerele prime mai mici sau egale cu {n} sunt: ");
        int count = 0;
        for (int i = 2; i <= n; i++)
        {
            if (estePrim[i])
            {
                Console.Write(i + " ");
                count++;
            }
        }
        Console.WriteLine();
        Console.WriteLine($"In total sunt {count} numere prime mai mici sau egale cu {n}.");
    }
}
