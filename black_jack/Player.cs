using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJack
{
    internal class Player
    {
        private List<Card> _hand;
        private Deck _gameDeck;

        public string Name {get; private set; }
        public int Score { get; private set; }

        public Player(Deck deck, string name)
        {
            Name = name;
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
            UserIO.ShowHand(this, _hand.ToArray());
        }

        public void Reset()
        {
            Score = 0;
            _hand.Clear();
            AskCard();
        }
    }
}
