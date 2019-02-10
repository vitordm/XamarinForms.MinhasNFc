using SQLite;

namespace MinhasNFc.Interfaces.Database
{
    public interface ISQLiteDb
    {
        SQLiteConnection Connection { get; }
        string SQLitePath { get; }
    }
}
