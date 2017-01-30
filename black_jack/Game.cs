using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace black_jack
{
    class Game
    {
        const int maxScore = 21;
        private IPlayer dealer;
        private IPlayer human;
        private IDeck deck;

        public Game()
        {
            deck = new Deck();
            dealer = new Player(deck, "Dealer");
            human = new Player(deck);
            Console.WriteLine("Welcome to Black Jack");
        }

        public Game(string _humanName)
        {
            if (_humanName == "my name is Neo")
            {
                deck = new Deck();
                dealer = new Player(deck, "mst Smit");
                human = new Player(deck, "Neo");
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Wake up, Neo");

            }
            else
            {
                deck = new Deck();
                dealer = new Player(deck, "Dealer");
                human = new Player(deck, _humanName);
            }
            Console.WriteLine("Welcome to Black Jack");
            GameCycle();
        }

        private void GameCycle() 
        {
            bool humanTurn = true;

            while (humanTurn) // player turn cycle
            {
                human.ShowHand();

                if (human.Score > maxScore)
                {
                    Console.WriteLine("You loose");
                    OnGameEnd();
                    break;
                }

                else if(human.Score  == maxScore)
                {
                    Console.WriteLine("You win");
                    OnGameEnd();
                    break;
                }

                bool rightChoise = false;

                while (!rightChoise)
                {
                    rightChoise = true;
                    Console.WriteLine("\nWhat do you want to do? \n1 - Ask Card \n2 - Enough");
                    
                    switch (Console.ReadLine())
                    {
                        case "1":
                            human.AskCard();
                            break;
                        case "2":
                            humanTurn = false;
                            break;
                        default:
                            rightChoise = false;
                            break;
                    }
                }
            }

            while (!humanTurn) //AI turn cycle
            {
                Random random = new Random();

                if (maxScore - dealer.Score > 10 || random.NextDouble() < (double)dealer.Score / (double)maxScore)
                    dealer.AskCard();

                else
                {
                    dealer.ShowHand();

                    if (dealer.Score > human.Score)
                    {
                        Console.WriteLine("You loose");
                        OnGameEnd();
                        break;
                    }

                    else if (dealer.Score == human.Score)
                    {
                        Console.WriteLine("There is no winner");
                        OnGameEnd();
                        break;
                    }

                    else
                    {
                        Console.WriteLine("You win");
                        OnGameEnd();
                        break;
                    }
                }

                if (dealer.Score > maxScore)
                {
                    dealer.ShowHand();
                    Console.WriteLine("You win");
                    OnGameEnd();
                    break;
                }

                else if (dealer.Score == maxScore)
                {
                    Console.WriteLine("You win");
                    OnGameEnd();
                    break;
                }
            }
        }

        private void OnGameEnd()
        {
            bool rightChoise = false;

            while (!rightChoise)
            {
                rightChoise = true;
                Console.WriteLine("\nEnter 1 to play again \nEnter 2 to exit");

                switch (Console.ReadLine())
                {
                    case "1": // reset deck and players for new game
                        deck.Reset(); 
                        dealer.Reset();
                        human.Reset();
                        Console.Clear();
                        GameCycle();
                        break;

                    case "2":
                        Environment.Exit(0);
                        break;

                    default:
                        rightChoise = false;
                        Console.WriteLine("Invalid input");
                        break;
                }
            }
        }
    }
}
