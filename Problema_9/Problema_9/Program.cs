using System;
class Program
{
    static void Main()
    {
        Console.WriteLine("Programul roteste elementele unui vector cu n elemente la stanga cu k pozitii.");
        Console.Write("Introduceti numarul de elemente (n): ");
        int n,k;
        while (!int.TryParse(Console.ReadLine(), out n) || n <= 0)
        {
            Console.Write("Va rog introduceti un numar intreg pozitiv pentru n: ");
        }
        Console.WriteLine($"Introduceti cele {n} elemente (separate prin spatiu): ");
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

        Console.WriteLine("Introduceti numarul k: ");
        while(!int.TryParse(Console.ReadLine(), out k) || k < 0)
        {
            Console.WriteLine("Va rog introduceti un numar intreg pozitiv pentru k: ");
        }

        k = k % n;
        if (k > 0)
        {
            Reverse(vector,0,k-1);
            Reverse(vector,k,n-1);
            Reverse(vector,0,n-1);
        }

        Console.WriteLine($"Vectorul dupa rotire la stanga cu {k} pozitii este:");
        for (int i = 0; i < n; i++)
        {
            Console.Write(vector[i] + " ");
        }
    }

    private static void Reverse(int[] vector, int inceput, int final)
    {
        while(inceput < final)
        {
            int copie = vector[inceput];
            vector[inceput] = vector[final];
            vector[final] = copie;
            inceput++;
            final--;
        }
    }
}