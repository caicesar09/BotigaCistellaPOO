using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BotigaCistellaApp
{
    class Menu
    {
        // Atributs
        private string titol;
        private string[] opcions;
        private ConsoleColor colorPrimari;
        private ConsoleColor colorSecundari;
        private int opcioSeleccionada;
        private static int opcioActiva = 0;

        // Propietats
        public string Titol { get { return titol;  } set { titol = value;  } }
        public int OpcioSeleccionada { get { return opcioSeleccionada; } set { opcioSeleccionada = value; } }

        // Constructors
        public Menu(string titol, string[] opcions) 
        {
            this.titol = titol;
            this.opcions = opcions;
            colorPrimari = ConsoleColor.White;
            colorSecundari = ConsoleColor.Yellow;
        }
        public Menu(string titol, string[] opcions, ConsoleColor colorPrimari, ConsoleColor colorSecundari) : this(titol, opcions)
        {
            this.colorPrimari = colorPrimari;
            this.colorSecundari = colorSecundari;
        }

        // Mètodes
        public void MostrarMenu()
        {
            bool menuObert = true;
            while (menuObert)
            {
                Console.Clear();
                Console.ForegroundColor = colorPrimari;
                CentrarText("╔════════════════════════════════════════════╗");
                CentrarText(titol);
                CentrarText("╚════════════════════════════════════════════╝");
                Console.ForegroundColor = colorSecundari;

                CentrarText("╔════════════════════════════════════════════╗");

                for (int i = 0; i < opcions.Length; i++)
                {
                    if (opcioActiva == i) CentrarText("->  " + opcions[i]);
                    else CentrarText( "    " + opcions[i]);
                }

                CentrarText("╚════════════════════════════════════════════╝");

                Console.ResetColor();

                CentrarText(" ╔══════════════════════════════════════════════╗");
                CentrarText("Utilitza les fletxes ↑↓");
                CentrarText("Prem [Enter] per seleccionar una opció.");
                CentrarText(" ╚══════════════════════════════════════════════╝");

                ConsoleKeyInfo keyInfo = Console.ReadKey();

                switch (keyInfo.Key)
                {
                    case ConsoleKey.UpArrow:
                        opcioActiva = opcioActiva == 0 ? opcions.Length - 1 : opcioActiva - 1;
                        break;

                    case ConsoleKey.DownArrow:
                        opcioActiva = opcioActiva == opcions.Length - 1 ? 0 : opcioActiva + 1;
                        break;

                    case ConsoleKey.Enter:
                        menuObert = false;
                        opcioSeleccionada = opcioActiva;
                        opcioActiva = 0;
                        break;
                }
            }
        }
        public void CentrarText(string txt, bool novaLinia = true)
        {
            Console.SetCursorPosition((Console.WindowWidth - txt.Length) / 2, Console.CursorTop);
            if (novaLinia) Console.WriteLine(txt);
            else Console.Write(txt);
        }

        public void Esperar(int milisegons = 2000)
        {
            for (int i = milisegons / 1000; i != 0; i--)
            {
                Console.Write($"\rTornant al menú en: [{i}]");
                Thread.Sleep(1000);
            }
        }
    }
}
