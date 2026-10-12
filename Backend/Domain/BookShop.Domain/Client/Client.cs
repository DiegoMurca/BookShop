using BookShop.Domain.ValueObjects;

namespace BookShop.Domain.Client;

public class Client
{
    //Fields
    public long Id { get; } 
    public string Name { get; private set; }
    public string Surname { get; private set; }
    public string FullName { get; private set; }
    public BirthDate BirthDate { get; private set; }
    public Money Balance { get; private set; } = new(0M);
    public Address Address { get; private set; }
    public Email Email { get; private set; }
    public DateTime CreatedAT { get; private set; }
    public int Age { get; private set; }
    
    //Constructors
    private Client(long id, string name, string surname, string fullName, int age, Money balance, Address address, Email email, DateTime createdAt) { }

    public Client(string name, string surname, BirthDate birthDate, Address address, Email email)
    {
        Name = ValidateNameAndSurname(name);
        Surname = ValidateNameAndSurname(surname);
        FullName = $"{Name} {Surname}";
        Address = address;
        Email = email;
        BirthDate = birthDate;
        CreatedAT = DateTime.UtcNow;
    }

    //Validation Methods
    private static string ValidateNameAndSurname(string? value)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(value);
        if (value.Trim().Length < 3 || value.Trim().Length > 50) throw new ArgumentException("value must be between 3 and 50 characters long", nameof(value));
        if (value.Contains(' ')) throw new ArgumentException("value cannot have space",nameof(value));
        if (value.Any(char.IsDigit)) throw new ArgumentException("invalid value", nameof(value));

        return value.Trim().ToLower();
    }

    //Change Methods
    public void ChangeName(string newName)
    { 
        Name = ValidateNameAndSurname(newName);
        FullName = $"{Name} { Surname}";
    }
    
    public void ChangeSurname(string newSurname)
    { 
        Surname = ValidateNameAndSurname(newSurname);
        FullName = $"{Name} {Surname}";
    }

    public void ChangeEmail(string newEmail)
    {
        Email = new Email(newEmail);
    }

    public void ChangeAddress(Address newAddress)
    {
        Address = newAddress ?? throw new ArgumentNullException(nameof(newAddress));
    }

    public void ChangeBalance(Money newBalance)
    {
        Balance = newBalance ?? throw new ArgumentNullException(nameof(newBalance));
    }

    public void ChangeBirthDate(int year, int month, int day)
    {
        var newBirthDate = new BirthDate(new DateTime(year,month,day));
        BirthDate = newBirthDate ?? throw new ArgumentNullException(nameof(newBirthDate));
        Age = BirthDate.Age;
    }
}