using BookShop.Domain.ValueObjects;

namespace BookShop.Domain.Client;

public class ClientBuilder
{
    private string _name;
    private string _surname;
    private BirthDate _BirthDate;
    private Address _address;
    private Email _Email;
    
    //With Methods
    public ClientBuilder WithName(string? name)
    {
        _name = name;
        return this;
    }

    public ClientBuilder WithSurname(string? surname)
    {
        _surname = surname;
        return this;
    }

    public ClientBuilder WithBirthDate(int year, int month, int day)
    {
        _BirthDate = new BirthDate(new DateTime(year, month, day));
        return this;
    }

    public ClientBuilder WithEmail(Email email)
    {
        _Email = email;
        return this;
    }
    
    public ClientBuilder WithEmail(string email)
    {
        _Email = new Email(email);
        return this;
    }

    public ClientBuilder WithAddress(Address address)
    {
        _address = address;
        return this;
    }

    public Client Build()
    {
        return new Client(_name, _surname, _BirthDate, _address, _Email);
    }
}