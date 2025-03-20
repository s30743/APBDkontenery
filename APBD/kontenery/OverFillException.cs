namespace kontenery;

public class OverFillException : Exception
{
    public OverFillException(string? message) : base(message)
    {
    }
}