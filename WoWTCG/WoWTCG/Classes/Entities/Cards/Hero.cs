using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WoWTCG
{
	public class Hero : Card
	{
		public String Health { get { return _fullCard.Health; } }
		public String Class { get { return _fullCard.Class ; } }
	}
}
