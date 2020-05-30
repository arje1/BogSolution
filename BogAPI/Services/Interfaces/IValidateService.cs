namespace BogAPI.Services.Interfaces
{
    public interface IValidateService
    {
        IValidateService ValidateCreation();
        IValidateService ValidateUpdate();
        IValidateService ValidateDelete(int id);
    }
}
