using System;
using System.Collections.Generic;
using SchacharenaZuFritz.Logic.Board;
using SchacharenaZuFritz.Logic.Moves;

namespace SchacharenaZuFritz.Logic.Game
{
	public class ChessGame
	{
		private string dateText = "?";
		private string playerName1 = "Player 1";
		private string playerName2 = "Player 2";
		private List<IMove> moves;
		
		public ChessGame()
		{
			this.moves = new List<IMove>();
		}
		
		public string DateText
		{
			get { return dateText; }
			set { dateText = value; }
		}		
				
		public string PlayerName1
		{
			get { return playerName1; }
			set { playerName1 = value; }
		}
		
		public string PlayerName2
		{
			get { return playerName2; }
			set { playerName2 = value; }
		}
		
		public List<IMove> Moves
		{
			get { return moves; }
		}
		
		public void AddMove(IMove move)
		{
			this.moves.Add(move);
		}
	}
}
