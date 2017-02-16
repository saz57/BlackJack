using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlackJack.Enums;

namespace BlackJack
{
    internal class Deck
    {
        public int MaxCardInDeck { get; private set; } // for the AI logic
        private List<Card> _deck;

        public Deck()
        {   
            _deck = new List<Card>();
            Reset();
        }
            

        public Card GetCard()
        {
            Card buffCard;
            buffCard = _deck.Last<Card>();
            _deck.Remove(buffCard);
            return buffCard;
        }

        public void Reset()
        {
            _deck.Clear();
            int maxCard = 0;
            int suitsCount = Enum.GetValues(typeof(CardSuit)).Length;
            Array cardNameValue = Enum.GetValues(typeof(CardName)); // fix - Change Array to something I don't now for what i can change Array,
                                                                    //because Enum.GetValues() return Array 
           
            for (int i = 0; i < suitsCount; i++)
            {
                for (int j = 0; j < cardNameValue.Length; j++)
                {
                    Card card = new Card();
                    card.Name = (CardName) cardNameValue.GetValue(j);
                    card.Suit = (CardSuit) i;
                    
                    if(maxCard < (int)card.Name)
                    {
                        maxCard = (int)card.Name;
                    }

                    _deck.Add(card);
                }
            }
            MaxCardInDeck = maxCard;
            MixCards(50);
        }

        private void MixCards(uint iterations)
        {
            int randomIndex = 0;
            int randomSize = 0;
            Random random = new Random();
            
            for(int i = 0; i < iterations; i++)
            {
                randomSize = random.Next(_deck.Count / 2);
                randomIndex = random.Next(_deck.Count - randomSize);
                Card[] buff = new Card[randomSize];
                _deck.CopyTo(randomIndex, buff, 0,randomSize);
                _deck.RemoveRange(randomIndex, randomSize);
                _deck.InsertRange(0, buff);
            }
        }

    }
}
