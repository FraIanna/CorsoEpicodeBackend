using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrimaProva
{
    internal class Veicolo
    {
        string colore;
        string marca;
        int cilindrata;
        int annoImmatricolazione;

        public string Colore { get { return colore; } set { colore = value; } }
        public string Marca {  get { return marca; } set { marca = value; } }
        public int Cilindrata { get { return cilindrata; } set { cilindrata = value; } }
        public int AnnoImmatricolazione { get { return annoImmatricolazione; } set { annoImmatricolazione = value; } }

        public void DescriizoneAuto()
        {
            Console.WriteLine(
                "Valori auto: marca: " + marca + " , anno: " + 
                annoImmatricolazione + " , colore: " + colore 
                + " , cilindrata: " + cilindrata
                );

        }

    }
}
