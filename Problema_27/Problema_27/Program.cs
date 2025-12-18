using System;
class Program
{
    static void Main()
    {
        Console.WriteLine("Programul determina valoarea de la o pozitie data dupa sortarea vectorului.");
        Console.WriteLine("Elementele vectorului sunt indexate de la pozitia 0.");
        Console.Write("Introduceti numarul de elemente din vector: ");
        int n;
        while(!int.TryParse(Console.ReadLine(), out n) || n <= 0)
        {
            Console.Write("Va rugam introduceti un numar natural valid pentru numarul de elemente: ");
        }

        int[] vector = new int[n];
        Console.WriteLine("Introduceti elementele vectorului (separate prin spatiu):");
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


        Console.Write("Introduceti pozitia dorita: ");
        int index;
        while(!int.TryParse(Console.ReadLine(), out index) || index < 0 || index >= n)
        {
            Console.Write($"Va rugam introduceti o pozitie valida intre 0 si {n-1}: ");
        }
        
        int rezultat=QuickSelect(vector,0,n-1, index);

        Console.WriteLine($"Elementul de pe pozitia {index} dupa sortare este: {rezultat}.");
    }

    static int QuickSelect(int[] vector,int st,int dr, int index)
    {
        if (st == dr)
            return vector[st];
        Random rand = new Random();
        int pivotIndex = Partitie(vector, st, dr, rand.Next(st, dr + 1));
        if (index == pivotIndex)
            return vector[index];
        else if (index < pivotIndex)
            return QuickSelect(vector, st, pivotIndex - 1, index);
        else
            return QuickSelect(vector, pivotIndex + 1, dr, index);
    }

    static int Partitie(int[] vector,int st,int dr, int pivotIndex)
    {
        int pivotValue = vector[pivotIndex];
        Swap(vector, pivotIndex, dr);
        int storeIndex = st;
        for (int i = st; i < dr; i++)
        {
            if (vector[i] < pivotValue)
            {
                Swap(vector, storeIndex, i);
                storeIndex++;
            }
        }
        Swap(vector, storeIndex, dr);
        return storeIndex;
    }
    static void Swap(int[] vector, int i, int j)
    {
        int temp = vector[i];
        vector[i] = vector[j];
        vector[j] = temp;
    }
}