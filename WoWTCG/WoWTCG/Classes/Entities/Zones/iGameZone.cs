using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WoWTCG
{
	public interface iGameZone
	{
		IEnumerable<Card> Cards
		{
			get;
		}
	}
}
