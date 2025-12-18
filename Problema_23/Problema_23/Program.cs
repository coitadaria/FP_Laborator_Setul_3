using System;
class Program
{
    static void Main()
    {
        Console.WriteLine("Programul determina intersectia, reuniunea si diferentele a doi vectori sortati v1 si v2.");
        
        int n;
        Console.Write("Introduceti dimensiunea vectorului v1: ");
        while (!int.TryParse(Console.ReadLine(), out n) || n <= 0)
            Console.Write("Dimensiune invalida. Introduceti din nou: ");

        List<int> v1 = new List<int>();
        Console.WriteLine("Introduceti elementele vectorului v1 (sortate crescator, separate prin spatiu):");
        string[] elemente1 = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
        for (int k = 0; k < n; k++)
        {
            v1.Add(int.Parse(elemente1[k]));
        }

        int m;
        Console.Write("Introduceti dimensiunea vectorului v2: ");
        while (!int.TryParse(Console.ReadLine(), out m) || m <= 0)
            Console.Write("Dimensiune invalida. Introduceti din nou: ");

        List<int> v2 = new List<int>();
        Console.WriteLine("Introduceti elementele vectorului v2 (sortate crescator, separate prin spatiu):");
        string[] elemente2 = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
        for (int k = 0; k < m; k++)
        {
            v2.Add(int.Parse(elemente2[k]));
        }

        List<int> intersectie = Intersectie(v1, v2);
        List<int> reuniune = Reuniune(v1, v2);
        List<int> v1minusv2 = Diferenta(v1, v2);
        List<int> v2minusv1 = Diferenta(v2, v1);

        Console.WriteLine($"Intersectia celor doi vectori este: [{string.Join(", ", intersectie)}]");
        Console.WriteLine($"Reuniunea celor doi vectori este: [{string.Join(", ", reuniune)}]");
        Console.WriteLine($"Diferenta v1 - v2 este: [{string.Join(", ", v1minusv2)}]");
        Console.WriteLine($"Diferenta v2 - v1 este: [{string.Join(", ", v2minusv1)}]");
    }

    static List<int> Intersectie(List<int> v1, List<int> v2)
    {
        List<int> intersectie = new List<int>();
        int i = 0, j = 0;

        while (i < v1.Count && j < v2.Count)
        {
            if (v1[i] < v2[j])
                i++;
            else if (v1[i] > v2[j])
                j++;
            else
            {
                intersectie.Add(v1[i]);
                i++;
                j++;
            }
        }
        return intersectie;
    }

    static List<int> Reuniune(List<int> v1, List<int> v2)
    {
        List<int> reuniune = new List<int>();
        int i = 0, j = 0;

        while (i < v1.Count && j < v2.Count)
        {
            if (v1[i] < v2[j])
            {
                reuniune.Add(v1[i]);
                i++;
            }
            else if (v1[i] > v2[j])
            {
                reuniune.Add(v2[j]);
                j++;
            }
            else
            {
                reuniune.Add(v1[i]);
                i++;
                j++;
            }
        }

        while (i < v1.Count)
        {
            reuniune.Add(v1[i]);
            i++;
        }
        while (j < v2.Count)
        {
            reuniune.Add(v2[j]);
            j++;
        }
        return reuniune;
    }

    static List<int> Diferenta(List<int> v1, List<int> v2)
    {
        List<int> diferenta = new List<int>();
        int i = 0, j = 0;

        while (i < v1.Count && j < v2.Count)
        {
            if (v1[i] < v2[j])
            {
                diferenta.Add(v1[i]);
                i++;
            }
            else if (v1[i] > v2[j])
            {
                j++;
            }
            else
            {
                i++;
                j++;
            }
        }

        while (i < v1.Count)
        {
            diferenta.Add(v1[i]);
            i++;
        }
        return diferenta;
    }
}