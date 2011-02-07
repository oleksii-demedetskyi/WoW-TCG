using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WoWTCG
{
	public class Ally : Card
	{
		public String Health { get { return _fullCard.Health; } }
		public String ATK { get { return _fullCard.ATK; } }
		public String Cost { get { return _fullCard.Cost; } }
		public String Class { get { return _fullCard.Class; } }
	}
}
