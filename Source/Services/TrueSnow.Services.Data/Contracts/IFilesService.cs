namespace TrueSnow.Services.Data.Contracts
{
    using System.Linq;

    using TrueSnow.Data.Models;

    public interface IFilesService
    {
        IQueryable<File> GetAll();

        void Add(File fileToAdd);

        File GetById(int id);
    }
}
