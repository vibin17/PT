using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using L12.Enums;

namespace L12
{
    class Card
    {
        private CardTypes Type { get; set; }
        private Suits Suit { get; set; }
        public Card(int number)
        {
            number--;
            Type = (CardTypes)(number % 13);
            Suit = (Suits)(number / 13);
        }
        public string Info () => Type.ToString().Remove(0, 1) + " of " + Suit.ToString();
        public static Card[] GenerateSet()
        {
            Card[] cards = new Card[52];
            for (int i = 1; i <= 52; i++)
                cards[i - 1] = new Card(i);
            return cards;
        }
    }
}
