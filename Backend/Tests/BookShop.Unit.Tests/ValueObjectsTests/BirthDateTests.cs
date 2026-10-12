using BookShop.Domain.ValueObjects;

namespace BookShop.Domain.UnitTests.ValueObjectsTests;

public class BirthDateTests
{
    [Fact]
    public void BirthDate_ShouldBeEquals()
    {
        //Arrange
        var birthDate = new BirthDate(new DateTime(2000, 8, 12));
        var otherBirthDate = new BirthDate(new DateTime(2002, 8, 12));
        
        //Act & Assert
        Assert.Equal(26,birthDate.Age);
        Assert.Equal(24,otherBirthDate.Age);
    }
}