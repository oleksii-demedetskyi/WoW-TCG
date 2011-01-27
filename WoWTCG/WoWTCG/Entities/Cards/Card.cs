using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WoWTCG
{
	public class Card : IExhaustble
	{
		private int _cost;
		private List<Power> _powers;
		private string _name;
		private bool _exhausted;

		#region IExhaustble Members

		public bool Exhausted
		{
			get
			{
				return _exhausted;
			}
		}

		public void Ready()
		{
			_exhausted = false;
		}

		public void Exhaust()
		{
			_exhausted = true;
		}

		#endregion
	}
}
