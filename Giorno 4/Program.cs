namespace Giorno_4
{
    internal class Program
    {
        static void Main(string[] args)
        {

            bool exit = false;

            while (!exit)
            {
                Console.Clear();
                Console.WriteLine("===============OPERAZIONI==============");
                Console.WriteLine("Scegli l'operazione da effettuare:");
                Console.WriteLine("1.: Login");
                Console.WriteLine("2.: Logout");
                Console.WriteLine("3.: Verifica ora e data di login");
                Console.WriteLine("4.: Lista degli accessi");
                Console.WriteLine("5.: Esci");
                Console.WriteLine("========================================");

                char choice = Choice();

                switch (choice)
                {
                    case '1':
                        Utente.Login();
                        break;
                    case '2':
                        Utente.Logout();
                        break;
                    case '3':
                        Utente.VerifyLogin();
                        break;
                    case '4':
                        Utente.ListUsersLogin();
                        break;
                    case '5':
                        exit = true;
                        break;
                    default:
                        Console.WriteLine("Operazione non valida. Premi un tasto per continuare.");
                        Console.ReadKey();
                        break;
                }
            }
            
            static char Choice()
            {
                char answer;
                do 
                {
                    string input = Console.ReadLine();
                    if (!string.IsNullOrEmpty(input) && input.Length == 1)
                    {
                        answer = input[0];
                    }
                    else
                    {
                        answer = '0';
                    }
                } 
                while (answer < '1' || answer > '5');
                return answer;
            }

            Utente.Login();
            Utente.UserLogout();
            Utente.VerifyLogin();
            Utente.ListUsersLogin();

        }
    }
}
