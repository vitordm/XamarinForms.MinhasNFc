using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Xamarin.Forms;
using Android.Content.Res;
using Android.Util;

namespace MinhasNFc.Droid.Configurations
{
    class GerenciadorArquivos : Java.Lang.Object
    {
        public bool SalvarArquivoEmPastaPublica(byte[] arquivo, string nomeArquivo, out string caminhoArquivo)
        {
            caminhoArquivo = "";

            try
            {
                var caminhoPublico = Android.OS.Environment.GetExternalStoragePublicDirectory(
                    Android.OS.Environment.DirectoryDownloads) + "";

                if (!System.IO.Directory.Exists(caminhoPublico))
                {
                    System.IO.Directory.CreateDirectory(caminhoPublico);
                }

                VerificarExisteSubPastas(caminhoPublico, nomeArquivo);

                caminhoPublico = caminhoPublico + "/" + nomeArquivo;

                if (ExisteArquivo(caminhoPublico))
                    DeleteArquivo(caminhoPublico);

                using (var bw = new System.IO.BinaryWriter(System.IO.File.Open
                    (caminhoPublico, System.IO.FileMode.CreateNew)))
                {
                    bw.Write(arquivo);
                    if (ExisteArquivo(caminhoPublico))
                    {
                        caminhoArquivo = caminhoPublico;
                        return true;
                    }

                    return false;

                }
            }
            catch (Exception ex)
            {
                Log.Debug("APP-GERENCIADOR", ex.Message);
            }

            return false;
        }

        private void VerificarExisteSubPastas(string caminhoPublico, string nomeArquivo)
        {
            var pastaDestinoArray = nomeArquivo.Split('/');
            if (pastaDestinoArray.Count() > 1)
            {
                pastaDestinoArray = pastaDestinoArray.Take(pastaDestinoArray.Count() - 1).ToArray();


                var pastaDestino = string.Join("/", pastaDestinoArray);
                var verificarPasta = caminhoPublico + "/" + pastaDestino;
                if (!System.IO.Directory.Exists(verificarPasta))
                {
                    System.IO.Directory.CreateDirectory(verificarPasta);
                }

            }

        }

        public bool SalvarArquivo(byte[] arquivo, string nomeArquivo)
        {

            var pastaDestinoArray = nomeArquivo.Split('/');
            pastaDestinoArray = pastaDestinoArray.Take(pastaDestinoArray.Count() - 1).ToArray();
            var pastaDestino = string.Join("/", pastaDestinoArray);

            if (!System.IO.Directory.Exists(pastaDestino))
            {
                System.IO.Directory.CreateDirectory(pastaDestino);
            }

            if (ExisteArquivo(nomeArquivo))
            {
                DeleteArquivo(nomeArquivo);
            }

            using (var bw = new System.IO.BinaryWriter(System.IO.File.Open(nomeArquivo, System.IO.FileMode.CreateNew)))
            {
                bw.Write(arquivo);
                if (ExisteArquivo(nomeArquivo))
                {
                    return true;
                }

                return false;

            }
        }

        public bool ExisteArquivo(string arquivo)
        {
            return System.IO.File.Exists(arquivo);
        }

        public bool DeleteArquivo(string destino)
        {
            if (System.IO.File.Exists(destino))
            {
                System.IO.File.Delete(destino);
            }

            return !System.IO.File.Exists(destino);
        }
    }
}