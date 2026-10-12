using System.Diagnostics.CodeAnalysis;

namespace BookShop.Domain.ValueObjects;

public record Money
{
    public decimal Amount { get; init; }

    public Money(decimal amount)
    {
        Amount = MoneyValidation(amount);
    }

    private decimal MoneyValidation(decimal amount)
    {
        if (amount < 0)
        {
            throw new ArgumentException("amount cant be negative", nameof(amount));
        }

        return amount;
    }
}