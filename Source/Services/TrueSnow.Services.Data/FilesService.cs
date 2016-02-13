namespace TrueSnow.Services.Data
{
    using System.Linq;

    using Contracts;
    using TrueSnow.Data.Common;
    using TrueSnow.Data.Models;

    public class FilesService : IFilesService
    {
        private readonly IDbRepository<File> files;

        public FilesService(IDbRepository<File> files)
        {
            this.files = files;
        }

        public IQueryable<File> GetAll()
        {
            return this.files
                .All()
                .OrderBy(f => f.CreatedOn);
        }

        public File GetById(int id)
        {
            return this.files.GetById(id);
        }

        public void Add(File fileToAdd)
        {
            this.files.Add(fileToAdd);
            this.files.Save();
        }

        public File GetDeafult()
        {
            return this.files
                .All()
                .FirstOrDefault(f => f.FileName == "default-avatar.png");
        }
    }
}
