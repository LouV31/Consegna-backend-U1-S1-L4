using System;
using System.Collections.Generic;

namespace Consegna_backend_U1_S1_L4
{
    internal static class Utente
    {
        public static string username { get; set; }
        public static string password { get; set; }
        public static string confermaPassword { get; set; }
        public static List<DateTime> accessi { get; set; } = new List<DateTime>();

        public static bool isLoggedIn = false;

        public static DateTime ultimoAccesso { get; set; }

        public static void Menu()
        {
            Console.WriteLine("===============OPERAZIONI==============");
            Console.WriteLine("Scegli l'operazione da effettuare:");
            Console.WriteLine("1.: Login");
            Console.WriteLine("2.: Logout");
            Console.WriteLine("3.: Verifica ora e data di login");
            Console.WriteLine("4.: Lista degli accessi");
            Console.WriteLine("5.: Esci");
            Console.WriteLine("========================================");
            string scelta = Console.ReadLine();
            switch (scelta)
            {
                case "1":
                    Login();
                    break;
                case "2":
                    Logout();
                    break;
                case "3":
                    Verifica();
                    break;
                case "4":
                    ListaAccessi();
                    break;
                case "5":
                    Esci();
                    break;
                default:
                    Console.WriteLine("Input non valido.");
                    Menu();
                    break;


            }
        }

        public static void Login()
        {
            if (isLoggedIn == false)
            {


                Console.WriteLine("Inserisci l'email: ");
                username = Console.ReadLine();
                Console.WriteLine("Inserisci la password: ");
                password = Console.ReadLine();
                Console.WriteLine("Conferma password: ");
                confermaPassword = Console.ReadLine();
                if (confermaPassword == password)
                {
                    isLoggedIn = true;
                    Console.WriteLine("Login Effettuato con successo!");
                    ultimoAccesso = DateTime.Now;
                    accessi.Add(ultimoAccesso);

                }
                else
                {
                    Console.WriteLine("Le password non coincidono.");
                }

            }
            else
            {
                Console.WriteLine("Login già effettuato!");
            }
            Menu();
        }

        public static void Logout()
        {
            if (isLoggedIn)
            {
                username = "";
                password = "";
                isLoggedIn = false;
                Console.WriteLine("logout effettuato con successo!");
            }
            else
            {
                Console.WriteLine("Non puoi effettuare il logout se non hai effettuato un login.");
            }
            Menu();

        }

        public static void Verifica()
        {
            if (isLoggedIn)
            {
                Console.WriteLine(ultimoAccesso);
            }
            else
            {
                Console.WriteLine("Non puoi verificare l'accesso se non sei loggato.");
            }
            Menu();
        }

        public static void ListaAccessi()
        {
            foreach (DateTime accesso in accessi)
            {
                Console.WriteLine(accesso);
            }
            Menu();
        }

        public static void Esci()
        {
            Environment.Exit(0);
        }


    }
}
