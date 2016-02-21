using System;
using NUnit.Framework;
using SchacharenaZuFritz.Logic.Board;
using SchacharenaZuFritz.Logic.Moves;

namespace SchacharenaZuFritz.Test
{
	[TestFixture]
	public class ChessBoardTest
	{
		[Test]
		public void TestInitialBoardState()
		{
			ChessBoard board = new ChessBoard();
			Assert.AreEqual(ManType.Pawn, board.GetManOnPosition(BoardPosition.ParsePositionString("a2")).ManType);
			Assert.AreEqual(ManType.Pawn, board.GetManOnPosition(BoardPosition.ParsePositionString("a7")).ManType);
		}
		
		[Test]
		public void TestMoves()
		{
			ChessBoard board = new ChessBoard();
			
			Assert.AreEqual(ManType.Pawn, board.GetManOnPosition(BoardPosition.ParsePositionString("a2")).ManType);
			Assert.IsFalse(board.IsManOnPosition(BoardPosition.ParsePositionString("a4")));
			
			board.PerformMove(new Move(Player.White, null, BoardPosition.ParsePositionString("a2"), BoardPosition.ParsePositionString("a4")));

			Assert.AreEqual(ManType.Pawn, board.GetManOnPosition(BoardPosition.ParsePositionString("a4")).ManType);
			Assert.IsFalse(board.IsManOnPosition(BoardPosition.ParsePositionString("a2")));
		}
	}
}