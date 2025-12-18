using System;
class Program
{
    static void Main()
    {
        Console.WriteLine("Programul construieste un al treilea vector format din toate elementele vectorilor v1 si v2 ordonati crescatori.");
        int n, m;
        Console.Write("Introduceti numarul de elemente pentru vectorul v1: ");
        while(!int.TryParse(Console.ReadLine(),out n) || n <= 0)
        {
            Console.Write("Input invalid. Va rugam introduceti un numar intreg pozitiv pentru n: ");
        }
        List<int> v1 = new List<int>();
        Console.WriteLine("Introduceti elementele vectorului v1 (separate prin spatiu):");
        string[] elemente1 = Console.ReadLine().Split(' ',StringSplitOptions.RemoveEmptyEntries);
        for (int i = 0; i < n; i++)
        {
            v1.Add(int.Parse(elemente1[i]));
        }
        Console.Write("Introduceti numarul de elemente pentru vectorul v2: ");
        while (!int.TryParse(Console.ReadLine(), out m) || m <= 0)
        {
            Console.Write("Input invalid. Va rugam introduceti un numar intreg pozitiv pentru m: ");
        }
        List<int> v2 = new List<int>();
        Console.WriteLine("Introduceti elementele vectorului v2 (separate prin spatiu):");
        string[] elemente2 = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
        for (int i = 0; i < m; i++)
        {
            v2.Add(int.Parse(elemente2[i]));
        }
        List<int> v3 = Interclasare(v1,v2);

        Console.WriteLine($"Vectorul interclasat este: [{string.Join(", ",v3)}].");
    }
    static List<int> Interclasare(List<int> v1, List<int> v2)
    {
        List<int> v3 = new List<int>();
        int i = 0, j = 0;
        while (i < v1.Count && j < v2.Count)
        {
            if (v1[i] <= v2[j])
            {
                v3.Add(v1[i]);
                i++;
            }
            else
            {
                v3.Add(v2[j]);
                j++;
            }
        }
        while (i < v1.Count)
        {
            v3.Add(v1[i]);
            i++;
        }
        while (j < v2.Count)
        {
            v3.Add(v2[j]);
            j++;
        }
        return v3;
    }
}