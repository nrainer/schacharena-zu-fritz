using System;

using SchacharenaZuFritz.Logic.Exceptions;

namespace SchacharenaZuFritz.Logic.Board
{
    public enum ManType
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
    
    public static class ManTypeUtility
    {    	
        public static string ManToEnglishChar(ManType manType)
        {
            switch (manType)
            {
                case ManType.Pawn:
                    return "";
                case ManType.Knight:
                    return "N";
                case ManType.Bishop:
                    return "B";
                case ManType.Rook:
                    return "R";
                case ManType.Queen:
                    return "Q";
                case ManType.King:
                    return "K";
                default:
                    throw new ConverterException("Unknown man type: " + manType);
            }
        }
        
        public static ManType ManFromGermanChar(String manChar)
        {
            switch (manChar)
            {
            	case "S":
            		return ManType.Knight;
            	case "L":
            		return ManType.Bishop;
            	case "T":
            		return ManType.Rook;
            	case "D":
            		return ManType.Queen;
                default:
                    throw new ConverterException("Unknown man char: " + manChar);
            }
        }
    }
}
