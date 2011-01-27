using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WoWTCG
{
	public class Player
	{
		private Deck _deck;
		private Hero _hero;
		private Graveyard _graveyard;
		private HandZone _hand;
		private RemovedFromGame _rfg;
		private InPlayZone _inPlay;

		public Player(Deck deck, Hero hero)
		{
			_hero = hero;
			_deck = deck;

			_graveyard = new Graveyard();
			_inPlay = new InPlayZone();
			_rfg = new RemovedFromGame();
		}

		public Hero Hero
		{
			get
			{
				return _hero;
			}
		}

		public InPlayZone PlayZone
		{
			get
			{
				return _inPlay;
			}
		}

		public Graveyard Graveyard
		{
			get
			{
				return _graveyard;
			}
		}

		public RemovedFromGame RFG
		{
			get
			{
				return _rfg;
			}
		}

		public void Start()
		{
			_hand = _deck.GetHand();

			// Mulligan
			if (false /* hand is very bad */) 
			{
				_deck.ReturnCards(_hand.Cards);
				_deck.Shuffle();

				_hand = _deck.GetHand();
			}
		}

		internal void MakeTurn()
		{
			/* START phase */
			_inPlay.ReadyAll(); // Ready step
			// TODO: Triggered effects. Player has priority

			_hand.Add(_deck.Draw()); // Draw step
			
			/* ACTION phase */
			Act(); // play-non instant; place a resource; propose a combat;

			/*END pahse*/
			// TODO: Triggered events add to the chain. Player has priority
			if (_hand.Cards.Count() > 7) // Wrap-Up
			{
				Discard();
			}
			// Expire modifiers (until end of turn...)
		}

		private void Discard()
		{
			var card = SelectDiscardCard();
			_hand.Discard(card);
			_graveyard.Add(card);
		}

		private Card SelectDiscardCard()
		{
			// TODO: implenet #AI;
			return _hand.Cards.FirstOrDefault();
		}

		private void Act()
		{
			throw new NotImplementedException();
		}
	}
}
