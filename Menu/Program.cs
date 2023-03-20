using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Menu
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

                Console.WriteLine(CenterText("MENÚ DE CONSOLA"));
                Console.WriteLine();

                ShowMenu(options, selectedOption);

                Console.WriteLine(CenterText("Use las flechas ↑↓"));
                Console.WriteLine(CenterText("Presione Enter para seleccionar"));
                Console.WriteLine();

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
                        Console.Clear();
                        Console.WriteLine(CenterText("MENÚ DE CONSOLA"));
                        Console.WriteLine();
                        Console.WriteLine(CenterText("Ha seleccionado la " + options[selectedOption] + "."));
                        Console.WriteLine();
                        Console.WriteLine(CenterText("Presione Enter para continuar"));
                        Console.ReadKey();
                        break;
                }
            }
        }

        static string CenterText(string text)
        {
            int screenWidth = Console.WindowWidth;
            int stringWidth = text.Length;
            int spaces = (screenWidth / 2) + (stringWidth / 2);
            return text.PadLeft(spaces);
        }

        static void ShowMenu(string[] options, int selectedOption)
        {
            for (int i = 0; i < options.Length; i++)
            {
                if (selectedOption == i)
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine(CenterText("> " + options[i]));
                }
                else
                {
                    Console.ResetColor();
                    Console.WriteLine(CenterText(options[i]));
                }
            }

            Console.ResetColor();
        }
    }
}
