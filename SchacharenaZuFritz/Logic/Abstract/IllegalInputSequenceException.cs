using System;

namespace SchacharenaZuFritz.Logic.Abstract
{
    class IllegalInputSequenceException : Exception
    {
        public IllegalInputSequenceException(string message, string source) : base(message + " [VALUE = " + source + "]")
        {
        }
    }
}
