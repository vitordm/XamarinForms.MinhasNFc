using SQLite;

namespace MinhasNFc.Interfaces.Database
{
    public interface ISQLiteDb
    {
        SQLiteConnection GetConnection();
        string SQLitePath { get; }
        void ExportaDatabase();
    }
}
