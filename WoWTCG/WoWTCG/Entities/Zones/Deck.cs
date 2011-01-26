using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WoWTCG
{
	public class Deck
	{
		private Queue<Card> _cards;

		public Deck(Queue<Card> cards)
		{
			_cards = cards;
		}

		public void Shuffle()
		{
			// shuffle cards
			throw new NotImplementedException("Need to shuffle");
		}

		public HandZone GetHand()
		{
			var hand = new HandZone();

			for (int i = 0; i < 7; i++)
			{
				var card = Draw();
				hand.Add(card);
			}

			return hand;
		}

		public Card Draw()
		{
			return _cards.Dequeue();
		}

		internal void ReturnCards(IEnumerable<Card> cards)
		{
			foreach (var card in cards)
				_cards.Enqueue(card);
		}
	}
}
