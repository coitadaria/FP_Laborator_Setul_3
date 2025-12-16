using System;

class Program
{
    static void Main()
    {
        Console.WriteLine("Programul interschimba elementele unui vector in asa fel incat la final toate valorile egale cu zero sa ajunga la sfarsit. ");
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

        int pozitie = 0;
        for(int i=0;i < n; i++)
        {
            if (vector[i] != 0)
            {
                int aux = vector[i];
                vector[i] = vector[pozitie];
                vector[pozitie] = aux;
                pozitie++;
            }
        }   
        Console.WriteLine("Vectorul cu zerouri la sfarsit este:");
        for (int i = 0; i < n; i++)
            Console.Write(vector[i] + " ");
    }
}