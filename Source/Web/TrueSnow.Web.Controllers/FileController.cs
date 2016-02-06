using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TrueSnow.Data.Services.Contracts;

namespace TrueSnow.Web.Views
{
    public class FileController : Controller
    {
        private IFilesService files;

        public FileController(IFilesService files)
        {
            this.files = files;
        }

        // GET: File
        public ActionResult Index(int id)
        {
            var fileToRetrieve = this.files.GetById(id);
            return File(fileToRetrieve.Content, fileToRetrieve.ContentType);
        }
    }
}