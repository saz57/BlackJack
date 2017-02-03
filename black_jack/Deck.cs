using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlackJack.Enums;

namespace BlackJack
{
    class Deck
    {
        private List<Card> _deck;

        public Deck()
        {   
            _deck = new List<Card>();
            Reset();
        }
            

        public Card GetCard()
        {
            int index;
            Card buffCard;
            Random random = new Random();
            index = random.Next(_deck.Count);
//            UserIO.ShowToUser("\n" + index.ToString() + " in " + _deck.Count.ToString() + "\n");
            buffCard = _deck[index];
            _deck.RemoveAt(index);
            return buffCard;
        }

        public void Reset()
        {
            _deck.Clear();
            int suitsCount = Enum.GetValues(typeof(CardSuit)).Length;
            Array cardNameValue = Enum.GetValues(typeof(CardName));
            for (int i = 0; i < suitsCount; i++)
            {
                for (int j = 0; j < cardNameValue.Length; j++)
                {
                    _deck.Add(new Card((CardName)cardNameValue.GetValue(j), (CardSuit)i));
                }
            }
        }
    }
}
