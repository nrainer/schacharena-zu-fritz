using System;

using SchacharenaZuFritz.Logic.Board;

namespace SchacharenaZuFritz.Logic.Moves
{
	public abstract class AbstractMove : IMove
	{
		private readonly Player player;
		
		public AbstractMove(Player player)
		{
			this.player = player;
		}
		
		public abstract string ToFritzString();
		 
		public Player Player
		{
			get
			{
				return player;
			}
		}
	}
}
