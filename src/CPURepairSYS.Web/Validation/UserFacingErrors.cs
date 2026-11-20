using CPURepairSYS.Application.Common;

namespace CPURepairSYS.Web.Validation;

internal static class UserFacingErrors
{
    public static IReadOnlyList<ValidationError> From(Exception exception, string field = "request")
    {
        var message = exception.ToString();
        var userMessage = message switch
        {
            var value when value.Contains("ORA-00001", StringComparison.OrdinalIgnoreCase) =>
                "A record with one of these unique values already exists.",
            var value when value.Contains("ORA-01400", StringComparison.OrdinalIgnoreCase) =>
                "A required value was not provided.",
            var value when value.Contains("ORA-12899", StringComparison.OrdinalIgnoreCase) =>
                "One of the values is longer than the database allows.",
            var value when value.Contains("ORA-00942", StringComparison.OrdinalIgnoreCase) =>
                "The database objects are not available to the configured account.",
            _ => "The request could not be completed. Check the values and try again."
        };

        return new[] { new ValidationError(field, userMessage) };
    }
}
