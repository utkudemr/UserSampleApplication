
using FluentValidation.Results;
using UserSample.Domain.Service.Validation.FluentValidation;

namespace UserSample.Domain.Service.Helpers
{
    public static class ErrorMessageHelper
    {
        public static string ErrorMessage(this ValidationResult validation)
        {
            var errorMessages = string.Join(',', validation.Errors);
            return errorMessages;
        }
    }
}
