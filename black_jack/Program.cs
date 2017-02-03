using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJack
{
    class Program
    {
        static void Main(string[] args)
        {
            
            UserIO.ShowToUser("Hello. What is your name?");
            string name = Console.ReadLine();
            Game game = new Game(name);
        }
    }
}
