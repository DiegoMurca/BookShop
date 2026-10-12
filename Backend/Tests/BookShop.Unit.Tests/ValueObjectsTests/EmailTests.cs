using BookShop.Domain.ValueObjects;

namespace BookShop.Domain.UnitTests.ValueObjectsTests;

public class EmailTests
{
    [Theory]
    [InlineData("user@example.com")]   
    [InlineData("first.last@example.co.uk")]   
    [InlineData("user+tag@example.com")]   
    public void Email_Should_be_Valid(string input)
    {
        //arrange
        var email = new Email(input);
        
        //Act & Assert
        Assert.Equal(input, email.EmailValue);
    }

    [Theory]
    [InlineData("test..address@example.com")]
    [InlineData("address@test..example.com")]
    [InlineData("user@")]
    [InlineData("@example.com")]
    public void Email_InvalidInput_ThrowsArgumentException(string input)
    {
        Assert.Throws<ArgumentException>(() => new Email(input));
    }
    
    [Theory]
    [InlineData("")]
    [InlineData(" ")]
    [InlineData(null)]
    public void Email_InvalidInput_ThrowsArgumentNullException(string? input)
    {
        Assert.Throws<ArgumentNullException>(() => new Email(input));
    }
}