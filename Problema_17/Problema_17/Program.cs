using System;
using System.Text;

class Program
{
    static void Main()
    {
        Console.WriteLine("Programul converteste un numar n din baza 10 in baza b (2 <= b <= 16).");
        Console.Write("Introduceti un numar n in baza 10: ");
        int n, b;
        while (!int.TryParse(Console.ReadLine(), out n) || n < 0)
        {
            Console.Write("Numar invalid. Introduceti un numar n in baza 10 (n >= 0): ");
        }
        Console.Write("Introduceti baza b (2 <= b <= 16): ");
        while (!int.TryParse(Console.ReadLine(), out b) || b < 2 || b > 16)
        {
            Console.Write("Baza invalida. Introduceti baza b (2 <= b <= 16): ");
        }
        string rezultat = ConversieDinBaza10(n,b);
        Console.WriteLine($"Numarul {n} in baza {b} este: {rezultat}");

    }

    private static string ConversieDinBaza10(int n, int b)
    {
        if(n==0) return "0";
        char[] cifre= "0123456789ABCDEF".ToCharArray();
        StringBuilder rezultat = new StringBuilder();

        while(n>0)
        {
            int rest = n % b;
            char cifra = cifre[rest];
            rezultat.Insert(0, cifra);
            n = n / b;
        }
        return rezultat.ToString();
    }
}