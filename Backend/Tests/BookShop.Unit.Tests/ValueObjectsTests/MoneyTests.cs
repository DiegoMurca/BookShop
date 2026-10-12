using BookShop.Domain.ValueObjects;

namespace BookShop.Domain.UnitTests.ValueObjectsTests;

public class MoneyTests
{
    [Theory]
    [InlineData(-10)]
    [InlineData(-170.50)]
    public void Money_withNegativeValue_Should_ThrowArgumentException(decimal invalidAmount)
    {
        //Act & Assert
        Assert.Throws<ArgumentException>(() => new Money(invalidAmount));
    }

    [Theory]
    [InlineData(10)]
    [InlineData(200.40)]
    public void Money_Should_Be_valid(decimal validValue)
    {
        //Arrange
        var money = new Money(validValue);
        
        //Act & Assert
        Assert.Equal(validValue, money.Amount);
    }
}