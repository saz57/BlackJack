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
        public int MaxCardInDeck { get; private set; }
        private int _lastImagedCardIndex;
        private int _imageCardScoreOffset;
        private int _valueCardScoreOffset;
        private uint _mixIterations;
        private List<Card> _deck;
        private Dictionary<CardName, int> _cardNameToScore;

        public Deck()
        {
            _lastImagedCardIndex = 3;
            _imageCardScoreOffset = 1;
            _valueCardScoreOffset = 2;
            _mixIterations = 50;

            _cardNameToScore = new Dictionary<CardName, int>();
            _deck = new List<Card>();

            for (int i = 0; i < _lastImagedCardIndex + 1; i++)
            {
                _cardNameToScore.Add((CardName)i, i + _imageCardScoreOffset);
            }

            for (int i = _lastImagedCardIndex + 1; i < Enum.GetValues(typeof(CardName)).Length; i++)
            {
                _cardNameToScore.Add((CardName)i, i + _valueCardScoreOffset);
            }
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
           
            for (int i = 0; i < suitsCount; i++)
            {
                for (int j = 0; j < _cardNameToScore.Count; j++)
                {
                    Card card = new Card();
                    card.Name = (CardName) j;
                    card.Suit = (CardSuit) i;
                    card.Score = _cardNameToScore[(CardName)j];

                    if (maxCard < _cardNameToScore[(CardName)j])
                    {
                        maxCard = _cardNameToScore[(CardName)j];
                    }

                    _deck.Add(card);
                }
            }
            MaxCardInDeck = maxCard;
            MixCards(_mixIterations);
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
