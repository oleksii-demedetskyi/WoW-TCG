using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WoWTCG
{
	public class Weapon : Equipment
	{
		public String ATK { get { return _fullCard.ATK; } }
		public String StrikeCost { get { return _fullCard.StrikeCost; } }
	}
}
