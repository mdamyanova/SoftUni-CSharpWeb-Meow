namespace Meow.Services.Admin.Contracts
{
    public interface ICatService
    {
        void Add(string name, string imageUrl, string description, string location, string ownerId);
    }
}