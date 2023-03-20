using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pruebas
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int selectedOption = 0;
            bool menuOpen = true;

            string[] options = { "Opción 1", "Opción 2", "Opción 3" };

            while (menuOpen)
            {
                Console.Clear();
                Console.WriteLine("Seleccione una opción:");
                Console.ForegroundColor = ConsoleColor.Yellow;

                for (int i = 0; i < options.Length; i++)
                {
                    if (selectedOption == i) Console.WriteLine("-> " + options[i]);
                    else Console.WriteLine("   " + options[i]);
                }

                Console.WriteLine("\nPresione Enter para seleccionar la opción.");

                Console.ResetColor();

                ConsoleKeyInfo keyInfo = Console.ReadKey();

                switch (keyInfo.Key)
                {
                    case ConsoleKey.UpArrow:
                        selectedOption = selectedOption == 0 ? options.Length - 1 : selectedOption - 1;
                        break;

                    case ConsoleKey.DownArrow:
                        selectedOption = selectedOption == options.Length - 1 ? 0 : selectedOption + 1;
                        break;

                    case ConsoleKey.Enter:
                        Console.WriteLine("\nHa seleccionado la " + options[selectedOption] + ".");
                        Console.WriteLine("\nPresione Enter para continuar.");
                        Console.ReadLine();

                        menuOpen = false;
                        break;
                }
            }
        }
    }
}
