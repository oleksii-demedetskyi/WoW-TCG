using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WoWTCG
{
	public class Graveyard : iGameZone
	{
		private List<Card> _cards;

		#region iGameZone Members

		IEnumerable<Card> iGameZone.Cards
		{
			get { return _cards; }
		}

		#endregion

		internal void Add(Card card)
		{
			_cards.Add(card);
		}
	}
}
