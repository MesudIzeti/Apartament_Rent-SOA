namespace EasyRent.Application.Common.Exceptions;

/// <summary>
/// Thrown when a business rule is violated (e.g. overlapping booking dates,
/// paying an unapproved booking, editing someone else's apartment).
/// The API's exception middleware maps this to HTTP 400 Bad Request.
/// </summary>
public class BusinessRuleException : Exception
{
    public BusinessRuleException(string message) : base(message) { }
}
