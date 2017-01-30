using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace black_jack
{
    class Program
    {
        static void Main(string[] args)
        {
            
            Console.WriteLine("Hello. What is your name?");
            string name = Console.ReadLine();
            Game game = new Game(name);
        }
    }
}
