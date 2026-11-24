using CPURepairSYS.Application.Common;

namespace CPURepairSYS.Web.Validation;

internal static class UserFacingErrors
{
    public static IReadOnlyList<ValidationError> From(Exception exception, string field = "request")
    {
        var message = exception.ToString();
        var userMessage = message switch
        {
            var value when value.Contains("ConnectionStrings:Oracle", StringComparison.OrdinalIgnoreCase) ||
                           value.Contains("Oracle connection string", StringComparison.OrdinalIgnoreCase) =>
                "The operation is unavailable because Oracle database credentials are not configured. Configure ConnectionStrings:Oracle and restart the application.",
            var value when value.Contains("ORA-00001", StringComparison.OrdinalIgnoreCase) =>
                "The operation could not be completed because a unique value already exists.",
            var value when value.Contains("ORA-01400", StringComparison.OrdinalIgnoreCase) =>
                "The operation could not be completed because a required database value is missing.",
            var value when value.Contains("ORA-12899", StringComparison.OrdinalIgnoreCase) =>
                "The operation could not be completed because one or more values exceed the database field limits.",
            var value when value.Contains("ORA-00904", StringComparison.OrdinalIgnoreCase) =>
                exception.ToString(),
            var value when value.Contains("ORA-00942", StringComparison.OrdinalIgnoreCase) =>
                "The operation could not access a required Oracle table or sequence. Ask the database administrator to verify the database objects and account permissions.",
            var value when value.Contains("ORA-00955", StringComparison.OrdinalIgnoreCase) =>
                "The operation could not be completed because a database object with the required name already exists.",
            var value when value.Contains("ORA-02289", StringComparison.OrdinalIgnoreCase) =>
                "The operation could not be completed because a required Oracle sequence does not exist or is not accessible.",
            var value when value.Contains("ORA-02291", StringComparison.OrdinalIgnoreCase) =>
                exception.ToString(),
            var value when value.Contains("ORA-02292", StringComparison.OrdinalIgnoreCase) =>
                "The operation could not be completed because the record is referenced by another database record.",
            var value when value.Contains("ORA-01017", StringComparison.OrdinalIgnoreCase) =>
                "The operation could not connect to Oracle because the configured username or password is invalid.",
            var value when value.Contains("ORA-28000", StringComparison.OrdinalIgnoreCase) =>
                "The operation could not connect because the configured Oracle account is locked.",
            var value when value.Contains("ORA-12154", StringComparison.OrdinalIgnoreCase) ||
                           value.Contains("ORA-12514", StringComparison.OrdinalIgnoreCase) ||
                           value.Contains("ORA-12541", StringComparison.OrdinalIgnoreCase) ||
                           value.Contains("ORA-12560", StringComparison.OrdinalIgnoreCase) =>
                "The operation could not connect to the configured Oracle service. Check the host, service name, and network connection.",
            _ => exception.ToString()
        };

        return new[] { new ValidationError(field, userMessage) };
    }
}
