using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using black_jack.Enums;

namespace black_jack
{
    class Deck : IDeck
    {
        private List<Card> deck;

        public Deck()
        {   
            deck = new List<Card>();
            OnNewGame();
        }
            

        public Card GetCard()
        {

            int index;
            Card buffCard;
            Random random = new Random();
            index = random.Next(deck.Count);
//            Console.WriteLine("\n" + index.ToString() + " in " + deck.Count.ToString() + "\n");
            buffCard = deck[index];
            deck.RemoveAt(index);
            return buffCard;
        }

        public void Reset()
        {
            deck.Clear();
            int suitsCount = Enum.GetValues(typeof(CardSuit)).Length;
            Array cardNameValue = Enum.GetValues(typeof(CardName));
            for (int i = 0; i < suitsCount; i++)
            {
                for (int j = 0; j < cardNameValue.Length; j++)
                {
                    deck.Add(new Card((CardName)cardNameValue.GetValue(j), (CardSuit)i));
                }
            }
        }
    }
}
