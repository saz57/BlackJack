using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJack
{
    static class UserIO
    {
        public static string GetInput()
        {
            return Console.ReadLine();
        }

        public static void ShowToUser(string text)
        {
            Console.WriteLine(text);
        }

        public static void ClearDisplay()
        {
            Console.Clear();
        }

        public static void MatrixEnable()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Green;
            UserIO.ShowToUser("Wake up, Neo");
        }
    }
}
