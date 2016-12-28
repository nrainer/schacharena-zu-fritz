using System;

using SchacharenaZuFritz.Logic.Converter.Fritz;
using SchacharenaZuFritz.Logic.Converter.Schacharena;
using SchacharenaZuFritz.Logic.Game;

namespace SchacharenaZuFritz.Logic.Converter
{
	public static class ConverterFactory
	{
		public static IChessParser CreateSchacharenaParser(string input)
		{
			IChessParser parser = new SchacharenaParserV2();
			parser.Initialize(input);
			return parser;
		}
		
		public static IChessOutputGenerator CreateFritzOutputGenerator(ChessGame game)
		{
			IChessOutputGenerator outputGenerator = new FritzOutputGeneratorV1();
			outputGenerator.Initialize(game);
			return outputGenerator;
		}
	}
}
