namespace TrueSnow.Data.Services
{
    using Models;
    using Repositories;
    using TrueSnow.Data.Services.Contracts;

    public class UsersService : IUsersService
    {
        private IRepository<User> users;

        public UsersService(IRepository<User> users)
        {
            this.users = users;
        }

        public User GetById(string id)
        {
            return this.users.GetById(id);
        }
    }
}
