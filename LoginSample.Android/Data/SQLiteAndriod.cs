using System;
using System.IO;
using LoginSample.Data;
using LoginSample.Droid.Data;
using Xamarin.Forms;

[assembly: Dependency(typeof(SQLiteAndriod))]
namespace LoginSample.Droid.Data
{
    public class SQLiteAndriod :ISQLite
    {
        public SQLiteAndriod() { }
        public SQLite.SQLiteConnection GetConnection()
        {
            var sqliteFileName = "TestDB.db3";
            string documentPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
            var path = Path.Combine(documentPath, sqliteFileName);
            var conn = new SQLite.SQLiteConnection(path);

            return conn;
        }
    }
}
