using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WoWTCG
{
	public class CardFactory
	{
		private Dictionary<Hero, Deck> _libriary;

		public CardFactory()
		{
			_libriary = ParseLib();
		}

		private Dictionary<Hero, Deck> ParseLib()
		{
			var lib = new Dictionary<Hero, Deck>();

			var cards = Parser.Parser.GetDeck(4906);

			return lib;
		}

		public Player NewPlayer()
		{
			var rand = new Random();

			var pair = _libriary.ElementAt(rand.Next(_libriary.Count-1));
			return new Player(pair.Value, pair.Key);
		}
	}
}
