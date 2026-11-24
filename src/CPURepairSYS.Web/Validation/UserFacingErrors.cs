using CPURepairSYS.Application.Common;

namespace CPURepairSYS.Web.Validation;

internal static class UserFacingErrors
{
    public static IReadOnlyList<ValidationError> From(Exception exception, string field = "request")
    {
        var message = exception.ToString();

        return new[] { new ValidationError(field, message) };
    }
}
