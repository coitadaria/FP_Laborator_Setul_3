using System;
class Program
{
    static void Main()
    {
        Console.WriteLine("Programul determina pozitia unui element k dintr-un vector cu n elemente sortat crescator.");
        int n, k;
        Console.Write("Introduceti numarul de elemente (n): ");
        while (!int.TryParse(Console.ReadLine(), out n) || n <= 0)
        {
            Console.Write("Va rugam sa introduceti un numar valid pentru n: ");
        }
        Console.Write("Introduceti elementul de cautat (k): ");
        while (!int.TryParse(Console.ReadLine(), out k))
        {
            Console.Write("Va rugam sa introduceti un numar valid pentru k: ");
        }
        int[] vector = new int[n];
        Console.WriteLine("Introduceti elementele vectorului sortat crescator:");
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


        int pozitie =CautareBinaraPozitie(vector,k,0,n- 1);
        
        if(pozitie != -1)
        {
            Console.WriteLine($"Elementul {k} se afla pe pozitia {pozitie} in vector.");
        }
        else
        {
            Console.WriteLine($"Elementul {k} nu a fost gasit in vector. Pozitia lui este -1.");
        }   
    }

    private static int CautareBinaraPozitie(int[] vector, int k, int stanga, int dreapta)
    {
        while(stanga <= dreapta)
        {
            int mijloc = (stanga + dreapta) / 2;
            if (k < vector[mijloc])
            {
                dreapta = mijloc - 1;
            }
            else
            {
                if (k > vector[mijloc])
                {
                    stanga = mijloc + 1;
                }
                else
                {
                    return mijloc;
                }
            }
        }
        return -1;
    }
}