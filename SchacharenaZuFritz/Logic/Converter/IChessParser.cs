using System;

using SchacharenaZuFritz.Logic.Game;

namespace SchacharenaZuFritz.Logic.Converter
{
	public interface IChessParser
	{
		void Initialize(string input);
		
		ChessGame ParseChessGame();
	}
}
