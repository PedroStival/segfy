using System.Collections.Generic;

namespace Insurance.Domain.Interfaces.Validation
{
    public interface IValidationRule
    {
        List<string> ErrorMessages { get; }
        bool Valid();
    }
}