using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WoWTCG
{
	public class Weapon : Equipment
	{
		public String Cost { get; internal set; }
		public String ATK { get; internal set; }
		public String StrikeCost { get; internal set; }
	}
}
