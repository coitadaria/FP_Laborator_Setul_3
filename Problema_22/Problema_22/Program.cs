using System;
class Program
{
    static void Main()
    {
        Console.WriteLine("Programul determina intersectia, reuniunea si diferentele a doi vectori v1 si v2.");

        int n;
        Console.Write("Introduceti dimensiunea vectorului v1: ");
        while (!int.TryParse(Console.ReadLine(), out n) || n <= 0)
            Console.Write("Dimensiune invalida. Introduceti din nou: ");

        List<int> v1 = new List<int>();
        Console.WriteLine("Introduceti elementele vectorului v1 (separate prin spatiu):");
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
        Console.WriteLine("Introduceti elementele vectorului v2 (separate prin spatiu):");
        string[] elemente2 = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
        for (int k = 0; k < m; k++)
        {
            v2.Add(int.Parse(elemente2[k]));
        }

        v1 = EliminaDuplicate(v1);
        v2 = EliminaDuplicate(v2);

        List<int> intersectie = Intersectie(v1, v2);
        List<int> reuniune = Reuniune(v1, v2);
        List<int> v1minusv2 = Diferenta(v1, v2);
        List<int> v2minusv1 = Diferenta(v2, v1);

        Console.WriteLine($"Intersectia celor doi vectori este: [{string.Join(", ", intersectie)}]");
        Console.WriteLine($"Reuniunea celor doi vectori este: [{string.Join(", ", reuniune)}]");
        Console.WriteLine($"Diferenta v1 - v2 este: [{string.Join(", ", v1minusv2)}]");
        Console.WriteLine($"Diferenta v2 - v1 este: [{string.Join(", ", v2minusv1)}]");
    }

    static List<int> EliminaDuplicate(List<int> lista)
    {
        List<int> rezultat = new List<int>();
        foreach (int element in lista)
        {
            if (!rezultat.Contains(element))
                rezultat.Add(element);
        }
        return rezultat;
    }

    static List<int> Intersectie(List<int> v1, List<int> v2)
    {
        List<int> intersectie = new List<int>();
        foreach (int element in v1)
        {
            if (v2.Contains(element) && !intersectie.Contains(element))
                intersectie.Add(element);
        }
        intersectie.Sort();
        return intersectie;
    }

    static List<int> Reuniune(List<int> v1, List<int> v2)
    {
        List<int> reuniune = new List<int>();
        foreach (int element in v1)
        {
            if (!reuniune.Contains(element))
                reuniune.Add(element);
        }
        foreach (int element in v2)
        {
            if (!reuniune.Contains(element))
                reuniune.Add(element);
        }
        reuniune.Sort();
        return reuniune;
    }

    static List<int> Diferenta(List<int> v1, List<int> v2)
    {
        List<int> diferenta = new List<int>();
        foreach (int element in v1)
        {
            if (!v2.Contains(element) && !diferenta.Contains(element))
                diferenta.Add(element);
        }
        diferenta.Sort();
        return diferenta;
    }
}