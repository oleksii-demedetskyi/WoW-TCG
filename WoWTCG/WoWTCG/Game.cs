using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WoWTCG
{
	public class Game
	{
		private Board _board;
		private CardFactory _factory;


		public Game()
		{
			_factory = new CardFactory();
			_board = new Board(_factory.NewPlayer(),_factory.NewPlayer());
		}

		public void Play()
		{
			_board.Start();
		}
	}
}
