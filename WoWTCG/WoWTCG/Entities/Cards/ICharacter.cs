using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WoWTCG
{
	public interface ICharacter
	{
		event EventHandler Dead;
	
		int Health
		{
			get;
			set;
		}

		int DamageCount
		{
			get;
			set;
		}

		int CurrentHealth
		{
			get;
			set;
		}
	}
}
