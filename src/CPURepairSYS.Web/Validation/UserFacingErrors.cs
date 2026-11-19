using CPURepairSYS.Application.Common;

namespace CPURepairSYS.Web.Validation;

internal static class UserFacingErrors
{
    public static IReadOnlyList<ValidationError> From(Exception exception, string field = "request")
    {
        var message = exception.ToString();
        var userMessage = message switch
        {
            var value when value.Contains("ORA-00001", StringComparison.OrdinalIgnoreCase)
                && value.Contains("PHONE", StringComparison.OrdinalIgnoreCase) =>
                "This phone number is already registered. Use a different phone number.",
            var value when value.Contains("ORA-00001", StringComparison.OrdinalIgnoreCase)
                && value.Contains("EMAIL", StringComparison.OrdinalIgnoreCase) =>
                "This email address is already registered. Use a different email address.",
            var value when value.Contains("ORA-00001", StringComparison.OrdinalIgnoreCase) =>
                "A customer with this phone number or email address already exists. Check both values and try again.",
            var value when value.Contains("ORA-01400", StringComparison.OrdinalIgnoreCase) =>
                "A required value is missing. Complete all required fields and try again.",
            var value when value.Contains("ORA-12899", StringComparison.OrdinalIgnoreCase) =>
                "One of the entered values is too long. Shorten it and try again.",
            var value when value.Contains("ORA-01438", StringComparison.OrdinalIgnoreCase) =>
                "One of the entered numbers is outside the database limits. Enter a smaller value.",
            var value when value.Contains("ORA-02290", StringComparison.OrdinalIgnoreCase) =>
                "One of the entered values violates a database rule. Check the highlighted values and try again.",
            var value when value.Contains("ORA-00942", StringComparison.OrdinalIgnoreCase) =>
                "The application cannot access the required database tables. Contact support.",
            var value when value.Contains("ORA-02291", StringComparison.OrdinalIgnoreCase) =>
                "One of the selected records does not exist. Check the ID and try again.",
            var value when value.Contains("ORA-01722", StringComparison.OrdinalIgnoreCase) =>
                "One of the numeric values is invalid. Enter numbers only.",
            var value when value.Contains("ORA-12514", StringComparison.OrdinalIgnoreCase)
                || value.Contains("ORA-12154", StringComparison.OrdinalIgnoreCase)
                || value.Contains("ORA-12541", StringComparison.OrdinalIgnoreCase) =>
                "The database is currently unavailable. Check the connection and try again.",
            var value when value.Contains("ORA-50032", StringComparison.OrdinalIgnoreCase) =>
                "The database returned incomplete data. Contact support.",
            _ => "The database rejected the customer record. This was not a form validation error; check for conflicting data or contact support."
        };

        return new[]
        {
            new ValidationError(field, $"{userMessage}\n\nFull exception details:\n{exception}")
        };
    }
}
