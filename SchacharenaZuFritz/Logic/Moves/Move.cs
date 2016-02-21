using System;

using SchacharenaZuFritz.Logic.Board;

namespace SchacharenaZuFritz.Logic.Moves
{
	public class Move : AbstractMove
	{
		private readonly Man man;
		private readonly BoardPosition oldPosition;
		private readonly BoardPosition newPosition;
		private readonly bool capture;
		private readonly Man transformedMan;
		
		public Move(Player player, Man man, BoardPosition oldPosition, BoardPosition newPosition) : this(player, man, oldPosition, newPosition, false, null)
		{
			
		}
		
		public Move(Player player, Man man, BoardPosition oldPosition, BoardPosition newPosition, bool capture, Man transformedMan) : base(player)
		{
			this.man = man;
			this.oldPosition = oldPosition;
			this.newPosition = newPosition;
			this.capture = capture;
			this.transformedMan = transformedMan;
		}
		
		public BoardPosition OldPosition
		{
			get { return oldPosition; }
		}
		
		public BoardPosition NewPosition
		{
			get { return newPosition; }
		}
		
		public Man TransformedMan
		{
			get { return transformedMan; }
		}
		
		public override string ToFritzString()
		{
			String output = string.Empty;
			
			output += ManTypeUtility.ManToEnglishChar(this.man.ManType);

			output += oldPosition.ToString();

			if (capture)
			{
				output += "x";
			}
			
			output += newPosition.ToString();

			if (this.transformedMan != null)
			{
				output += ManTypeUtility.ManToEnglishChar(this.transformedMan.ManType);
			}
			
			return output;
		}
	}
}
