namespace TrueSnow.Services.Data.Contracts
{
    using System.Linq;

    using TrueSnow.Data.Models;

    public interface IFilesService
    {
        IQueryable<File> GetAll();

        File GetById(int id);

        void Add(File fileToAdd);
    }
}
