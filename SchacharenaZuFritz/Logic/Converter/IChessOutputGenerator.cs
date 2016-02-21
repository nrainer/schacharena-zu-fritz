using System;

using SchacharenaZuFritz.Logic.Game;

namespace SchacharenaZuFritz.Logic.Converter
{
	public interface IChessOutputGenerator
	{
		void Initialize(ChessGame game);
		
		string ToFritzString();
	}
}
