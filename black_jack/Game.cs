using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using BlackJack.Enums;

namespace BlackJack
{
    internal class Game
    {
        private const int _maxScore = 21;
        private Player _dealer;
        private Player _human;
        private Deck _deck;
        private GameStatus gameStatus;

        public Game()
        {
            string humanName = UserIO.GetPlayerName();
            _deck = new Deck();

            if (humanName == "my name is Neo") // Check for spetial name
            { 
                _dealer = new Player(_deck, "mrs Smit");
                _human = new Player(_deck, "Neo");
                UserIO.MatrixEnable();
            }

            if (humanName != "my name is Neo")
            {
                _dealer = new Player(_deck, "Dealer");
                _human = new Player(_deck, humanName);
            }
            GameCycle();
        }

        private void GameCycle() 
        {
            bool humanTurn = true;
            int input;
            Random random = new Random();
            gameStatus = GameStatus.InGame;

            while (true)
            {
                if(humanTurn)
                {
                    _human.ShowHand();

                    if (CheckForWinner(_human, _dealer))
                    {
                        return;
                    }

                    while (true) // Player input
                    {
                        input = UserIO.OnGameInput(gameStatus);
                        
                        if (input == 1) // Ask Card
                        {
                            _human.AskCard();
                            break;
                        }

                        if (input == 2) // Enough
                        {
                            humanTurn = false;
                            break;
                        }

                        _human.ShowHand();
                    }
                }

                if (!humanTurn) //AI logic
                {
                    double rand = random.NextDouble();

                    if (_maxScore - _dealer.Score >= _maxScore - _deck.MaxCardInDeck ||
                        rand >= ((double)_dealer.Score - _deck.MaxCardInDeck) / ((double)_maxScore - _deck.MaxCardInDeck))
                    {
                        _dealer.AskCard();

                        if (CheckForWinner(_dealer, _human))
                        {
                            return;
                        }
                    }

                    if (_maxScore - _dealer.Score < _maxScore - _deck.MaxCardInDeck &&
                        rand < ((double)_dealer.Score - _deck.MaxCardInDeck) / ((double)_maxScore - _deck.MaxCardInDeck))
                    {
                        gameStatus = GameStatus.GameEnd;
                        CheckForWinner(_dealer, _human);
                    }
                }
            }
        }

        private bool CheckForWinner(Player player1, Player player2) // For find where game must be stoped its must return bool in my view
        {
            bool findWinner = false;
            Player winner = null;

            if (gameStatus == GameStatus.InGame)  
            {

                if (player1.Score > _maxScore || player2.Score == _maxScore)
                {
                    winner = player2;
                    findWinner = true;
                }

                if (player2.Score > _maxScore || player1.Score == _maxScore)
                {
                    winner = player1;
                    findWinner = true;
                }
            }

            if (gameStatus == GameStatus.GameEnd) 
            {
                if (player1.Score > player2.Score)
                {
                    winner = player1;
                }

                if (player1.Score < player2.Score)
                {
                    winner = player2;
                }

                if (player1.Score == player2.Score)
                {
                    winner = null;
                }

                findWinner = true;
            }
                
            if (findWinner)
            {
                gameStatus = GameStatus.GameEnd;
                player1.ShowHand();
                player2.ShowHand();
                UserIO.ShowWinner(winner);
                OnGameEnd();
            }

            return findWinner;
        }
    
        private void OnGameEnd() // When winner is found and GameCycle is end
        {
            int input;

            while (true)
            {
                input = UserIO.OnGameInput(gameStatus);

                    if(input == 1) // reset _deck and players for new game
                    {
                        _deck.Reset(); 
                        _dealer.Reset();
                        _human.Reset();
                        GameCycle();
                        break;
                    }

                    if(input == 2) //exit from application
                    {
                        Environment.Exit(0);
                        break;
                    }
            }
        }
    }
}
