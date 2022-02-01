namespace API.Interfaces
{
    public interface IDirectoryService
    {
        Directory GetDirectoryStructure (string pathToDirectory);
    }
}