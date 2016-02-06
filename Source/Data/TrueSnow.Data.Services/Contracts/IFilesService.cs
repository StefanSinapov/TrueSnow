namespace TrueSnow.Data.Services.Contracts
{
    using System.Linq;
    using TrueSnow.Data.Models;

    public interface IFilesService : IService
    {
        IQueryable<File> GetAll();

        void Add(File fileToAdd);

        File GetById(int id);
    }
}
