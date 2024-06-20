using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Giorno_4
{
    internal class Utente
    {
        private static string _username;
        private static string _password;


        public static DateTime LastLoginTime { get; set; }
        public static List <string> Usernames { get; } = new List<string>();


        public static bool isLoggedIn() 
        { return !string.IsNullOrEmpty(_username); }


        public static bool Login(string username, string password, string confirmPassword)
        {
            if (!string.IsNullOrEmpty(username) && password == confirmPassword)
            {
                _username = username;
                _password = password;
                LastLoginTime = DateTime.Now;
                Usernames.Add($"{LastLoginTime}: {_username}");
                if (Usernames.Count > 10)
                {
                    Usernames.RemoveAt(0);
                }
                return true;
            }
            return false;
        }

        public static bool Logout ()
         {
            if (isLoggedIn())
            {
                _username = null;
                _password = null;
                return true;
            }
             return false;
         }


        public static void Login()
        {
            Console.WriteLine("Inserisci username: ");
            string username = Console.ReadLine();

            Console.WriteLine("Inserisci password: ");
            string password = Console.ReadLine();
            Console.WriteLine("Conferma password: ");
            string confirmPassword = Console.ReadLine();

            if (Utente.Login(username, password, confirmPassword))
            {
                Console.WriteLine("Login effettuato con successo!");
            }
            else
            {
                Console.WriteLine("Errore nel login.Verificaidatiinseriti.");
            }
            Console.WriteLine("Premi un tasto per continuare.");
            Console.ReadKey();

        }

        public static void UserLogout()
        {
            if (Utente.Logout())
            {
                Console.WriteLine("Logout effettuato con successo!");
                }
            else
            {
                Console.WriteLine("Nessun utente attualmeloggato.");
            }
            Console.WriteLine("Premi un tasto per continuare.");
            Console.ReadKey();
        }

        public static void VerifyLogin()
        {
            if (Utente.isLoggedIn())
            {
                Console.WriteLine($"Ultimo login effettuato il: {Utente.LastLoginTime}");
            }
            else
            {
                Console.WriteLine("Nessun utente attualmente loggato.");
            }
            Console.WriteLine("Premi un tasto per continuare.");
            Console.ReadKey();
        }

        public static void ListUsersLogin()
        {
            Console.WriteLine("Lista degli ultimi 10 accessi:");
            foreach (var accesso in Utente.Usernames)
            {
                Console.WriteLine(accesso);
            }
            Console.WriteLine("Premi un tasto per continuare.");
            Console.ReadKey();
        }
    }
}
