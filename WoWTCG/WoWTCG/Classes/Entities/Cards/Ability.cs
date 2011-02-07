using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WoWTCG
{
	public class Ability : Card
	{
		public String Cost { get { return _fullCard.Cost; } }
	}
}
