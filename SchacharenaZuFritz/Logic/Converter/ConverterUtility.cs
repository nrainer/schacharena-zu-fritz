using System;

using SchacharenaZuFritz.Logic.Game;

namespace SchacharenaZuFritz.Logic.Converter
{
	public static class ConverterUtility
	{
		public static string ConvertFromSchacharenaToFritz(string schacharenaInput)
        {
        	  IChessParser parser = ConverterFactory.CreateSchacharenaParser(schacharenaInput);
        	  ChessGame game = parser.ParseChessGame();
        	  
        	  IChessOutputGenerator outputGenerator = ConverterFactory.CreateFritzOutputGenerator(game);
        	  return outputGenerator.ToFritzString();
        }
	}
}
