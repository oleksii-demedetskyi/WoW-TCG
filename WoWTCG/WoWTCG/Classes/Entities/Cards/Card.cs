using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WoWTCG
{
	public class Card
	{
		private global::Program.FullCard _full;

		public string Name { get { return _full.Name; } }
		public string ImagePath { get { return _full.ImagePath; } }
		public string LargeImagePath { get { return _full.LargeImagePath; } }

		public string Talent { get { return _full.Talent; } }
		public string Professions { get { return _full.Professions; } }

		public string StrikeCost { get { return _full.StrikeCost; } }
		public string DEF { get { return _full.DEF; } }
		public string Tags { get { return _full.Tags; } }

		public string Type { get { return _full.Type; } }
		public string Supertype { get { return _full.Supertype; } }
		public string Subtype { get { return _full.Subtype; } }

		public string Race { get { return _full.Race; } }
		public string Class { get { return _full.Class; } }
		public string Faction { get { return _full.Faction; } }

		public string Cost { get { return _full.Cost; } }
		public string Health { get { return _full.Health; } }
		public string ATK { get { return _full.ATK; } }
		public string ATKType { get { return _full.ATKType; } }

		public string RequireClass { get { return _full.RequireClass; } }
		public string RequireProfession { get { return _full.RequireProfession; } }
		public string RequireRace { get { return _full.RequireRace; } }
		public string RequireTalent { get { return _full.RequireTalent; } }
		public string RequireReputation { get { return _full.RequireReputation; } }

		public string Rules { get { return _full.Rules; } }
		public string Flavor { get { return _full.Flavor; } }
		public string Number { get { return _full.Number; } }
		public string Set { get { return _full.Set; } }
		public string RelatedLinks { get { return _full.RelatedLinks; } }
		public string Rulings { get { return _full.Rulings; } }
		public string Notes { get { return _full.Notes; } }
		public string Rarity { get { return _full.Rarity; } }
		public string Artist { get { return _full.Artist; } }

		private List<Power> _powers;
		private bool _exhausted;

		public Card Clone()
		{
			return Create(_full);
		}

		public static Card Create(global::Program.FullCard full)
		{
			return new Card {_full = full};
		}

		protected Card()
		{
			_exhausted = false;
		}

		#region IExhaustble Members

		public bool Exhausted
		{
			get
			{
				return _exhausted;
			}
		}

		public void Ready()
		{
			_exhausted = false;
		}

		public void Exhaust()
		{
			_exhausted = true;
		}

		#endregion
	}
}
