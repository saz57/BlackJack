using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace BlackJack
{
    class Game
    {
        private const int _maxScore = 21;
        private Player _dealer;
        private Player _human;
        private Deck _deck;

        public Game()
        {
            UserIO.ShowToUser("Hello. What is your name?");
            string humanName = UserIO.GetInput();
            _deck = new Deck();

            if (humanName == "my name is Neo")
            { 
                _dealer = new Player(_deck, "mst Smit");
                _human = new Player(_deck, "Neo");
                UserIO.MatrixEnable();
            }

            if (humanName != "my name is Neo")
            {
                _dealer = new Player(_deck, "Dealer");
                _human = new Player(_deck, humanName);
            }

            UserIO.ShowToUser("Welcome to Black Jack");
            GameCycle();
        }


        private void GameCycle() 
        {
            bool humanTurn = true;
            string input;
            Random random = new Random();
            while (true)
            {
                if(humanTurn)
                {
                    _human.ShowHand();
                    if (CheckForWinner(_human))
                    {
                        return;
                    }

                    while (true)
                    {
                        UserIO.ShowToUser("\nWhat do you want to do? \n1 - Ask Card \n2 - Enough");
                        input = UserIO.GetInput();
                        
                        if (input == "1")
                        {
                            _human.AskCard();
                            break;
                        }

                        if (input == "2")
                        {
                            humanTurn = false;
                            break;
                        }
                        UserIO.ShowToUser("\nInvalid input. Please try again");
                        _human.ShowHand();
                    }
                }

                if (!humanTurn)
                {
                    double rand = random.NextDouble();
                    if (_maxScore - _dealer.Score >= 11 || rand <= ((double)_dealer.Score - 11) / ((double)_maxScore -11))
                    {
                        _dealer.AskCard();
                        if (CheckForWinner(_dealer))
                        {
                            return;
                        }
                    }

                    if (_maxScore - _dealer.Score < 11 && rand > ((double)_dealer.Score - 11) / ((double)_maxScore - 11))
                    {
                        FinalWinnerCheck(_dealer, _human);
                    }
                }
            }
        }

        private bool CheckForWinner(Player player)
        {
            bool findWinner = false;

            if (player.Score > _maxScore)
            {
                findWinner = true;
                player.IsWinner = false;
            }

            if (player.Score == _maxScore)
            {
                findWinner = true;
                player.IsWinner = true;
            }

            if(findWinner)
            {
                HaveWinner();
            }
            

            return findWinner;
        }

        private void FinalWinnerCheck(Player player1,Player player2)
        {
            if (player1.Score > player2.Score )
            {
                player1.IsWinner = true;
            }

            if (player1.Score < player2.Score)
            {
                player2.IsWinner = true;
            }

            if (player1.Score == player2.Score)
            {
                player1.ShowHand();
                player2.ShowHand();
                UserIO.ShowToUser("\nThere is no winner");

                OnGameEnd();
                return;
            }
            HaveWinner();
        }

        private void HaveWinner()
        {
            _dealer.ShowHand();
            if (_human.IsWinner == false || _dealer.IsWinner == true)
            {
                UserIO.ShowToUser("You loose");
            }

            if (_dealer.IsWinner == false || _human.IsWinner == true)
            {
                UserIO.ShowToUser("You win");
            }

            OnGameEnd();
        }
    
        private void OnGameEnd()
        {
            string input;

            while (true)
            {
                UserIO.ShowToUser("\nWhat do you want now? \nEnter 1 to play again\nEnter 2 to exit");
                input = UserIO.GetInput();
                    if(input == "1") // reset _deck and players for new game
                    {
                        _deck.Reset(); 
                        _dealer.Reset();
                        _human.Reset();
                        UserIO.ClearDisplay();
                        GameCycle();
                        break;
                    }

                    if(input == "2")
                    {
                        Environment.Exit(0);
                        break;
                    }
                    UserIO.ShowToUser("Invalid input");
            }
        }
    }
}
