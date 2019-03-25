using System.Collections.Generic;
using Insurance.Domain.Interfaces.Validation;

namespace Insurance.Domain.Validation
{
    public class ValidationRule : IValidationRule
    {
        private readonly bool _valid;

        public ValidationRule(bool valid, List<string> errorMessage)
        {
            _valid = valid;
            ErrorMessages = errorMessage;
        }

        public List<string> ErrorMessages { get; private set; }
        public bool Valid()
        {
            return _valid;
        }
    }
}
