namespace TrueSnow.Data.Services.Contracts
{
    using TrueSnow.Data.Models;

    public interface IUsersService
    {
        User GetById(string id);
    }
}
