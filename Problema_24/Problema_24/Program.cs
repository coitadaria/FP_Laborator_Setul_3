using System;
class Program
{
    static void Main()
    {
        Console.WriteLine("Programul determina intersectia, reuniunea si diferentele a doi vectori v1 si v2.");
        Console.WriteLine("Elementele vectorilor sunt 1 (daca elementul face parte din multime) si 0 (daca elementul nu face parte din multime).");
        Console.WriteLine("Vectorii trebuie sa aiba acelas numar de elemente.");
        int dimeniune;
        Console.Write("Introduceti dimensiunea vectorilor: ");
        while (!int.TryParse(Console.ReadLine(), out dimeniune) || dimeniune <= 0)
            Console.Write("Dimensiune invalida. Introduceti din nou: ");

        int[] v1 = new int[dimeniune];
        Console.WriteLine("Introduceti elementele vectorului v1 (0 sau 1, separate prin spatiu):");
        string[] elemente1 = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
        for (int i = 0; i < dimeniune; i++)
        {
            int numar;
            if (!int.TryParse(elemente1[i], out numar) || (numar != 0 && numar != 1))
            {
                Console.WriteLine("Element invalid. Introduceti doar 0 sau 1.");
                return;
            }
            v1[i] = numar;
        }

        int[] v2 = new int[dimeniune];
        Console.WriteLine("Introduceti elementele vectorului v2 (0 sau 1, separate prin spatiu):");
        string[] elemente2 = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
        for (int i = 0; i < dimeniune; i++)
        {
            int numar;
            if (!int.TryParse(elemente2[i], out numar) || (numar != 0 && numar != 1))
            {
                Console.WriteLine("Element invalid. Introduceti doar 0 sau 1.");
                return;
            }
            v2[i] = numar;
        }

        List<int> intersectie = IntersectieBinara(v1, v2);
        List<int> reuniune = ReuniuneaBinara(v1, v2);
        List<int> v1minusv2 = DiferentaBinara(v1, v2);
        List<int> v2minusv1 = DiferentaBinara(v2, v1);

        Console.WriteLine($"Intersectia celor doi vectori este: [{string.Join(", ", intersectie)}]");
        Console.WriteLine($"Reuniunea celor doi vectori este: [{string.Join(", ", reuniune)}]");
        Console.WriteLine($"Diferenta v1 - v2 este: [{string.Join(", ", v1minusv2)}]");
        Console.WriteLine($"Diferenta v2 - v1 este: [{string.Join(", ", v2minusv1)}]");
    }

    private static List<int> DiferentaBinara(int[] v1, int[] v2)
    {
        List<int> diferenta = new List<int>();
        for (int i = 0; i < v1.Length; i++)
        {
            if (v1[i] == 1 && v2[i] == 0)
                diferenta.Add(i);
        }
        return diferenta;
    }

    private static List<int> ReuniuneaBinara(int[] v1, int[] v2)
    {
        List<int> reuniune = new List<int>();
        for (int i = 0; i < v1.Length; i++)
            if (v1[i] == 1 || v2[i] == 1)
                reuniune.Add(i);
        return reuniune;
    }

    private static List<int> IntersectieBinara(int[] v1, int[] v2)
    {
        List<int> intersectie = new List<int>();
        for (int i = 0; i < v1.Length; i++)
            if (v1[i] == 1 && v2[i] == 1)
                intersectie.Add(i);
        return intersectie;
    }
}