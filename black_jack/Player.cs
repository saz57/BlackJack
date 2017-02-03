using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJack
{
    class Player
    {
        private List<Card> _hand;
        private Deck _gameDeck;

        public bool? IsWinner { get; set;} 
        public string Name {get; private set; }
        public int Score { get; private set; }

        public Player(Deck deck, string name = "Player")
        {
            Name = name;
            IsWinner = null;
            _gameDeck = deck;
            _hand = new List<Card>();
            Score = 0;
            AskCard();
        }

        public void AskCard()
        {
            _hand.Add(_gameDeck.GetCard());
            Score += (int)_hand.Last<Card>().Name;
        }

        public void ShowHand()
        {
            UserIO.ShowToUser("\n" + Name + " have in hand:");
            foreach (Card card in _hand)
            {
                UserIO.ShowToUser(card.ToString());
            }

            UserIO.ShowToUser("\nTotal score is: " + Score.ToString());
        }

        public void Reset()
        {
            Score = 0;
            IsWinner = null;
            _hand.Clear();
            AskCard();
        }
    }
}
