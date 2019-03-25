namespace Insurance.Domain.Interfaces.Validation
{
    public interface IValidation
    {
        string GetErrorMessage();
        bool Valid();
    }
}