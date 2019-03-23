using Moriah.Framework.Exceptions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Moriah.Framework.Files
{
    public class FileProperties
    {
        public string FullName { get; private set; }
        public string HashMD5 { get; private set; }

        public string FileAsString { get; private set; }
        public string FileName { get; private set; }
        public string OriginalFileName { get; private set; }
        public string Folder { get; private set; }
        public HttpPostedFileBase File { get; private set; }

        public FileProperties(HttpPostedFileBase file, string folder, string id = "")
        {
            File = file;
            Folder = folder;
            byte[] bytes = new BinaryReader(file.InputStream).ReadBytes(file.ContentLength);
            HashMD5 = BitConverter.ToString(MD5.Create().ComputeHash(bytes)).Replace("-", "");

            if (file.FileName.Length < 5 || !file.FileName.Contains("."))
            {
                throw new FileNameException(file);
            }
            else if (file == null || file.ContentLength == 0)
            {
                throw new FileFormatException(file);
            }
            else
            {
                OriginalFileName = file.FileName;

                string extension = OriginalFileName.Right(3);

                FileName = string.Format("{0}{1}.{2}", id.Equals("") ? "" : id + "_" , Guid.NewGuid().ToString(), extension);

                FullName = Folder + FileName;

            }



        }
      
    }
}
