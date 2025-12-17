namespace Emdep.Geos.Core.Exceptions;

public class DomainException : Exception
{
    public string ErrorCode { get; }

    public DomainException(string message, string errorCode = "GENERIC_ERROR")
        : base(message)
    {
        ErrorCode = errorCode;
    }
}