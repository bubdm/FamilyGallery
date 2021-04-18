using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FamilyGallery.Application.Exceptions
{
    public class ValidationException : ApplicationException
    {
        public List<string> ValidationErrors { get; set; }
        public ValidationException(ValidationResult validationResult)
        {
            ValidationErrors = new List<string>();
            ValidationErrors.AddRange(validationResult.Errors.Select(e => e.ErrorMessage));                
        }
    }

}
