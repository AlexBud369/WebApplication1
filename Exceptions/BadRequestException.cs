namespace WebApplication1.Exceptions;

public abstract class BadRequestException : Exception
{
    protected BadRequestException(string message) : base(message) { }
}

public sealed class InvalidRequestException : BadRequestException
{
    public InvalidRequestException(string message) : base(message) { }
}