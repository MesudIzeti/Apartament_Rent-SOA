namespace EasyRent.Application.Common.Exceptions;

/// <summary>
/// Thrown when a requested entity does not exist.
/// The API's exception middleware maps this to HTTP 404 Not Found.
/// </summary>
public class NotFoundException : Exception
{
    public NotFoundException(string message) : base(message) { }
}
