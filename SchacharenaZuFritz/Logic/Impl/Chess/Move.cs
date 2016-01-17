using System;
using SchacharenaZuFritz.Logic.Abstract;
using SchacharenaZuFritz.Logic.Abstract.Chess;

namespace SchacharenaZuFritz.Logic.Impl.Chess
{
    struct Move : IMove
    {
        public readonly bool white;
        public readonly Man UsedMan;
        public readonly Position OldPosition;
        public readonly Position Destination;
        public readonly bool Capture;
        public Man TransformedMan;

        public Move(bool white, Man usedMan, string oldPosition, string destination, bool capture, Man transformedMan)
        {
            this.white = white;
            this.UsedMan = usedMan;
            this.OldPosition = Position.ParsePosition(oldPosition);
            this.Destination = Position.ParsePosition(destination);
            this.Capture = capture;

            this.TransformedMan = transformedMan;
        }

        private static string ManToEnglishChar(Man man)
        {
            switch (man)
            {
                case Man.Pawn:
                    return "";
                case Man.Knight:
                    return "N";
                case Man.Bishop:
                    return "B";
                case Man.Rook:
                    return "R";
                case Man.Queen:
                    return "Q";
                case Man.King:
                    return "K";
                default:
                    return "";
            }
        }

        public static Move.Man GermanCharToMan(string de)
        {
            switch (de)
            {
                case "D":
                    return Man.Queen;
                case "T":
                    return Man.Rook;
                case "L":
                    return Man.Bishop;
                case "S":
                    return Man.Knight;
                case "K":
                    return Man.King;
                default:
                    return Man.Pawn;
            }
        }

        public enum Man
        {
            /// <summary>
            /// König
            /// </summary>
            King,
            /// <summary>
            /// Dame
            /// </summary>
            Queen,
            /// <summary>
            /// Turm
            /// </summary>
            Rook,
            /// <summary>
            /// Läufer
            /// </summary>
            Bishop,
            /// <summary>
            /// Springer
            /// </summary>
            Knight,
            /// <summary>
            /// Bauer
            /// </summary>
            Pawn
        }

        public override string ToString()
        {
            return ManToEnglishChar(UsedMan) + OldPosition.ToString() + (Capture ? "x" : "") + Destination.ToString() + (TransformedMan != UsedMan ? ManToEnglishChar(TransformedMan) : "");
        }
    }

    struct Position
    {
        public readonly byte X;
        public readonly byte Y;

        public Position(byte x, byte y)
        {
            this.X = x;
            this.Y = y;
        }

        public static Position ParsePosition(string value)
        {
            try
            {
                return new Position((byte) (Char.ToUpper(value[0]) - 65), (byte) (value[1] - 48));
            }
            catch
            {
                throw new IllegalInputSequenceException("Position can not be parsed.", value);
            }
        }

        public override string ToString()
        {
            return ((char) (X + 97)).ToString() + Y;
        }
    }
}
