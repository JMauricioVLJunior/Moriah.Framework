using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using Moriah.Framework.Exceptions;

namespace Moriah.Framework.Files
{
    public class Arquivo
    {
        private const string DiretorioUpload = "Files\\Upload\\";
        private string DiretorioDefault = HttpRuntime.AppDomainAppPath + DiretorioUpload;
        private HttpPostedFileBase ArquivoEnviado;

        #region Propriedades

        public string Path { get; private set; }
        public string HASH { get; private set; }

        public string ArquivoEmTexto { get; private set; }
        public string NomeArquivo { get; private set; }
        public string NomeArquivoOriginal { get; private set; }
        public string PathCompleto { get { return Path + NomeArquivo; } }
        public string Diretorio { get; private set; }


        #endregion

        public Arquivo(HttpPostedFileBase arquivo)
        {
            Diretorio = DiretorioDefault;
            ArquivoEnviado = arquivo;
            byte[] bytes = new BinaryReader(arquivo.InputStream).ReadBytes(arquivo.ContentLength);
            HASH = BitConverter.ToString(MD5.Create().ComputeHash(bytes)).Replace("-","");
        }
        

        /// <summary>
        /// Salva o arquivo no Path Configurado
        /// </summary>
        /// <param name="arquivo">Objeto contendo o stream do arquivo.</param>
        /// <param name="idIdentificacao">ID para configurar no início do nome do arquivo fisicamente.</param>
        /// <returns>Retorna o caminho completo do arquivo salvo.</returns>
        public string SalvarArquivo(int idIdentificacao = 0)
        {
            if (ArquivoEnviado.FileName.Length < 5 || !ArquivoEnviado.FileName.Contains("."))
            {
                throw new FileNameException(ArquivoEnviado);
            }
            else if (ArquivoEnviado == null || ArquivoEnviado.ContentLength == 0 )
            {
                throw new FileFormatException(ArquivoEnviado);
            }
            else
            {
                NomeArquivoOriginal = ArquivoEnviado.FileName;

                string extensao = NomeArquivoOriginal.Right(3);

                NomeArquivo = string.Format("{0}_{1}.{2}", idIdentificacao, Guid.NewGuid().ToString(), extensao);

                if (!Directory.Exists(Diretorio)) Directory.CreateDirectory(Diretorio);

                string localArquivo = Diretorio + NomeArquivo;

                ArquivoEnviado.SaveAs(localArquivo);

                Path = localArquivo;

                return NomeArquivo;
            }
        }


    }
}
