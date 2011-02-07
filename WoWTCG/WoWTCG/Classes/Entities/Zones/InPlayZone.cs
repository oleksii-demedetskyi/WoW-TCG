﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WoWTCG
{
	public class InPlayZone : iGameZone
	{
		private List<Card> _cards = new List<Card>();

		#region iGameZone Members

		IEnumerable<Card> iGameZone.Cards
		{
			get { return _cards; }
		}

		#endregion

		internal void ReadyAll()
		{
			foreach (IExhaustble item in _cards)
			{
				item.Ready();
			}
		}
	}
}