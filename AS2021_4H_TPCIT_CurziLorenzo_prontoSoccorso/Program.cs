using System;
using AS2021_4H_TPCIT_CurziLorenzo_prontoSoccorso.Models;

namespace AS2021_4H_TPCIT_CurziLorenzo_prontoSoccorso
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Programma prontoSoccorso di Lorenzo Curzi 4H, 7/01/2021");

            ProntoSoccorso paziente = new ProntoSoccorso();

            paziente.InserisciPaziente("Mario", "Rossi", "Giallo", "aaabbbbb", Convert.ToDateTime("2/1/2000"));

            try
            {
                Console.WriteLine(paziente.RecuperoPaziente("aaabbbbb"));
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            paziente.SalvataggioDati();

            ProntoSoccorso paziente1 = new ProntoSoccorso();

            paziente1.InserisciPaziente("Franco", "Verdi", "Rosso", "bbbbbaaaaa", Convert.ToDateTime("10/03/1980"));

            try
            {
                Console.WriteLine(paziente1.RecuperoPaziente("bbbbbaaaaa"));
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            paziente1.EliminazionePaziente("bbbbbaaaaa");

            paziente.SalvataggioDati();
        }
    }
}
