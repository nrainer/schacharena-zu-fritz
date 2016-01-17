using System;
using System.Collections.Generic;
using System.Text;
using SchacharenaZuFritz.Logic.Abstract;
using SchacharenaZuFritz.Logic.Impl.Chess;
using SchacharenaZuFritz.Logic.Abstract.Chess;
using System.Text.RegularExpressions;

namespace SchacharenaZuFritz.Logic.Impl
{
	public class SchacharenaToFritz : IConverter
	{
		private readonly Dictionary<string, Move.Man> allMen;

		public SchacharenaToFritz()
		{
			allMen = new Dictionary<string, Move.Man>();
			allMen.Add("Bauer", Move.Man.Pawn);
			allMen.Add("Springer", Move.Man.Knight);
			allMen.Add("Läufer", Move.Man.Bishop);
			allMen.Add("Turm", Move.Man.Rook);
			allMen.Add("Dame", Move.Man.Queen);
			allMen.Add("König", Move.Man.King);
		}

		public string Convert(string input)
		{
			string[] inputRows = GetRows(input);

			string output;

			output = GetDefaultHeader(input);

			output += Environment.NewLine;
			output += Environment.NewLine;

			output += CreateBody(inputRows);

			return output;
		}

		private string GetDefaultHeader(string input)
		{
			string date = "????.??.??";
			string player1 = "Spieler 1";
			string player2 = "Spieler 2";


			Match m;
			
			m = Regex.Match(input, "(\\w*) \\[\\d+\\]\\s*(\\w*) \\[\\d+\\]");
			
			if (m.Success)
			{
				player1 = m.Groups[1].Value;
				player2 = m.Groups[2].Value;
			}

			m = Regex.Match(input, @"Start: (\d\d)\.(\d\d)\.(\d\d) - \d\d:\d\d Uhr");
			
			if (m.Success)
			{
				date = "20" + m.Groups[3].Value + "." + m.Groups[2].Value + "." + m.Groups[1].Value;
			}

			return
				@"[Event ""Partie""]
[Site ""www.schacharena.de""]
[Date """ + date + @"""]
[Round ""?""]
[White """ + player1 + @"""]
[Black """ + player2 + @"""]
[Result ""*""]";
		}

		private string CreateBody(string[] lines)
		{
			return FormatMoves(ParseMoves(lines));
		}

		private List<IMove> ParseMoves(string[] lines)
		{
			List<IMove> moves = new List<IMove>();

			int index = 0;
			foreach (string currentLine in lines)
			{
				parseLine(moves, currentLine, index == lines.Length - 1);
				index++;
			}

			return moves;
		}
		
		private void parseLine(List<IMove> moves, string line, bool isLastLine)
		{
			if (line.Length == 0)
			{
				return;
			}
			
			try
			{
				string[] tokens = line.Split('\t');
				
				string whiteMan = tokens[1];
				string whiteMove = tokens[2];
				
				moves.Add(handleLinePart(line, true, whiteMan, whiteMove));
				
				if (isLastLine && (tokens.Length == 3 || tokens[3] == ""))
				{
					// last line, no move for black
				}
				else
				{
					string blackMan = tokens[3];
					string blackMove = tokens[4];
					moves.Add(handleLinePart(line, false, blackMan, blackMove));
				}
			}
			catch (IllegalInputSequenceException ex)
			{
				throw ex;
			}
			catch (Exception)
			{
				throw new IllegalInputSequenceException("Parsing error.", line);
			}
		}

		private IMove handleLinePart(string line, bool white, string manString, string moveString)
		{
			if (moveString.Contains("0-0-0"))
			{
				return new Castling(false);
			}
			else if (moveString.Contains("0-0"))
			{
				return new Castling(true);
			}
			else
			{
				Move.Man man;
				Move.Man transformedMan;
				string from;
				string to;
				bool capture;


				if (allMen.ContainsKey(manString))
				{
					allMen.TryGetValue(manString, out man);
				}
				else
				{
					throw new IllegalInputSequenceException("Expected man but got: " + manString, line);
				}


				Match m = Regex.Match(moveString, "^([a-h][1-8])(-|x|ep)([a-h][1-8])([DTLS])?");

				if (m.Success)
				{
					from = m.Groups[1].Value;
					to = m.Groups[3].Value;
					capture = m.Groups[2].Value != "-";
					string transformation = m.Groups[4].Value;

					if (transformation != "")
					{
						transformedMan = Move.GermanCharToMan(transformation);
					}
					else
					{
						transformedMan = man;
					}
				}
				else
				{
					throw new IllegalInputSequenceException("Expected '-' or 'x' as separator but got: " + moveString, line);
				}

				return new Move(white, man, from, to, capture, transformedMan);
			}
		}

		private string FormatMoves(List<IMove> moves)
		{
			StringBuilder sB = new StringBuilder();

			for (int i = 0; i < moves.Count; i++)
			{
				if (i % 2 == 0)
				{
					sB.Append(((i / 2) + 1) + ". ");
				}

				sB.Append(moves[i].ToString());
				sB.Append(" ");
			}

			return sB.ToString();
		}

		private string[] GetRows(string text)
		{
			String cleanedText = text.Replace(" - ", "\t").Replace(" ", "\t");
			String pattern = @"\d+\.";
			return Regex.Split(cleanedText, pattern);
		}

		private string[] SplitRow(string line)
		{
			return line.Split(' ');
		}

		public string FromType
		{
			get
			{
				return "Schacharena";
			}
		}

		public string ToType
		{
			get
			{
				return "Fritz";
			}
		}
	}
}
