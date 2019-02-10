using MinhasNFc.Droid.Configurations.Database;
using MinhasNFc.Interfaces.Database;
using SQLite;
using System.IO;
using Xamarin.Forms;

[assembly: Dependency(typeof(SQLiteDb))]
namespace MinhasNFc.Droid.Configurations.Database
{
    class SQLiteDb : Java.Lang.Object, ISQLiteDb
    {

        private SQLiteConnection _connection = null;
        public SQLiteConnection Connection
        {
            get
            {
                if (_connection == null)
                {
                    _connection = new SQLiteConnection(SQLitePath);
                }
                return _connection;
            }
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
    }
}