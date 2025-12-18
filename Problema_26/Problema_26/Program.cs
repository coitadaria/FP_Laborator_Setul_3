using System;
class Program
{
    static void Main()
    {
        Console.WriteLine("Programul determina suma, diferenta si produsul a doua numere naturale foarte mari.");
        Console.WriteLine("Cifrele numerelor vor fi stocate in vectori, cate o cifra pe fiecare pozitie a vectorului.");
        Console.Write("Introduceti primul numar natural foarte mare: ");
        List<int> numar1 = CitireNumar();
        Console.Write("Introduceti al doilea numar natural foarte mare: ");
        List<int> numar2 = CitireNumar();
        List<int> suma = Adunare(numar1, numar2);
        List<int> diferenta = Scadere(numar1, numar2);
        bool numar1MaiMare = EsteMaiMare(numar1, numar2);
        List<int> produs = Inmultire(numar1, numar2);

        Console.WriteLine($"Suma este: {string.Join("", suma)}.");
        Console.Write($"Diferenta este: ");
        if (!numar1MaiMare) Console.Write("-");
        Console.WriteLine($"{string.Join("", diferenta)}.");
        Console.WriteLine($"Produsul este: {string.Join("", produs)}.");
    }

    static List<int> CitireNumar()
    {
        string input = Console.ReadLine();
        List<int> numar = new List<int>();
        foreach (char cifra in input)
        {
            if (cifra >= '0' && cifra <= '9')
                numar.Add(cifra - '0');
            else
            {
                Console.WriteLine("Input invalid. Va rugam introduceti doar cifre.");
                return CitireNumar();
            }
        }
        if (numar.Count == 0)
        {
            numar.Add(0);
        }
        return numar;
    }

    static List<int> Adunare(List<int> numar1, List<int> numar2)
    {
        List<int> rezultat = new List<int>();
        int carry = 0;
        int i = numar1.Count - 1;
        int j = numar2.Count - 1;

        while (i >= 0 || j >= 0 || carry > 0)
        {
            int suma = carry;
            if (i >= 0)
            {
                suma += numar1[i];
                i--;
            }
            if (j >= 0)
            {
                suma += numar2[j];
                j--;
            }
            rezultat.Insert(0, suma % 10);
            carry = suma / 10;
        }
        return rezultat;
    }


    static List<int> Scadere(List<int> numar1, List<int> numar2)
    {
        int i;
        bool numar1MaiMare = true;
        
        while (numar1.Count > 1 && numar1[0] == 0) numar1.RemoveAt(0);
        while (numar2.Count > 1 && numar2[0] == 0) numar2.RemoveAt(0);

        if (numar1.Count < numar2.Count)
            numar1MaiMare = false;
        else if (numar1.Count == numar2.Count)
        {
            for (i = 0; i < numar1.Count; i++)
            {
                if (numar1[i] < numar2[i])
                {
                    numar1MaiMare = false;
                    break;
                }
                else if (numar1[i] > numar2[i])
                    break;
            }
        }

        List<int> mare, mic;
        if (numar1MaiMare)
        {
            mare = numar1;
            mic = numar2;
        }
        else
        {
            mare = numar2;
            mic = numar1;
            Console.WriteLine("Primul numar este mai mic, rezultatul va fi negativ!");
        }

        List<int> rezultat = new List<int>();
        int borrow = 0;
        i = mare.Count - 1;
        int j = mic.Count - 1;

        while (i >= 0)
        {
            int diferenta = mare[i] - borrow;
            i--;

            if (j >= 0)
            {
                diferenta -= mic[j];
                j--;
            }

            if (diferenta < 0)
            {
                diferenta += 10;
                borrow = 1;
            }
            else
            {
                borrow = 0;
            }
            rezultat.Insert(0, diferenta);
        }

        // Elimină zerouri de la început
        while (rezultat.Count > 1 && rezultat[0] == 0)
            rezultat.RemoveAt(0);

        return rezultat;
    }

    static bool EsteMaiMare(List<int> a, List<int> b)
    {
        List<int> copieA = new List<int>(a);
        List<int> copieB = new List<int>(b);

        while (copieA.Count > 1 && copieA[0] == 0) copieA.RemoveAt(0);
        while (copieB.Count > 1 && copieB[0] == 0) copieB.RemoveAt(0);

        if (copieA.Count > copieB.Count) return true;
        if (copieA.Count < copieB.Count) return false;

        for (int i = 0; i < copieA.Count; i++)
        {
            if (copieA[i] > copieB[i]) return true;
            if (copieA[i] < copieB[i]) return false;
        }

        return true; 
    }
    static List<int> Inmultire(List<int> numar1, List<int> numar2)
    {
        if(numar1.Count == 1 && numar1[0] == 0 || numar2.Count == 1 && numar2[0] == 0)
            return new List<int> { 0 };
        List<int> rezultat = new List<int> { 0 };

        for(int j = numar2.Count - 1; j >= 0; j--)
        {
            List<int> linie = new List<int>();
            int carry = 0;

            for (int k = 0; k < numar2.Count - 1 - j; k++)
            {
                linie.Add(0);
            }

            for (int i = numar1.Count - 1; i >= 0; i--)
            {
                int produs = numar1[i] * numar2[j] + carry;
                linie.Insert(0, produs % 10);
                carry = produs / 10;
            }
            if (carry > 0)
            {
                linie.Insert(0, carry);
            }
            rezultat = Adunare(rezultat, linie);
        }
        return rezultat;
    }

}
