namespace Generics;

public class DivideByZeroException : Exception
{
    public DivideByZeroException() : base("Can't divide by zero")
    {
    }
}