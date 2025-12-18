using System;
class Program
{
    static void Main()
    {
        Console.WriteLine("Programul sorteaza vectorii bicriterial (crescator dupa valoare, descrescator dupa pondere).");
        Console.WriteLine("Introduceti numarul de elemente (n): ");
        int n;
        while(!int.TryParse(Console.ReadLine(), out n) || n<=0)
        {
            Console.Write("Numar invalid. Introduceti un numar intreg pozitiv: ");
        }

        int[] E=new int[n];
        Console.WriteLine("Introduceti elementele vectorului E (numere separate prin spatiu): ");
        while(true)
        {
            string[] input=Console.ReadLine().Split(" ",StringSplitOptions.RemoveEmptyEntries);
            if (input.Length!=n)
            {
                Console.WriteLine($"Va rugam introduceti exact {n} elemente. Reintroduceti vectorul: ");
                continue;
            }
            bool valid = true;
            for(int i=0;i<n;i++)
            {
                if(!int.TryParse(input[i],out E[i]))
                {
                    Console.WriteLine("Input invalid. Va rugam introduceti numere intregi.Reintroduceti vectorul:");
                    valid = false;
                    break;
                }
            }
            if (valid) break;
        }

        int[] W=new int[n];
        Console.WriteLine("Introduceti elementele vectorului W care contine ponderea numerelor din vectorul E (separate prin spatiu): ");

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
                if (!int.TryParse(input[i], out W[i]))
                {
                    Console.WriteLine("Input invalid. Va rugam introduceti numere intregi.Reintroduceti vectorul:");
                    valid = false;
                    break;
                }
            }
            if (valid) break;
        }

        SortareBicriteriala(E, W);

        Console.WriteLine("Vectorii dupa sortare sunt: ");
        Console.Write("E: ");
        foreach(int val in E)
             Console.Write(val + " ");
        Console.WriteLine();
        Console.Write("W: ");
        foreach (int pondere in W)
            Console.Write(pondere + " ");
    }

    static void SortareBicriteriala(int[] E, int[] W)
    {
        for(int i=0;i<E.Length-1;i++)
        {
            for (int j = 0; j < W.Length-i-1; j++)
            {
                if (E[j] > E[j+1] || (E[j] == E[j+1] && W[j] < W[j+1]))
                {
                    int aux = E[j];
                    E[j] = E[j+1];
                    E[j+1] = aux;

                    aux = W[j];
                    W[j]=W[j+1];
                    W[j+1] = aux;
                }
            }
        }
    }
}