using System;
class Program
{
    static void Main()
    {
        Console.WriteLine("Programul determina numarul de suprapuneri a unui sirag de margele (s1) peste celalalt (s2).");
        Console.WriteLine("Margelele sunt albe sau negre. Introduceti 1 pentru margele negre si 0 pentru margele albe.");
        //citire date
        Console.WriteLine("Intoduceti numarul de margele din siragul s1:");
        int n,m;
        while(!int.TryParse(Console.ReadLine(), out n) || n <= 0)
        {
            Console.WriteLine("Va rugam sa introduceti un numar intreg pozitiv pentru numarul de margele:");
        }
        int[] s1=new int[n];
        Console.WriteLine("Introduceti margelele din siragul s1 (separate prin spatiu):");
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
                if (!int.TryParse(input[i], out s1[i]) || (s1[i]!=0 && s1[i]!=1))
                {
                    Console.WriteLine("Input invalid. Va rugam introduceti numere intregi.Reintroduceti vectorul:");
                    valid = false;
                    break;
                }
            }
            if (valid) break;
        }

        Console.WriteLine("Intoduceti numarul de margele din siragul s2:");
        while(!int.TryParse(Console.ReadLine(), out m) || m <= 0)
        {
            Console.WriteLine("Va rugam sa introduceti un numar intreg pozitiv pentru numarul de margele:");
        }
        int[] s2 = new int[m];
        Console.WriteLine("Introduceti margelele din siragul s2 (separate prin spatiu):");
        
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
                if (!int.TryParse(input[i], out s2[i]) || (s2[i] != 0 && s2[i] != 1)) 
                {
                    Console.WriteLine("Input invalid. Va rugam introduceti numere intregi.Reintroduceti vectorul:");
                    valid = false;
                    break;
                }
            }
            if (valid) break;
        }

        //prelucrare date
        // fixam s2 si rotim s1
        int maxPotriviri = 0;
        for(int rotire=0;rotire<n;rotire++)
        {
            int potrivire = 0;
            for(int i = 0; i < Math.Min(n, m); i++)
            {
                if (s1[(i + rotire) % n] == s2[i])
                {
                    potrivire++;
                }
            }
            if (potrivire > maxPotriviri)
            {
                maxPotriviri = potrivire;
            }
        }
        //fixam s1 si rotim s2
        for (int rotire = 0; rotire < m; rotire++)
        {
            int potrivire = 0;
            for (int i = 0; i < Math.Min(n, m); i++)
            {
                if (s1[i] == s2[(rotire+i)%m])
                {
                    potrivire++;
                }
            }
            if (potrivire > maxPotriviri)
            {
                maxPotriviri = potrivire;
            }
        }
        Console.WriteLine($"Numarul maxim de suprapuneri este: {maxPotriviri}.");
    }
}   