using FluentValidation.Results;
using System.Text;

namespace FamilyGallery.Application.Extensions
{
    public static class ConvertValidationErrorsToString
    {
        public static string Convert(this ValidationResult validationResult)
        {
            var stringBuilder = new StringBuilder();
            validationResult.Errors.ForEach(e => stringBuilder.Append(e.ErrorMessage));
            return stringBuilder.ToString();
        }
    }
}
