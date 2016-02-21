using System;

using SchacharenaZuFritz.Logic.Board;

namespace SchacharenaZuFritz.Logic.Moves
{
	public class Castling : AbstractMove
	{
		private readonly bool longCastling;
		
		public Castling(Player player, bool longCastling) : base(player)
		{
			this.longCastling = longCastling;
		}

		public bool LongCastling
		{
			get { return longCastling; }
		}
		
		public override string ToFritzString()
		{
			if (longCastling)
			{
				return "0-0-0";
			}
			
			return "0-0";
		}
	}
}
