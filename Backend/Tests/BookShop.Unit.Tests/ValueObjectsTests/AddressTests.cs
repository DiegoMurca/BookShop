using BookShop.Domain.ValueObjects;

namespace BookShop.Domain.UnitTests.ValueObjectsTests;

public class AddressTests
{
    public static IEnumerable<object[]> InvalidAddressCases()
    {
        // postalCode, street, number, complement, district, city, state, countryCode
        yield return new object[] { "", "Av. Paulista", "1578", null, "Bela Vista", "São Paulo", "SP", "BR" };
        yield return new object[] { "01310-100",  "", "1578", null, "Bela Vista", "São Paulo", "SP", "BR" };
        yield return new object[] { "01310-100",  "Av. Paulista", "", null, "Bela Vista", "São Paulo", "SP", "BR" };
        yield return new object[] { "01310-100",  "Av. Paulista", "1578", null, "Bela Vista", "","SP", "BR" };
        yield return new object[] { "01310-100",  "Av. Paulista", "1578", null, "Bela Vista", "São Paulo", "SP", ""  };
    }
    
    [Theory]
    [MemberData(nameof(InvalidAddressCases))]
    public void Address_Should_ThrowArgumentException(string postalCode, string street, string number, string? complement, string? district, string city, string? state, string countryCode)
    {
        Assert.Throws<ArgumentException>(() =>
            new Address(postalCode, street, number, complement, district, city, state, countryCode));
    }
}