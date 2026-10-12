namespace BookShop.Domain.ValueObjects;

public sealed record Address
{
    public  string PostalCode { get;}
    public string Street { get; }
    public string Number { get; }
    public string? Complement { get; }
    public string? District { get; }
    public string City { get; }
    public string? State { get; }          
    public string CountryCode { get; }

    public Address(string postalCode, string street, string number, string? complement, string? district, string city,
        string? state, string countryCode)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(postalCode);
        ArgumentException.ThrowIfNullOrWhiteSpace(street);
        ArgumentException.ThrowIfNullOrWhiteSpace(number);
        ArgumentException.ThrowIfNullOrWhiteSpace(city);
        ArgumentException.ThrowIfNullOrWhiteSpace(countryCode);

        if (countryCode.Trim().Length != 2)
        {
            throw new ArgumentException("CountryCode must be ISO 3166-1 alpha-2.", nameof(countryCode));
        }

        PostalCode = postalCode.Trim();
        Street = street.Trim();
        Number = number.Trim();
        Complement = complement?.Trim();
        District = district?.Trim();
        City = city.Trim();
        State = state?.Trim();
        CountryCode = countryCode.Trim().ToUpperInvariant();
    }
}