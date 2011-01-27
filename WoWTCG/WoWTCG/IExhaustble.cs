using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WoWTCG
{
	public interface IExhaustble
	{
		bool Exhausted
		{
			get;
			set;
		}
	
		void Ready();

		void Exhaust();
	}
}
