namespace Kolokwium1.Exceptions;

public class NoFirefighterExeption : Exception
{
    public NoFirefighterExeption ()
    {}

    public NoFirefighterExeption (string message) 
        : base(message)
    {}

    public NoFirefighterExeption (string message, Exception innerException)
        : base (message, innerException)
    {} 
}