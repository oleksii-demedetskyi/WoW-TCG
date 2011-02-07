using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using Parser;

namespace WoWTCG
{
	public class CardFactory
	{
		private Dictionary<Hero, Deck> _libriary;
		private IEnumerable<Card> _cards;


		public CardFactory()
		{
			_cards = LoadSets().ToList();
			_libriary = ParseLib();
		}

		private IEnumerable<Card> LoadSets()
		{
			foreach (var item in SetParser.ParseSet(Sets.Icecrown))
			{
				yield return Card.Create(item);
			}
		}

		private Dictionary<Hero, Deck> ParseLib()
		{
			var lib = new Dictionary<Hero, Deck>();

			var doc = new XmlDocument(); doc.LoadXml(Decks.decks);
			var root = doc.DocumentElement;

			foreach (XmlNode deckNode in root.SelectNodes("deck"))
			{
				var cards = ParseDeck(deckNode);
				var hero = cards.OfType<Hero>().Single();
				var deck = new Deck(cards.Where(x=>!x.GetType().Equals(hero.GetType())));

				lib.Add(hero, deck);
			}

			return lib;
		}

		private IEnumerable<Card> ParseDeck(XmlNode deck)
		{
			foreach (XmlNode card in deck.SelectNodes("card"))
			{
				for (int i = 0; i < Int32.Parse(card.Attributes["count"].Value); i++)
				{
					yield return _cards.First(x => x.Name == card.Attributes["name"].Value).Clone();
				}
			}
		}

		public Player NewPlayer()
		{
			var rand = new Random();

			var pair = _libriary.ElementAt(rand.Next(_libriary.Count-1));
			return new Player(pair.Value, pair.Key);
		}
	}
}
