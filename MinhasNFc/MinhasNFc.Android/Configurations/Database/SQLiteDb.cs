using Android.Util;
using MinhasNFc.Droid.Configurations.Database;
using MinhasNFc.Interfaces.Database;
using SQLite;
using System;
using System.IO;
using Xamarin.Forms;

[assembly: Dependency(typeof(SQLiteDb))]
namespace MinhasNFc.Droid.Configurations.Database
{
    class SQLiteDb : Java.Lang.Object, ISQLiteDb
    {

        public SQLiteConnection GetConnection()
        {
            return (new SQLiteConnection(SQLitePath));
        }

        public string SQLitePath
        {
            get
            {
                string caminhoSQLite = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
                var caminho = Path.Combine(caminhoSQLite, "db.db3");
                return caminho;
            }
        }

        public void ExportaDatabase()
        {
            try
            {
                var arquivoDb = SQLitePath;

                var bytes = System.IO.File.ReadAllBytes(arquivoDb);
                var gerenciador = new GerenciadorArquivos();
                gerenciador.SalvarArquivoEmPastaPublica(bytes, "db.db3", out string caminhoArquivo);
                Log.Info("APP-DATABASE", caminhoArquivo);
            }
            catch (Exception ex)
            {
                Log.Info("GERENCIADOR", ex.Message);
            }
        }
    }


}