namespace Organizer.Domain.Validation;

public class DomainValidationException : Exception
{
    public DomainValidationException(string error) : base(error)
    {
    }

    public static void When(bool hasErro, string error)
    {
        if (hasErro)
            throw new DomainValidationException(error);
    }
}