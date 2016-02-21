using System;
using System.Text;
using SchacharenaZuFritz.Logic.Game;
using SchacharenaZuFritz.Logic.Converter;
using SchacharenaZuFritz.Logic.Board;
using SchacharenaZuFritz.Logic.Moves;

namespace SchacharenaZuFritz.Logic.Converter.Fritz
{
	public class FritzOutputGeneratorV1 : IChessOutputGenerator
	{
		private ChessGame game;
		
		public void Initialize(ChessGame game)
		{
			this.game = game;
		}
		
		public string ToFritzString()
		{
			StringBuilder outputBuilder = new StringBuilder();
			
			CreateDefaultHeader(outputBuilder);
			outputBuilder.AppendLine();
			CreateBody(outputBuilder);

			return outputBuilder.ToString();
		}
		
		private void CreateDefaultHeader(StringBuilder outputBuilder)
		{
			outputBuilder.AppendLine("[Event \"Partie\"]");
			outputBuilder.AppendLine("[Site \"www.schacharena.de\"]");
			outputBuilder.AppendLine("[Date \"" + this.game.DateText + "\"]");
			outputBuilder.AppendLine("[Round \"?\"]");
			outputBuilder.AppendLine("[White \"" + this.game.PlayerName1 + "\"]");
			outputBuilder.AppendLine("[Black \"" + this.game.PlayerName2 + "\"]");
			outputBuilder.AppendLine("[Result \"*\"]");
		}
		
		private void CreateBody(StringBuilder outputBuilder)
		{
			for (int moveIndex = 0; moveIndex < this.game.Moves.Count; moveIndex++)
			{
				int moveNumber = (moveIndex / 2) + 1;
				IMove currentMove = this.game.Moves[moveIndex];
				
				if (currentMove.Player == Player.White)
				{
					outputBuilder.Append(moveNumber);
					outputBuilder.Append(". ");
				}

				outputBuilder.Append(currentMove.ToFritzString());
				outputBuilder.Append(" ");
			}
		}
	}
}
