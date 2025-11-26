namespace WebApplication1.Exceptions;

public abstract class BadRequestException : Exception
{
    protected BadRequestException(string message) : base(message) { }
}

