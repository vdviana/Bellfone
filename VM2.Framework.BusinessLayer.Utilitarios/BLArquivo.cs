using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Drawing;
using System.Drawing.Imaging;
using System.Drawing.Drawing2D;


namespace VM2.Framework.BusinessLayer.Utilitarios
{
    public static class BLArquivo
    {

        #region SalvarImagem

        /// <summary>
        /// Salvar imagem no diretório informado
        /// </summary>
        /// <user>tprohaska</user>
        public static void SalvarImagem(Stream pstrArquivo, string pstrCaminho)
        {
            string strDiretorio = string.Empty;

            try
            {
                strDiretorio = Path.GetDirectoryName(pstrCaminho);

                if (!Directory.Exists(strDiretorio))
                {
                    Directory.CreateDirectory(strDiretorio);
                }

                if (File.Exists(pstrCaminho))
                {
                    File.Delete(pstrCaminho);
                }
                
                byte[] arrByte = new byte[pstrArquivo.Length];
                pstrArquivo.Read(arrByte, 0, arrByte.Length);
                Image objImagem = Image.FromStream(new MemoryStream(arrByte));

                objImagem.Save(pstrCaminho);

            }
            catch
            {
                throw;
            }

        }

        #endregion

        #region Excluir Arquivo

        /// <summary>
        /// Excluir imagem no diretório informado
        /// </summary>
        /// <user>vnarcizo</user>
        public static void ExcluirArquivo(string pstrCaminho)
        {
            string strDiretorio = string.Empty;

            try
            {
                strDiretorio = Path.GetDirectoryName(pstrCaminho);

                if (Directory.Exists(strDiretorio) && File.Exists(pstrCaminho))
                {
                    File.Delete(pstrCaminho);
                }
            }
            catch
            {
                throw;
            }

        }

        #endregion

        #region Redimencionar imagem

        /// <summary>
        /// Redimenciona o tamanho da imagem
        /// </summary>
        /// <param name="arrByte"></param>
        /// <returns></returns>
        /// <user>tprohaska</user>
        public static  byte[] RedimencionarImagem(byte[] arrByte, int intAltura, int intLargura)
        {
            //byte[] arrByte = null;
            Image objImagem;
            MemoryStream ms = null;

            try
            {
                ms = new MemoryStream(arrByte);

                objImagem = Image.FromStream(ms, true);

                Bitmap bmPhoto = new Bitmap(intLargura, intAltura, PixelFormat.Format24bppRgb);
                bmPhoto.SetResolution(72, 72);
                Graphics grPhoto = Graphics.FromImage(bmPhoto);

                grPhoto.SmoothingMode = SmoothingMode.AntiAlias;
                grPhoto.InterpolationMode = InterpolationMode.HighQualityBicubic;
                grPhoto.PixelOffsetMode = PixelOffsetMode.HighQuality;
                grPhoto.DrawImage(objImagem, new Rectangle(0, 0, intLargura, intAltura), 0, 0, objImagem.Width, objImagem.Height, GraphicsUnit.Pixel);

                MemoryStream mm = new MemoryStream();
                bmPhoto.Save(mm, System.Drawing.Imaging.ImageFormat.Jpeg);

                objImagem.Dispose();
                bmPhoto.Dispose();
                grPhoto.Dispose();

                return mm.GetBuffer();

            }
            catch
            {
                throw;
            }
            finally
            {
                ms.Close();
            }
        }

        #endregion

        #region Salvar imagem redimencionada
        /// <summary>
        ///     Salvar a imagem com tamanho configurado no web.config
        /// </summary>
        /// <param name="arrArquivo"></param>
        /// <param name="strCaminho"></param>
        /// <user>tprohaska</user>
        public static void SalvarImagemRedimencionando(byte[] arrArquivo, string strCaminho, int intAltura, int intLargura)
        {
            FileStream objFile = null;
            byte[] arrByte = null;

            try
            {
                arrByte = RedimencionarImagem(arrArquivo, intAltura, intLargura);
                objFile = new FileStream(strCaminho, FileMode.OpenOrCreate);
                objFile.Write(arrByte, 0, arrByte.Length);
            }
            catch
            {
                throw;
            }
            finally
            {
                if (objFile != null)
                {
                    objFile.Close();
                    objFile.Dispose();
                }
            }
        }

        #endregion

        #region Salvar Arquivo

        /// <summary>
        /// Salvar arquivo no diretório informado
        /// </summary>
        /// <user>tprohaska</user>
        public static void SalvarArquivo(Stream pstrArquivo, string pstrCaminho)
        {
            string strDiretorio = string.Empty;

            FileStream objFileStrem = null;
            try
            {
                strDiretorio = Path.GetDirectoryName(pstrCaminho);

                if (!Directory.Exists(strDiretorio))
                {
                    Directory.CreateDirectory(strDiretorio);
                }

                if (File.Exists(pstrCaminho))
                {
                    File.Delete(pstrCaminho);
                }

                byte[] arrByte = new byte[pstrArquivo.Length];
                pstrArquivo.Read(arrByte, 0, arrByte.Length);

                objFileStrem = new FileStream(pstrCaminho, FileMode.OpenOrCreate, FileAccess.Write);
                objFileStrem.Write(arrByte, 0, arrByte.Length);
                objFileStrem.Flush();

            }
            catch
            {
                throw;
            }
            finally
            {
                if (objFileStrem != null)
                    objFileStrem.Close();
            }
        }

        #endregion
    }
}
