using BookShop.Domain.Client;
using BookShop.Domain.ValueObjects;

namespace BookShop.Domain.UnitTests.ClientTests;

public class ClientBuilderTests
{
    private Address _address = new Address("12312.123", "Av. Paulista", "1578", null, "Bela Vista", "São Paulo", "SP", "BR");
    
    public static TheoryData<string> InvalidName => new()
    {
        new string('a', 51),
        "ab",
        "",
        " "
    };
    
    [Theory]
    [MemberData(nameof(InvalidName))]
    public void ClientBuilder_WithName_shouldThrowArgumentException(string name)
    {
        //Arrange
        var builder = new ClientBuilder().WithName(name).WithSurname("johnathan").WithEmail("valid@email.com").WithAddress(_address).WithBirthDate(2002,8,12);
        //Act & Assert
        Assert.Throws<ArgumentException>(() => builder.Build());
    }
    
    [Fact]
    public void ClientBuilder_WithName_shouldThrowArgumentNullException()
    {
        //Arrange
        var builder = new ClientBuilder().WithName(null).WithSurname("johnathan").WithEmail("valid@email.com").WithAddress(_address).WithBirthDate(2002,8,12);
        //Act & Assert
        Assert.Throws<ArgumentNullException>(() => builder.Build());
    }
    
    [Theory]
    [MemberData(nameof(InvalidName))]
    public void ClientBuilder_WithSurname_shouldThrowArgumentException(string surname)
    {
        //Arrange
        var builder = new ClientBuilder().WithName("john").WithSurname(surname).WithEmail("valid@email.com").WithAddress(_address).WithBirthDate(2002,8,12);
        //Act & Assert
        Assert.Throws<ArgumentException>(() => builder.Build());
    }
    
    [Fact]
    public void ClientBuilder_WithSurname_shouldThrowArgumentNullException()
    {
        //Arrange
        var builder = new ClientBuilder().WithName("john").WithSurname(null).WithEmail("valid@email.com").WithAddress(_address).WithBirthDate(2002,8,12);
        //Act & Assert
        Assert.Throws<ArgumentNullException>(() => builder.Build());
    }

    [Fact]
    public void CliendBuilder_ShouldBeValid()
    {
        //Arrange
        var before = DateTime.UtcNow;
        
        var builder = new ClientBuilder().WithName("jOhn").WithSurname("johNson").WithEmail("valid@email.com").WithAddress(_address).WithBirthDate(2002,8,12).Build();

        var after = DateTime.UtcNow;
        
        //Act & Assert
        Assert.Equal("john",builder.Name );
        Assert.Equal("johnson",builder.Surname );
        Assert.Equal("john johnson",builder.FullName );
        Assert.Equal("valid@email.com", builder.Email.EmailValue );
        Assert.Equal(_address.ToString() ,builder.Address.ToString());
        Assert.Equal( new DateTime(2002,8,12), builder.BirthDate.DateValue);
        Assert.InRange(builder.CreatedAT, before, after);
    }
}