using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domains
{
	public static class ExtensionMethods
	{
		public static int CountPoints(this List<Card> cards)
		{
			int points = 0;
			List<Card> aces = new();

			if (cards != null)
			{
				foreach (var card in cards)
				{
					if (card.CardNumber == CardNumber.Ace)
					{
						aces.Add(card); // put aces in separate list for counting
					}
					else
					{
						if (card.CardNumber < CardNumber.Jack)
						{
							points += (int)card.CardNumber; // 2-10 points = card value
						}
						else
						{
							points += 10; // jack,queen,king point = 10
						}
					};
				}

				foreach (var card in aces)
				{
					points += 11;

					if (points > 21)
					{
						points -= 10;
					}
				}
			}

			return points;
		}

		public static string ToUnicode(this Card card)
		{
			if (card.CardNumber == CardNumber.Ace)
			{
				if (card.Suit == Suit.Spades)
				{
					return "\U0001f0a1";
				}
				else if (card.Suit == Suit.Heart)
				{
					return "\U0001f0b1";
				}
				else if (card.Suit == Suit.Diamond)
				{
					return "\U0001f0c1";
				}
				else if (card.Suit == Suit.Club)
				{
					return "\U0001f0d1";
				}
			}
			if (card.CardNumber == CardNumber.Two)
			{
				if (card.Suit == Suit.Spades)
				{
					return "\U0001f0a2";
				}
				else if (card.Suit == Suit.Heart)
				{
					return "\U0001f0b2";
				}
				else if (card.Suit == Suit.Diamond)
				{
					return "\U0001f0c2";
				}
				else if (card.Suit == Suit.Club)
				{
					return "\U0001f0d2";
				}
			}
			if (card.CardNumber == CardNumber.Three)
			{
				if (card.Suit == Suit.Spades)
				{
					return "\U0001f0a3";
				}
				else if (card.Suit == Suit.Heart)
				{
					return "\U0001f0b3";
				}
				else if (card.Suit == Suit.Diamond)
				{
					return "\U0001f0c3";
				}
				else if (card.Suit == Suit.Club)
				{
					return "\U0001f0d3";
				}
			}
			if (card.CardNumber == CardNumber.Four)
			{
				if (card.Suit == Suit.Spades)
				{
					return "\U0001f0a4";
				}
				else if (card.Suit == Suit.Heart)
				{
					return "\U0001f0b4";
				}
				else if (card.Suit == Suit.Diamond)
				{
					return "\U0001f0c4";
				}
				else if (card.Suit == Suit.Club)
				{
					return "\U0001f0d4";
				}
			}
			if (card.CardNumber == CardNumber.Five)
			{
				if (card.Suit == Suit.Spades)
				{
					return "\U0001f0a5";
				}
				else if (card.Suit == Suit.Heart)
				{
					return "\U0001f0b5";
				}
				else if (card.Suit == Suit.Diamond)
				{
					return "\U0001f0c5";
				}
				else if (card.Suit == Suit.Club)
				{
					return "\U0001f0d5";
				}
			}
			if (card.CardNumber == CardNumber.Six)
			{
				if (card.Suit == Suit.Spades)
				{
					return "\U0001f0a6";
				}
				else if (card.Suit == Suit.Heart)
				{
					return "\U0001f0b6";
				}
				else if (card.Suit == Suit.Diamond)
				{
					return "\U0001f0c6";
				}
				else if (card.Suit == Suit.Club)
				{
					return "\U0001f0d6";
				}
			}
			if (card.CardNumber == CardNumber.Seven)
			{
				if (card.Suit == Suit.Spades)
				{
					return "\U0001f0a7";
				}
				else if (card.Suit == Suit.Heart)
				{
					return "\U0001f0b7";
				}
				else if (card.Suit == Suit.Diamond)
				{
					return "\U0001f0c7";
				}
				else if (card.Suit == Suit.Club)
				{
					return "\U0001f0d7";
				}
			}
			if (card.CardNumber == CardNumber.Eight)
			{
				if (card.Suit == Suit.Spades)
				{
					return "\U0001f0a8";
				}
				else if (card.Suit == Suit.Heart)
				{
					return "\U0001f0b8";
				}
				else if (card.Suit == Suit.Diamond)
				{
					return "\U0001f0c8";
				}
				else if (card.Suit == Suit.Club)
				{
					return "\U0001f0d8";
				}
			}
			if (card.CardNumber == CardNumber.Nine)
			{
				if (card.Suit == Suit.Spades)
				{
					return "\U0001f0a9";
				}
				else if (card.Suit == Suit.Heart)
				{
					return "\U0001f0b9";
				}
				else if (card.Suit == Suit.Diamond)
				{
					return "\U0001f0c9";
				}
				else if (card.Suit == Suit.Club)
				{
					return "\U0001f0d9";
				}
			}
			else if (card.CardNumber == CardNumber.Ten)
			{
				if (card.Suit == Suit.Spades)
				{
					return "\U0001f0aa";
				}
				else if (card.Suit == Suit.Heart)
				{
					return "\U0001f0ba";
				}
				else if (card.Suit == Suit.Diamond)
				{
					return "\U0001f0ca";
				}
				else if (card.Suit == Suit.Club)
				{
					return "\U0001f0da";
				}
			}
			else if (card.CardNumber == CardNumber.Jack)
			{
				if (card.Suit == Suit.Spades)
				{
					return "\U0001f0ab";
				}
				else if (card.Suit == Suit.Heart)
				{
					return "\U0001f0bb";
				}
				else if (card.Suit == Suit.Diamond)
				{
					return "\U0001f0cb";
				}
				else if (card.Suit == Suit.Club)
				{
					return "\U0001f0db";
				}
			}
			else if (card.CardNumber == CardNumber.Queen)
			{
				if (card.Suit == Suit.Spades)
				{
					return "\U0001f0ad";
				}
				else if (card.Suit == Suit.Heart)
				{
					return "\U0001f0bd";
				}
				else if (card.Suit == Suit.Diamond)
				{
					return "\U0001f0cd";
				}
				else if (card.Suit == Suit.Club)
				{
					return "\U0001f0dd";
				}
			}
			else if (card.CardNumber == CardNumber.King)
			{
				if (card.Suit == Suit.Spades)
				{
					return "\U0001f0ae";
				}
				else if (card.Suit == Suit.Heart)
				{
					return "\U0001f0be";
				}
				else if (card.Suit == Suit.Club)
				{
					return "\U0001f0ce";
				}
				else if (card.Suit == Suit.Diamond)
				{
					return "\U0001f0de";
				}
			}
			return "\u0001f0a0";
		}
	}
}
