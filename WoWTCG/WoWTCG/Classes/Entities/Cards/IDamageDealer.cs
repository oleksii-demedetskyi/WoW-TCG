using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WoWTCG
{
	public interface IDamageDealer
	{
		AtkType DamageType
		{
			get;
			set;
		}

		int Count
		{
			get;
			set;
		}
	}
}
