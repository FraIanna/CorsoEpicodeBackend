using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Giorno_3
{
    internal class ContoCorrente
    {
        public string NomeIntestatario { get; private set; }
        public string NumeroConto { get; private set; }
        public decimal Saldo { get; private set; }
        private bool ContoAperto { get; set; }

        public ContoCorrente (string nomeIntestatario, string numeroConto)
        {
            NomeIntestatario = nomeIntestatario;
            NumeroConto = numeroConto;
            Saldo = 0;
            ContoAperto = false;
        }

        public void ApriConto (decimal primoVersamento)
        {
            if (ContoAperto) {
                Console.WriteLine("Il conto è già stato aperto.");
                return;
            }
            if(primoVersamento < 1000)
            {
                Console.WriteLine("Attenzione! Il primo versamento deve essere almeno di 1000$");
                return;
            }

            Saldo = primoVersamento;
            ContoAperto = true;
            Console.WriteLine($"Conto aperto correttamente, con un versamento di {primoVersamento}$");
        } 
        
        public void Versamento(decimal importo)
        {
            if (!ContoAperto)
            {
                Console.WriteLine("Il conto non è ancora stato aperto");
                return;
            } 
            Saldo += importo;
            Console.WriteLine($"Versamento di {importo}$ effettuato con successo");

        }

        public void Prelievo (decimal importo)
        {
            if (!ContoAperto)
            {
                Console.WriteLine("Il conto non è ancora stato aperto");
                return;
            }

            if (importo > Saldo) {

                Console.WriteLine($"Saldo insufficiente per prelevare {importo}$ ");
                return;
            }

            Saldo -= importo;
            Console.WriteLine($"Versamento di {importo}$ effettuato con successo");

        }
    }
}
