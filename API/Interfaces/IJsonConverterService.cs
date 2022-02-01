namespace API.Interfaces
{
    public interface IJsonConverterService
    {
         public void GetStringFromJson(string folder, IFormFile file);
    }
}