using SQLite;

namespace FishingDerby
{
    public interface ISQLiteDb
    {
        SQLiteAsyncConnection GetConnection();
    }
}

