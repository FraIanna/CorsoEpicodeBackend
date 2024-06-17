using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrimaProva
{
    internal class Dipendente
    {

        string nome;
        string cognome;
        string azienda;
        int stipendio;
        int ore;

        public string Nome { get { return nome; } set { nome = value; } }
        public string Cognome { get { return cognome; } set { cognome = value; } }
        public string Azienda { get { return azienda; } set { azienda = value; } }
        public int Stipendio{ get { return stipendio; } set { stipendio = value; } }
        public int Ore{ get { return ore; } set { ore = value; } }


        public void Descrivi() {
            Console.WriteLine(
                "Il mio nome è " + Nome + " " + Cognome + 
                ", lavoro in " + azienda + 
                " per " + ore + 
                " al giorno, guadagnando " + stipendio);
        }
    }
}
