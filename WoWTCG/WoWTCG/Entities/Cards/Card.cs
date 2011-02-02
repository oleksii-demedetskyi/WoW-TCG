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
		private System.Xml.XmlNode _node;

		public string CardNumber { get; protected set; }
		public string Rarity { get; protected set; }
		public string Faction { get; protected set; }
		public string ClassRestriction { get; protected set; }
		public string Rules { get; protected set; }
		public string Name { get; protected set; }

		public Card Clone()
		{
			return Card.Create(_node);
		}

		public static Card Create(System.Xml.XmlNode item)
		{
			Func<System.Xml.XmlNode,string,string> propValue = (node,name) => 
				{
					var property = node.SelectSingleNode("property[@name='" + name + "']");
					if (property == null) return null;

					return property.Attributes["value"].Value;
				};

			Card card = null;
			switch (propValue(item,"Type"))
			{
				case "Hero":
					card = new Hero()
					{
						Health = propValue(item, "Health"),
						Class = propValue(item, "Class")
					};
					break;

				case "Master Hero":
				case "Ally":
					card = new Ally()
					{
						Cost = propValue(item, "Cost"),
						ATK = propValue(item, "ATK"),
						Health = propValue(item, "Health"),
						Class = propValue(item, "Class")
					};
					break;

				case "Location":
				case "Quest":
					card = new Quest();
					break;

				case "Ability":
					card = new Ability()
					{
						Cost = propValue(item, "Cost")
					};
					break;

				case "Weapon":
					card = new Weapon() {
						Cost = propValue(item, "Cost"),
						ATK = propValue(item, "ATK"),
						StrikeCost = propValue(item, "Strike Cost") // TODO
					};
					break;

				case "Armor":
					card = new Armor()
					{
						Cost = propValue(item, "Cost"),
						DEF = propValue(item, "DEF") // TODO
					};
					break;

				case "Item":
					card = new Item()
					{
						Cost = propValue(item, "Cost")
					};
					break;

				default:
					throw new ArgumentOutOfRangeException("Type","Unknown card type");
			}

			card.Name = item.Attributes["name"].Value;
			card.CardNumber = propValue(item, "Card Number");
			card.Rarity = propValue(item, "Rarity");
			card.Faction = propValue(item, "Faction");
			card.ClassRestriction = propValue(item, "Class Restriction");
			card.Rules = propValue(item, "Rules");

			card._node = item;
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
