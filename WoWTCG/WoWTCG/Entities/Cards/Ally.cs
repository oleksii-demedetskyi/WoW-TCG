using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WoWTCG
{
	public class Ally : Card
	{
		public String Health { get; internal set; }
		public String ATK { get; internal set; }
		public String Cost { get; internal set; }
		public String Class { get; internal set; }
	}
}
