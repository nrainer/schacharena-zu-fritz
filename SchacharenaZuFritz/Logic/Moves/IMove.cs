using SchacharenaZuFritz.Logic.Board;

namespace SchacharenaZuFritz.Logic.Moves
{
    public interface IMove
    {
    	string ToFritzString();
    	
    	Player Player {get;}
    }
}
