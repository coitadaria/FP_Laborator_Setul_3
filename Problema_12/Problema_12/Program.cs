using System;

class Program
{
    static void Main()
    {
        Console.WriteLine("Programul sorteaza un vector cu n elemente prin Selection Sort.");
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

        SelectionSort(vector);
        Console.WriteLine("Vectorul sortat este:");
        for (int i = 0; i < n; i++)
            Console.Write(vector[i] + " ");
    }

    private static void SelectionSort(int[] vector)
    {
        //algoritmul sorteaza cresatoare prin Selection Sort 
        int i, j, pozmin, minv;// pozmin - pozitia elementului minim, minv - valoarea elementului minim
        // pentru a sorta descrescator avem nevoie de pozmax si maxv
        for (i = 0; i < vector.Length - 1; i++)
        {
            minv = vector[i];
            pozmin = i;
            for(j=i+1;j < vector.Length; j++)
            {
                if (vector[j] < minv) //conditia pentru sortarea crescatoare, pentru sortare descrescatoare se schimba in ">"
                {
                    minv = vector[j];
                    pozmin = j;
                }
            }
            if(pozmin != i)
            {
                vector[pozmin] = vector[i];
                vector[i] = minv;
            }       
        }
    }
}