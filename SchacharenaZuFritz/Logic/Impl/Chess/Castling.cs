using System;
using SchacharenaZuFritz.Logic.Abstract.Chess;

namespace SchacharenaZuFritz.Logic.Impl.Chess
{
    class Castling : IMove
    {
        public readonly bool shortC;

        public Castling(bool shortC)
        {
            this.shortC = shortC;
        }

        public override string ToString()
        {
            return "0-0" + (shortC ? "" : "-0");
        }
    }
}
