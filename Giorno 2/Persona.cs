using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Giorno_2
{
    internal class Persona
    {
        private string name;
        private string surname;
        private int age;

        public string Name { get { return name; } set { name = value; } }  
        public string Surname { get { return surname; } set { surname = value; } }
        public int Age { get { return age;   } set { age = value; } }

        public void getName(string var) 
        {
            Console.WriteLine("Il mio nome è: " + var);
        }
        public void getSurname(string var) 
        {
            Console.WriteLine("Il mio cognome è: " + var);
        }
        public void getDetails(string var1, string var2, int var3) 
        {
            Console.WriteLine("Il mio nome è: " + var1 + ", invece il mio cognome è: " + var2 + ", ho " + var3 + " anni");
        }

    }
}
