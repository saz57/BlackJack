using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlackJack.Enums;

namespace BlackJack
{
    struct Card
    {
        public CardName Name {get; set;}
        public CardSuit Suit { get; set; }

        public Card(CardName _name, CardSuit _suit) : this()
        {
            Name = _name;
            Suit = _suit;
        }

        public override string ToString()
        {
            return Name.ToString() + " " + Suit.ToString();
        }
    }
}
