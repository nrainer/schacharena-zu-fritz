namespace SchacharenaZuFritz.Logic.Abstract
{
    public interface IConverter
    {
        string Convert(string input);

        string FromType { get; }

        string ToType { get; }
    }
}
