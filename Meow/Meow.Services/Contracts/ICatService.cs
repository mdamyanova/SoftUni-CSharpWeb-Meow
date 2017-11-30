namespace Meow.Services.Contracts
{
    using Admin.Models;
    using System.Collections.Generic;

    public interface ICatService
    {
        IEnumerable<CatServiceModel> All();
    }
}