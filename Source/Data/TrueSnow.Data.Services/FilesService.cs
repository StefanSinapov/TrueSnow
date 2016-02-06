namespace TrueSnow.Data.Services
{
    using Models;
    using Repositories;
    using System.Linq;
    using TrueSnow.Data.Services.Contracts;

    public class FilesService : IFilesService
    {
        private IRepository<File> files;

        public FilesService(IRepository<File> files)
        {
            this.files = files;
        }

        public IQueryable<File> GetAll()
        {
            return this.files.All();
        }

        public void Add(File fileToAdd)
        {
            this.files.Add(fileToAdd);
            this.files.SaveChanges();
        }

        public File GetById(int id)
        {
            return this.files.GetById(id);
        }
    }
}
