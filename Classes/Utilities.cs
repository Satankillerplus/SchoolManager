using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZooManager.Classes
{
    internal static class Utilities
    {
        public static void ShowHeader(string appName)
        {
            Console.BackgroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.Black;

            for (int i = 0; i < (Console.WindowWidth - appName.Length) / 2; i++)
            {
                Console.Write(" ");
            }
            Console.Write(appName);
            for (int i = Console.GetCursorPosition().Left; i < Console.WindowWidth; i++)
            {
                Console.Write(" ");
            }

            Console.ResetColor();
            Console.WriteLine("\n\n");
        }

        public static void ShowFooter(string footer)
        {
            Console.BackgroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.Black;

            Console.SetCursorPosition(0, Console.WindowHeight - 1);
            Console.Write(footer);
            for (int i = Console.GetCursorPosition().Left; i < Console.WindowWidth-1; i++)
            {
                Console.Write(" ");
            }

            Console.ResetColor();
        }
    }
}
