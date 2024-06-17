using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrimaProva
{
    internal class Animale
    {
        string nome;
        string razza;
        int eta; 

        public string Nome { get { return nome; } set { nome = value; } }
        public string Razza{ get { return razza; } set { razza= value; } }
        public int Eta { get { return eta; } set { eta= value; } }

        public void DescriviAnimale()
        {
            Console.WriteLine("Il mio animale si chiama " + nome + ", è un " + razza + " e ha " + eta + " anni ");
        }
    }
}
