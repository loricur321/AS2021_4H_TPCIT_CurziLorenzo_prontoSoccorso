using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace AS2021_4H_TPCIT_CurziLorenzo_prontoSoccorso.Models
{
    class ProntoSoccorso
    {
        List<Paziente> _pazienti = new List<Paziente>();

        public void InserisciPaziente(string nome, string cognome, string colore, string codiceFiscale, DateTime dataNascita)
        {
            _pazienti.Add(new Paziente(nome, cognome, dataNascita, codiceFiscale, colore));
        }

        public Paziente RecuperoPaziente(string codiceFiscale)
        {
            for(int i = 0; i < _pazienti.Count; i++)
            {
                if (_pazienti[i].CodiceFiscale == codiceFiscale)
                    return _pazienti[i];
            }
            
            throw new Exception("Non è stato trovato il paziente.");
            
        }

        public string ListaPazientiColore(string colore)
        {
            List<Paziente> daOrdinare = new List<Paziente>();
            for(int i = 0; i < _pazienti.Count; i++)
            {
                if(_pazienti[i].Colore == colore)
                {
                    daOrdinare.Add(_pazienti[i]);
                }
            }

            //sort
            for(int i = 0; i < daOrdinare.Count - 1; i++)
            {
                for(int j = i + 1; j < daOrdinare.Count; j++)
                {
                    if(daOrdinare[i]._dataAccettazione.CompareTo(daOrdinare[j]._dataAccettazione) > 0)
                    {
                        var tmp = daOrdinare[j];
                        daOrdinare[j] = daOrdinare[i];
                        daOrdinare[i] = tmp;
                    }
                }
            }

            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < daOrdinare.Count; i++)
                sb.AppendLine(daOrdinare[i].ToString());

            return sb.ToString();
        }

        public bool EliminazionePaziente(string codiceFiscale)
        {
            for (int i = 0; i < _pazienti.Count; i++)
                if (_pazienti[i].CodiceFiscale == codiceFiscale)
                {
                    _pazienti[i]._dataDimmissione = DateTime.Now;
                    return true;
                }

            return false;
        }


        public void SalvataggioDati()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"\t\t{DateTime.Today:dd/MM/yyyy:HH:mm}");
            for (int i = 0; i < _pazienti.Count; i++)
                sb.AppendLine(_pazienti[i].ToString());

            File.AppendAllText("Dati.txt", sb.ToString());
        }
    }
}
