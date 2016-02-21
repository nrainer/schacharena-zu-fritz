using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

using SchacharenaZuFritz.Logic.Board;
using SchacharenaZuFritz.Logic.Converter;
using SchacharenaZuFritz.Logic.Exceptions;
using SchacharenaZuFritz.Logic.Game;
using SchacharenaZuFritz.Logic.Moves;

namespace SchacharenaZuFritz.Logic.Converter.Schacharena
{
	public abstract class AbstractSchacharenaParser : IChessParser
	{
		private const string PATTERN_MOVE = "([a-h][1-8])[-x]([a-h][1-8])";
		private const string PATTERN_MAN_TRANSFORMATION = "\\s([SLTD])";
		private const string PATTERN_SHORT_CASTLING = "0-0";
		private const string PATTERN_LONG_CASTLING = "0-0-0";
		private const string PATTERN_ANY_CASTLING = "0-0(-0)?";
		
		private string rawInput;
		private ChessGame game;
		private ChessBoard board;
		private bool noMoreMovesAllowed;
		
		public void Initialize(string input)
		{
			this.rawInput = input;
			this.game = new ChessGame();
			this.board = new ChessBoard();
		}
		
		public ChessGame ParseChessGame()
		{
			ParseHeader();
			ParseBody();
			
			return this.game;
		}

		protected void ParseHeader()
		{
			ParsePlayerNamesInHeader();
			ParseDateInHeader();
		}

		protected void ParseDateInHeader()
		{
			Match matcher = Regex.Match(this.rawInput, "Partiebeginn:\\s*(\\d\\d)\\.(\\d\\d)\\.(\\d\\d) \\d\\d:\\d\\d Uhr");
			
			if (matcher.Success)
			{
				this.game.DateText = "20" + matcher.Groups[3].Value + "." + matcher.Groups[2].Value + "." + matcher.Groups[1].Value;
			}
		}

		protected void ParsePlayerNamesInHeader()
		{
			Match matcher = Regex.Match(this.rawInput, "(\\w*) \\[\\d+\\]\\s*(\\w*) \\[\\d+\\]");
			
			if (matcher.Success)
			{
				this.game.PlayerName1 = matcher.Groups[1].Value;
				this.game.PlayerName2 = matcher.Groups[2].Value;
			}
		}
		
		protected void ParseBody()
		{
			this.noMoreMovesAllowed = false;
			string[] lines = SplitIntoGameContentRows();

			int lineCount = 1;
			foreach (string currentLine in lines)
			{
				if (IsRowWithMoves(currentLine))
				{
					ParseLine(currentLine, lineCount);
					lineCount++;
				}
			}
		}
		
		protected bool IsRowWithMoves(string currentLine)
		{
			return currentLine.Trim().Length > 0;
		}
		
		protected string[] SplitIntoGameContentRows()
		{
			string gameContent = getCleanedGameContent();
			return Regex.Split(gameContent, "\\d+\\.");
		}
		
		protected string getCleanedGameContent()
		{
			int gameContentBeginIndex = findGameContentBeginIndex();
			
			if (gameContentBeginIndex == -1)
			{
				throw new ConverterException("Begin of game content not found.");
			}
			
			string gameContent = this.rawInput.Substring(gameContentBeginIndex);
			gameContent = gameContent.Replace(" - ", "-");
			gameContent = gameContent.Replace(" x ", "x");
			return gameContent;
		}
		
		protected int findGameContentBeginIndex()
		{
			return this.rawInput.IndexOf("\n1.");
		}
		
		protected void ParseLine(string line, int lineCount)
		{
			if (line.Length == 0)
			{
				return;
			}
			
			try
			{
				string[] moves = ExtractMoves(line);
				string moveWhite = moves[0];
				string moveBlack = moves[1];
				
				ParseMove(Player.White, moveWhite);
				
				if (moveBlack != null)
				{
					ParseMove(Player.Black, moveBlack);
				}
				else
				{
					noMoreMovesAllowed = true;
				}
			}
			catch (ConverterException ex)
			{
				throw new ConverterException("In line " + lineCount + ": '" + line + "' because of: " + ex.Message);
			}
		}
		
		protected string[] ExtractMoves(string line)
		{
			Match match = Regex.Match(line, "(" + PATTERN_ANY_CASTLING + "[+]?)|(" + PATTERN_MOVE + "[+]?(" + PATTERN_MAN_TRANSFORMATION + ")?)");
			
			if (!match.Success)
			{
				throw new ConverterException("Move extraction failed.");
			}
			
			string[] result = new String[2];
			result[0] = match.Value;

			match = match.NextMatch();
			
			if (match.Success)
			{
				result[1] = match.Value;
			}
			
			return result;
		}
		
		protected void ParseMove(Player player, string move)
		{
			if (this.noMoreMovesAllowed)
			{
				throw new ConverterException("No more moves are expected.");
			}
			
			if (IsLongCastling(move))
			{
				handleCastling(player, true);
			}
			else if (IsShortCastling(move))
			{
				handleCastling(player, false);
			}
			else
			{
				handleNonCastlingMove(player, move);
			}
		}

		protected void handleCastling(Player player, bool longCastling)
		{
			Castling castling = new Castling(player, longCastling);
			this.game.AddMove(castling);
			this.board.PerformMove(castling);
		}
		
		protected bool IsLongCastling(string move)
		{
			return move.Contains(PATTERN_LONG_CASTLING);
		}
		
		protected bool IsShortCastling(string move)
		{
			return move.Contains(PATTERN_SHORT_CASTLING);
		}
		
		protected void handleNonCastlingMove(Player player, string moveString)
		{
			BoardPosition fromPosition = ParsePosition(moveString, 0);
			BoardPosition toPosition = ParsePosition(moveString, 1);
			
			Man man = this.board.GetManOnPosition(fromPosition);
			
			bool isCapture = this.board.IsManOnPosition(toPosition);
			Man transformedMan = ParseManTransformation(player, moveString);
			
			Move move = new Move(player, man, fromPosition, toPosition, isCapture, transformedMan);
			this.game.AddMove(move);
			this.board.PerformMove(move);
		}
		
		protected BoardPosition ParsePosition(string moveString, int positionIndex)
		{
			Match match = Regex.Match(moveString, PATTERN_MOVE);
			string positionString = match.Groups[1 + positionIndex].Value;
			return BoardPosition.ParsePositionString(positionString);
		}
		
		protected Man ParseManTransformation(Player player, string moveString)
		{
			Match match = Regex.Match(moveString, PATTERN_MAN_TRANSFORMATION);
			
			if (match.Success)
			{
				ManType manType = ManTypeUtility.ManFromGermanChar(match.Groups[1].Value);
				return new Man(player, manType);
			}
			
			return null;
		}
	}
}
