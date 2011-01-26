using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WoWTCG
{
	public class HandZone : iGameZone
	{
		private List<Card> _cards = new List<Card>();

		internal void Add(Card card)
		{
			_cards.Add(card);
		}

		#region iGameZone Members

		public IEnumerable<Card> Cards
		{
			get { return _cards; }
		}

		#endregion
	}
}
