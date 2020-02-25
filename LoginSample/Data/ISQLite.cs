using System;
using SQLite;

namespace LoginSample.Data
{
    public interface ISQLite
    {
        SQLiteConnection GetConnection();
    }
}
