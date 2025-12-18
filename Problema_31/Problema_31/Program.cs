using System;
class Program
{
    static void Main()
    {
        Console.WriteLine("Programul determina elementul majoritate al unui vector.");
        Console.WriteLine("Introduceti numarul de elemente (n): ");
        int n;
        while (!int.TryParse(Console.ReadLine(), out n) || n <= 0)
        {
            Console.Write("Numar invalid. Introduceti un numar intreg pozitiv: ");
        }

        int[] vector = new int[n];
        Console.WriteLine("Introduceti elementele vectorului (separate prin spatiu): ");
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
        int elementulMajoritar = GasireElementMajoritate(vector);

        if (elementulMajoritar != int.MinValue)
            Console.WriteLine($"Elementul majoritate este: {elementulMajoritar}.");
        else
            Console.WriteLine("Nu exista element majoritate in vector.");
    }
    static int GasireElementMajoritate(int[] vector)
    {
        if (vector.Length == 0) return int.MinValue;

        int curent = vector[0];
        int count = 1;

        for (int i = 1; i < vector.Length; i++)
        {
            if (vector[i] == curent)
            {
                count++;
            }
            else
            {
                count--;
                if (count == 0)
                {
                    curent = vector[i];
                    count = 1;
                }
            }
        }
        count = 0;
        foreach (var item in vector)
        {
            if (item == curent) count++;
        }
        if (count > vector.Length / 2)
            return curent;
        else
            return int.MinValue;
    }
}