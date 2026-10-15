using CPURepairSYS.Domain.ValueObjects;

namespace CPURepairSYS.Domain.Entities;

public sealed class Customer
{
    private Customer(CustomerId id, string firstName, string surname, PhoneNumber phone, string email)
    {
        Id = id;
        FirstName = ValidateText(firstName, nameof(firstName), 15);
        Surname = ValidateText(surname, nameof(surname), 15);
        Phone = phone;
        Email = ValidateText(email, nameof(email), 25);
    }

    public CustomerId Id { get; }
    public string FirstName { get; private set; }
    public string Surname { get; private set; }
    public PhoneNumber Phone { get; private set; }
    public string Email { get; private set; }

    public static Customer Create(CustomerId id, string firstName, string surname, PhoneNumber phone, string email) =>
        new(id, firstName.ToUpperInvariant(), surname.ToUpperInvariant(), phone, email);

    private static string ValidateText(string value, string parameterName, int maxLength)
    {
        var normalised = value?.Trim() ?? string.Empty;
        if (normalised.Length == 0 || normalised.Length > maxLength)
        {
            throw new ArgumentException($"{parameterName} is required and must be at most {maxLength} characters.", parameterName);
        }

        return normalised;
    }
}
