using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
// ReSharper disable IdentifierTypo

namespace Siema
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            // Zadanie 1:
            Console.WriteLine("--- Zadanie 1 ---");
            Console.Write("Podaj napis: ");
            int iloscZnakow = IleZnakowWZbiorze(Console.ReadLine(), "AaBbMmKk");
            Console.WriteLine($"Zgodnych znaków jest: {iloscZnakow}");

            // Zadanie 2:
            Console.WriteLine("\n\n--- Zadanie 2 ---");
            Console.Write("Podaj tekst: ");
            double srednia = SredniaWyrazow(Console.ReadLine());
            Console.WriteLine($"Średnia długość wyrazów wynosi: {srednia}");

            // Zadanie 3:
            Console.WriteLine("\n\n--- Zadanie 3 ---");
            Console.Write("Znajdź: ");
            string wyrazy = "pietruszka;majeranek;zimejka;mąka;kredka;marchewka";
            string[] wynik = ZnajdzWyrazyZKoncowka(wyrazy, Console.ReadLine());
            if (wynik.Length == 0)
            {
                Console.WriteLine("Nie znaleziono");
            }
            else
            {
                Console.Write("Wynik: ");
                for (int i = 0; i < wynik.Length; i++)
                {
                    Console.Write(wynik[i] + (i == wynik.Length - 1 ? "" : ", "));
                }
            }

            // Zadanie 4
            Console.WriteLine("\n\n--- Zadanie 4 ---");
            Console.Write("Podaj napis: ");
            string wysrodkowanyNapis = WysrodkujNapis(Console.ReadLine());
            if (wysrodkowanyNapis == null)
            {
                Console.WriteLine("Podany napis jest nieprawidłowy.");
            }

            // Zadanie 5
            Console.WriteLine("\n\n--- Zadanie 5 ---");
            Console.Write("Podaj tekst: ");
            string tekst = WstawSpacje(Console.ReadLine());
            Console.WriteLine($"Poprawiony tekst: {tekst}");
        }

        // Zadanie 1
        public static int IleZnakowWZbiorze(string napis, string zbior)
        {
            int zgodne = 0;
            foreach (char c in napis)
            {
                if (zbior.Contains(c))
                {
                    zgodne++;
                }
            }

            return zgodne;
        }

        // Zadanie 2
        public static double SredniaWyrazow(string tekst)
        {
            string[] wyrazy = tekst.Split(' ');
            return wyrazy.Average(s => s.Length);
        }

        // Zadanie 3
        public static string[] ZnajdzWyrazyZKoncowka(string wyrazy, string koncowka)
        {
            string[] tablicaWyrazow = wyrazy.Split(';');
            List<string> wynik = new List<string>();
            foreach (string wyraz in tablicaWyrazow)
            {
                if (wyraz.EndsWith(koncowka))
                {
                    wynik.Add(wyraz);
                }
            }

            return wynik.ToArray();
        }

        // Zadanie 4
        public static string WysrodkujNapis(string napis)
        {
            if (napis.Contains('\n') || napis.Length > 80)
            {
                return null;
            }
            return (new string(' ', (Console.WindowWidth - napis.Length) / 2) + napis);
        }

        // Zadanie 5
        public static string WstawSpacje(string tekst)
        {
            string result = tekst;
            int offset = 0;
            for (int i = 0; i < tekst.Length; i++)
            {
                if (tekst[i] == '.' || tekst[i] == ',')
                {
                    if ((tekst[i - 1] >= '0' && tekst[i - 1] <= '9') || (tekst[i + 1] >= '0' && tekst[i + 1] <= '9'))
                    {
                        continue;
                    }
                    if (tekst[i + 1] == ' ')
                    {
                        continue;
                    }

                    result = result.Substring(0, i + 1 + offset) + " " + result.Substring(i + 1 + offset);
                    offset++;
                }
            }

            return result;
        }
    }
}
