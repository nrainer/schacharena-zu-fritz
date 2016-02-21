using System;
using SchacharenaZuFritz.Logic.Exceptions;

namespace SchacharenaZuFritz.Logic.Board
{
	public struct BoardPosition
	{
		private const int CHAR_OFFSET = 97;
		
		private readonly int x;
		private readonly int y;
		
		public BoardPosition(int x, int y)
		{
			if (x < 0 || x >= 8 || y < 0 || y >= 8)
			{
				throw new ConverterException("BoardPosition out of range: x = " + x + " y = " + y);
			}
			
			this.x = x;
			this.y = y;
		}
		
		public int X
		{
			get { return x; }
		}
		
		public int Y
		{
			get { return y; }
		}
		
		public override string ToString()
		{
			return ((char) (x + CHAR_OFFSET)).ToString() + (y + 1).ToString();
		}
 
		public static BoardPosition ParsePositionString(string positionString)
		{
			if (positionString.Length != 2)
			{
				throw new ConverterException("Invalid position: '" + positionString + "'");
			}
			
			int x = (positionString[0]) - CHAR_OFFSET;
			int y = int.Parse(positionString[1].ToString()) - 1;
			return new BoardPosition(x, y);
		}
	}
}
