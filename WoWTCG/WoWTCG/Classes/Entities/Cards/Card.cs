using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WoWTCG
{
	public class Card : IExhaustble
	{
		private List<Power> _powers;
		private bool _exhausted;
		internal global::Program.FullCard _fullCard;

		public string CardNumber { get { return _fullCard.Number; } }
		public string Rarity { get { return _fullCard.Rarity; } }
		public string Faction { get { return _fullCard.Faction; } }
		public string ClassRestriction { get { return _fullCard.RequireClass; } }
		public string Rules { get { return _fullCard.Rules; } }
		public string Name { get { return _fullCard.Name; } }

		public Card Clone()
		{
			return Card.Create(_fullCard);
		}

		public static Card Create(global::Program.FullCard item)
		{
			Card card = null;
			switch (item.Type)
			{
				case "Hero": card = new Hero(); break;
				case "Master Hero":
				case "Ally": card = new Ally(); break;
				case "Location":
				case "Quest":card = new Quest();break;
				case "Ability": card = new Ability(); break;
				case "Weapon": card = new Weapon();break;
				case "Armor": card = new Armor(); break;
				case "Item": card = new Item(); break;

				default:
					throw new ArgumentOutOfRangeException("Type","Unknown card type");
			}
			card._fullCard = item;
			return card;
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
