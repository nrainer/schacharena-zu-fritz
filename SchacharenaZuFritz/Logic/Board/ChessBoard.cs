using System;
using System.Text;

using SchacharenaZuFritz.Logic.Exceptions;
using SchacharenaZuFritz.Logic.Moves;

namespace SchacharenaZuFritz.Logic.Board
{
	public class ChessBoard
	{
		private readonly Man[,] fieldAssignment;
		
		public ChessBoard()
		{
			this.fieldAssignment = new Man[8, 8];
			SetInitialFieldAssignment();
		}
		
		private void SetInitialFieldAssignment()
		{
			SetNonPawnMan(Player.White);
			SetPawnMan(Player.White);
			
			SetNonPawnMan(Player.Black);
			SetPawnMan(Player.Black);
		}
		
		private void SetNonPawnMan(Player player)
		{
			int y = player == Player.White ? 0 : 7;
			
			fieldAssignment[0, y] = new Man(player, ManType.Rook);
			fieldAssignment[1, y] = new Man(player, ManType.Knight);
			fieldAssignment[2, y] = new Man(player, ManType.Bishop);
			fieldAssignment[3, y] = new Man(player, ManType.Queen);
			fieldAssignment[4, y] = new Man(player, ManType.King);
			fieldAssignment[5, y] = new Man(player, ManType.Bishop);
			fieldAssignment[6, y] = new Man(player, ManType.Knight);
			fieldAssignment[7, y] = new Man(player, ManType.Rook);
		}
		
		private void SetPawnMan(Player player)
		{
			int y = player == Player.White ? 1 : 6;
			
			for (int i = 0; i < 8; i++)
			{
				fieldAssignment[i, y] = new Man(player, ManType.Pawn);
			}
		}
		
		public Man GetManOnPosition(BoardPosition position)
		{
			return fieldAssignment[position.X, position.Y];
		}
		
		public bool IsManOnPosition(BoardPosition position)
		{
			return GetManOnPosition(position) != null;
		}
		
		private void MoveManToNewPosition(BoardPosition oldPosition, BoardPosition newPosition)
		{
			Man manToMove = GetManOnPosition(oldPosition);
			
			if (manToMove == null)
			{
				throw new ConverterException("Man to move is not on position: oldPosition = " + oldPosition);
			}
			
			SetManOnPosition(oldPosition, null);
			SetManOnPosition(newPosition, manToMove);
		}
		
		private void SetManOnPosition(BoardPosition position, Man man)
		{
			fieldAssignment[position.X, position.Y] = man;
		}
		
		public void PerformMove(Castling move)
		{
			int y = move.Player == Player.White ? 0 : 7;
			
			BoardPosition kingPosition = new BoardPosition(4, y);
			Man king = GetManOnPosition(kingPosition);
			
			int rookX = move.LongCastling ? 0 : 7;
			BoardPosition rookPosition = new BoardPosition(rookX, y);
			Man rook = GetManOnPosition(rookPosition);
			
			if (king == null || rook == null)
			{
				throw new ConverterException("Man to perform castling is not on position: move = " + move);
			}
			
			SetManOnPosition(kingPosition, null);
			SetManOnPosition(rookPosition, null);
			
			if (move.LongCastling)
			{
				SetManOnPosition(new BoardPosition(2, y), king);
				SetManOnPosition(new BoardPosition(3, y), rook);
			}
			else
			{
				SetManOnPosition(new BoardPosition(6, y), king);
				SetManOnPosition(new BoardPosition(5, y), rook);
			}
		}
		
		public void PerformMove(Move move)
		{
			MoveManToNewPosition(move.OldPosition, move.NewPosition);
			
			if (move.TransformedMan != null)
			{
				SetManOnPosition(move.NewPosition, move.TransformedMan);
			}
		}
		
		public override string ToString()
		{
			StringBuilder outputBuilder = new StringBuilder();
			
			for (int y = 0; y < 8; y++)
			{
				for (int x = 7; x >= 0; x--)
				{
					Man man = fieldAssignment[x, y];
					
					outputBuilder.Append(" ");
					
					if (man == null)
					{
						outputBuilder.Append("0");
					}
					else if (man.Player == Player.White)
					{
						outputBuilder.Append("1");
					}
					else
					{
						outputBuilder.Append("2");
					}
					
					outputBuilder.Append(" ");
				}
				
				outputBuilder.AppendLine();
			}
			
			return outputBuilder.ToString();
		}
	}
}
