using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WoWTCG
{
	public class Equipment : Card
	{
		public String Cost { get { return _fullCard.Cost; } }
		public String Tags { get { return _fullCard.Tags; } }
	}
}
