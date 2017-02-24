using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlackJack.Enums;

namespace BlackJack
{
    internal class Card
    {
        public int Score { get; set;}
        public CardName Name {get; set;}
        public CardSuit Suit { get; set;}
    }
}
