using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WoWTCG
{
	public class Board
	{
		private Player _player1;
		private Player _player2;
		
		public Player CurrentPlayer {get; private set;}

		public Board(Player player1, Player player2)
		{
			_player1 = player1;
			_player2 = player2;
		}

		public void Start()
		{
			_player1.Start();
			_player2.Start();

			var rand = new Random();
			CurrentPlayer = (rand.Next() % 2 == 0) ?_player1 : _player2;

			MakeTurn();
		}

		private void MakeTurn()
		{
			CurrentPlayer.MakeTurn();
			CurrentPlayer = NextPlayer();
		}

		private Player NextPlayer()
		{
			if (CurrentPlayer == _player1) return _player2;
			if (CurrentPlayer == _player2) return _player1;
			throw new FieldAccessException("Unknown current player");
		}
	}
}
