using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlackJack.Enums;

namespace BlackJack
{
    static internal class UserIO 
    {

        public static string GetPlayerName()
        {
            Console.WriteLine("Hello. What is your name?");
            string name = Console.ReadLine(); ;
            
            if(name == "")
            {
                name = "Player";
            }

            Console.WriteLine("Welcome to Black Jack");
            return name;
        }

        public static int OnGameInput(GameStatus gameStatus)
        {
            while(true)
            {
                string input;
                
                if (gameStatus == GameStatus.InGame)
                {
                    Console.WriteLine("\nWhat do you want to do? \n1 - Ask Card \n2 - Enough");
                }

                if (gameStatus == GameStatus.GameEnd)
                {
                    Console.WriteLine("\nWhat do you want now? \nEnter 1 to play again\nEnter 2 to exit");
                }

                input = Console.ReadLine();

                if(input == "1" || input =="2")
                {
                   Console.Clear();
                   return Convert.ToInt32(input);
                }
                Console.Clear();
                Console.WriteLine("Invalid input. Please try again");
            } 
        }

        public static void ShowWinner(Player winner)
        {
            if (winner == null)
            {
                Console.WriteLine("\nNo one is win");
            }

            if (winner != null)
            {
                Console.WriteLine("\n" + winner.Name + " is winner");
            }

        }

        public static void MatrixEnable()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Wake up, Neo");
        }

        public static void ShowHand(Player player, IEnumerable<Card> hand)
        {
            Console.WriteLine("\n" + player.Name + " have in hand:");

            foreach(Card card in hand)
            {
                Console.WriteLine(card.Name.ToString() + " " + card.Suit.ToString());
            }

            Console.WriteLine("\nTotal score is: " + player.Score.ToString());
        }
    }
}
