using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using Moriah.Framework.Exceptions;
using Moriah.Framework.Common;

namespace Moriah.Framework.Files
{
    public class UpLoadFiles
    {
        private static string DirectoryToSave = "Files\\Upload\\";
        private string DefaultFolder = HttpRuntime.AppDomainAppPath + DirectoryToSave;
        private HttpPostedFileBase ArquivoEnviado;

        private ReturnAction<List<FileProperties>> ret = new ReturnAction<List<FileProperties>>();

        #region Propriedades

        public List<FileProperties> Files = new List<FileProperties>();
        
        #endregion
        public UpLoadFiles(string directoryToSave = "Files\\Upload\\")
        {
            DirectoryToSave = directoryToSave;
        }

        public void Save(HttpRequestBase request)
        {
            foreach (string fileName in request.Files)
            {
                Save(request.Files[fileName]);
            }
        }

        public void Save(HttpPostedFileBase file)
        {
            Save(file);
        }

        public FileProperties Save(HttpPostedFileBase file, string id = "")
        {
            var fp = new FileProperties(file, DefaultFolder, id);

            if (!Directory.Exists(fp.Folder)) Directory.CreateDirectory(fp.Folder);

            file.SaveAs(fp.FullName);

            return fp;
        }
        


    }
}
