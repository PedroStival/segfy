using Insurance.Domain.Interfaces.Validation;

namespace Insurance.Domain.Validation
{
    public class ValidationCore : IValidation
    {
        private ValidationRule _validationsRules;
        private string _errorMessage;
        protected virtual void AddRule(ValidationRule validationRule)
        {
            _validationsRules = validationRule;
        }

        public string GetErrorMessage()
        {
            return _errorMessage;
        }

        public bool Valid()
        {
            var rule = _validationsRules;
            if (!rule.Valid())
            {
                _errorMessage = string.Join("<br />", rule.ErrorMessages);
                return false;
            }
                
            return true;
        }
    }
}
