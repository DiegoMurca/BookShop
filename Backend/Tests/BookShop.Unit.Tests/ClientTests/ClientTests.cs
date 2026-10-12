using BookShop.Domain.Client;
using BookShop.Domain.ValueObjects;

namespace BookShop.Domain.UnitTests.ClientTests;

public class ClientTests
{
    private Address _address = new Address("12312.123", "Av. Paulista", "1578", null, "Bela Vista", "São Paulo", "SP", "BR");
    private Address _newAddress = new Address("12312.123", "AV. principal", "1578", null, "Bela Vista", "florianopolis", "SP", "BR");
    [Fact]
    public void Client_ChangeMethods_shouldChangeValues()
    {
        //Arrange
        var before = DateTime.UtcNow;
        var client = new ClientBuilder().WithName("john").WithSurname("johnson").WithEmail("valid@email.com").WithAddress(_address).WithBirthDate(2002,8,12).Build();
        var after = DateTime.UtcNow;
        //Act
        client.ChangeName("mIke");
        client.ChangeSurname("thOmpson");
        client.ChangeEmail("newvalid@email.com");
        client.ChangeAddress(_newAddress);
        client.ChangeBirthDate(2003,12,3);
        //Assert
        Assert.Equal("mike", client.Name);
        Assert.Equal("thompson", client.Surname);
        Assert.Equal("mike thompson", client.FullName);
        Assert.Equal("newvalid@email.com", client.Email.EmailValue);
        Assert.Equal(_newAddress.ToString(), client.Address.ToString());
        Assert.Equal(2003, client.BirthDate.DateValue.Year);
        Assert.Equal(12, client.BirthDate.DateValue.Month);
        Assert.Equal(3, client.BirthDate.DateValue.Day);
        Assert.Equal(22, client.BirthDate.Age);
        Assert.InRange(client.CreatedAT, before, after);
    }
}