using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

using BotigaCistellaApp;


namespace BotigaCistella
{
    internal class MainProgram
    {

        private static Botiga botiga = new Botiga("Mercadona", 0);
        
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            IniciarSessio();
        }

        private static void IniciarSessio()
        {
            string nomIntroduit, nomUsuari;
            string passwordIntroduit, password;
            string nivell = "";
            bool iniciCorrecte = false;


            while (!iniciCorrecte)
            {
                Console.Clear();
                Console.WriteLine("INICI DE SESSIÓ\n");
                Console.Write("Nom d'usuari: "); nomIntroduit = Console.ReadLine();
                Console.Write("Contrasenya: "); passwordIntroduit = Console.ReadLine();

                using (StreamReader arxiuUsuaris = new StreamReader($"../../dades/usuaris.txt"))
                {
                    while (!arxiuUsuaris.EndOfStream)
                    {
                        string linia = arxiuUsuaris.ReadLine();
                        nomUsuari = linia.Split(',')[0];
                        password = linia.Split(',')[1];
                        nivell = linia.Split(',')[2];

                        if (nomIntroduit == nomUsuari && passwordIntroduit == password)
                        {
                            iniciCorrecte = true;
                            break;
                        }
                    }
                }
                if (iniciCorrecte && nivell == "admin") ObrirBotiga();
                else if (iniciCorrecte && nivell == "user") ObrirCistella();
            }
        }

        public static void ObrirBotiga()
        {
            string titol = "BOTIGA";
            string[] opcions = {
                "Afegir producte",
                "Eliminar producte",
                "Modificar producte",
                "Mostrar productes",
                "Sortir"
            };

            Menu menu = new Menu(titol, opcions, ConsoleColor.White, ConsoleColor.Yellow);
            menu.MostrarMenu();
            ControlarInput(menu);
        }

        public static void ObrirCistella()
        {
            string titol = "CISTELLA";
            string[] opcions = {
                "Comprar producte",
                "Ordenar cistella",
                "Mostrar cistella",
                "Sortir"
            };

            Menu menu = new Menu(titol, opcions, ConsoleColor.White, ConsoleColor.Yellow);
            menu.MostrarMenu();
            ControlarInput(menu);
        }

        public static void ControlarInput(Menu menu)
        {
            if (menu.Titol == "BOTIGA")
            {
                switch (menu.OpcioSeleccionada)
                {
                    case 0:
                        string nomProducte;
                        double preuProducte;
                        double iva;
                        int quantitat;

                        Console.Clear();

                        Console.Write("Nom: "); nomProducte = Console.ReadLine();
                        Console.Write("Preu: "); preuProducte = Convert.ToDouble(Console.ReadLine());
                        Console.Write("IVA: "); iva = Convert.ToDouble(Console.ReadLine());
                        Console.Write("Quantitat: "); quantitat = Convert.ToInt32(Console.ReadLine());

                        Producte producte = new Producte(nomProducte, preuProducte, iva, quantitat);
                        botiga.AfegirProducte(producte);

                        menu.Esperar();
                        ObrirBotiga();

                        break;

                    case 1:
                        Console.WriteLine("Eliminar productes");
                        break;

                    case 2:
                        Console.WriteLine("Modificar productes");
                        break;
                    case 3:
                        Console.Clear();
                        botiga.Mostrar();
                        menu.Esperar();
                        ObrirBotiga();
                        break;
                    case 4:
                        TancarSessio();
                        break;

                }
            }
            else
            {
                switch (menu.OpcioSeleccionada)
                {
                    case 0: Console.WriteLine("Comprar productes"); break;
                    case 1: Console.WriteLine("Ordenar cistella"); break;
                    case 2: Console.WriteLine("Mostrar cistella"); break;
                    case 3:
                        TancarSessio();
                        break;
                }
            }
        }

        private static void TancarSessio()
        {
            Console.Write("[0] Sortir | [1] Tancar sessió: ");
            int res = Convert.ToInt32(Console.ReadLine());
            if (res == 0) Console.WriteLine("Adéu!");
            else IniciarSessio();
        }
    }
}
