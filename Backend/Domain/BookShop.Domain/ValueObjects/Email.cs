namespace BookShop.Domain.ValueObjects;

public sealed record Email
{
    public string EmailValue { get; }

    public Email(string? emailValue)
    {
        EmailValue = EmailValidation(emailValue);
    }
    
    private static string EmailValidation(string? value)
    {
        if (string.IsNullOrWhiteSpace(value))
        {
            throw new ArgumentNullException(nameof(value), "email cannot be null or empty");
        }
        if (value.Any(char.IsWhiteSpace))
        {
            throw new ArgumentException($"email cannot contain white spaces: ", nameof(value));
        }

        value = value.ToLowerInvariant();
        try
        {
            var addr = new System.Net.Mail.MailAddress(value);
            if (!string.Equals(addr.Address, value, StringComparison.Ordinal))
            {
                throw new ArgumentException($"email is invalid", nameof(value));
            }
        }
        catch (FormatException ex)
        {
            throw new ArgumentException($"email is invalid: {value}", nameof(value), ex);
        }
        return value;
    }

    public override string ToString() => EmailValue;

}