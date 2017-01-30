using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace black_jack
{
    class Player : IPlayer
    {
        private string name;
        private List<Card> hand;
        private IDeck gameDeck;
        public int Score { get; private set; }

        public Player(IDeck _deck, string _name = "Player")
        {
            name = _name;
            gameDeck = _deck;
            hand = new List<Card>();
            Score = 0;
            AskCard();
        }


        public void AskCard()
        {
            hand.Add(gameDeck.GetCard());
            Score += (int)hand.Last<Card>().Name;
        }

        public void ShowHand()
        {
            Console.WriteLine("\n" + name + " have in hand:");
            foreach (Card _card in hand)
            {
                Console.WriteLine(_card.ToString());
            }
            Console.WriteLine("\nTotal score is: " + Score.ToString());
        }

        public void Reset()
        {
            Score = 0;
            hand.Clear();
            AskCard();
        }
    }
}
