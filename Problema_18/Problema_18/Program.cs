using System;

class Program
{
    static void Main()
    {
        Console.WriteLine("Programul calculeaza valoarea unui polinom de grad n intr-un punct x.");
        Console.Write("Introduceti gradul polinomului n: ");
        int n;
        while (!int.TryParse(Console.ReadLine(), out n) || n < 0)
        {
            Console.Write("Gradul polinomului trebuie sa fie un numar intreg pozitiv.");
        }
        double[] coeficienti = new double[n + 1];

        Console.WriteLine("Introduceti coeficientii polinomului de la a0 la an (a0 fiind termenul liber) :");
        for (int i = 0; i <= n; i++)
        {
            Console.Write($"a{i}: ");
            while (!double.TryParse(Console.ReadLine(), out coeficienti[i]))
            {
                Console.Write("Coeficientul trebuie sa fie un numar valid. ");
            }
        }
        Console.Write("Introduceti valoarea punctului x: ");
        double x;
        while (!double.TryParse(Console.ReadLine(), out x))
        {
            Console.Write("Valoarea punctului trebuie sa fie un numar valid. ");
        }
        // pentru calcul se foloeste schema lui Horner
        double rezultat = coeficienti[n];

        for(int i=n-1;i>=0;i--)
        {
            rezultat= rezultat * x + coeficienti[i];
        }
        Console.WriteLine($"Valoarea polinomului in punctul x={x} este: {rezultat}.");
    }
}