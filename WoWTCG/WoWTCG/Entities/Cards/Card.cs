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

		#region IExhaustble Members

		public bool Exhausted
		{
			get
			{
				throw new NotImplementedException();
			}
			set
			{
				throw new NotImplementedException();
			}
		}

		public void Ready()
		{
			throw new NotImplementedException();
		}

		public void Exhaust()
		{
			throw new NotImplementedException();
		}

		#endregion
	}
}
