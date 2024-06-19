namespace Giorno_3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Test classe ContoCorrente

            ContoCorrente conto = new ContoCorrente("Mario Rossi", "IT23470924098");
            
            conto.ApriConto(500);
            // importo inferiore a 1000

            Console.WriteLine("--------------------");

            conto.ApriConto(1200);
            //importo superiore a 1000

            Console.WriteLine("--------------------");

            conto.Versamento(1200);
            // versamento valido

            Console.WriteLine("--------------------");

            conto.Prelievo(2000);
            // prelievo non valido

            Console.WriteLine("--------------------");

            conto.Prelievo(1000);
            // prelievo valido

            Console.WriteLine("--------------------");

            Console.WriteLine($"Il saldo del conto è: {conto.Saldo}$");

            Console.WriteLine("---------Fine--------");

            //--------------++++++++++++++--------------//

            // Eserizio 2
            string[] nomi = { "Antonio", "Michele", "Ilaria", "Giulia", };
            Console.WriteLine("Inserisci il nome da cercare: ");
            string nomeDaCercare = Console.ReadLine();

            bool found = false;
            foreach (string nome in nomi) { 
            
                if (nome.Equals(nomeDaCercare, StringComparison.OrdinalIgnoreCase))
                { 
                    found = true; 
                    break;
                }

            }
            if (found) {

                Console.WriteLine("È presente nell'array");
                
            } 
            else
            {
                Console.WriteLine("Non è presente nell'array");
            }

            // Esercizio 3

            Console.WriteLine("Inserisci la dimensione dell'array:");
            
            int dimensione = int.Parse(Console.ReadLine());

            int[] numeri = new int[dimensione];

            for (int i = 0; i < dimensione; i++)
            {
                Console.WriteLine("Inserisci un numero intero:");
                numeri[i] = int.Parse(Console.ReadLine());
            }

            int somma = 0;
            foreach (int numero in numeri)

            {
                somma += numero;
            }

            double media = (double)somma / dimensione;

            Console.WriteLine("La somma di tutti i numeri è: " + somma);
            Console.WriteLine("La media aritmetica di tutti i numeri è: " + media);
        }
        
    }
    
}
