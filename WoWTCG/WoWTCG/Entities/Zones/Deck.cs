using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WoWTCG
{
	public class Deck
	{
		private Queue<Card> _cards;

		public Deck(IEnumerable<Card> cards)
		{
			_cards = new Queue<Card>(cards);
		}

		public void Shuffle()
		{
			_cards = new Queue<Card>(_cards.OrderBy(x => Guid.NewGuid()));
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
