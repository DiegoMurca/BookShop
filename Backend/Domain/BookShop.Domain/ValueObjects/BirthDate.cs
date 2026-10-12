namespace BookShop.Domain.ValueObjects;

public sealed record BirthDate
{
    public DateTime DateValue { get; }
    public int Age => AgeCalculate(DateValue);
    public BirthDate(DateTime dateValue)
    {
        
        if (dateValue.Date > DateTime.Today) throw new ArgumentException("Birthdate cannot be future", nameof(dateValue));
        if (dateValue.Year < dateValue.Year - 150) throw new ArgumentException("Invalid birthdate", nameof(dateValue));

        DateValue = dateValue.Date;
    }

    private static int AgeCalculate(DateTime birthDate)
    {
        var today = DateTime.Today;
        var age = today.Year - birthDate.Year;
        if (birthDate.Date > today.AddYears(-age)) age--;
        return age;
    }
}