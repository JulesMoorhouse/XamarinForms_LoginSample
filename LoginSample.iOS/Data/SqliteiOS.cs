using System;
using System.IO;
using LoginSample.Data;
using LoginSample.iOS.Data;
using Xamarin.Forms;

[assembly: Dependency(typeof(SqliteiOS))]
namespace LoginSample.iOS.Data
{
    public class SqliteiOS: ISQLite
    {
        public SqliteiOS() { }
        public SQLite.SQLiteConnection GetConnection()
        {
            var fileName = "Testdb.db3";
            var documentPath = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            var libraryPath = Path.Combine(documentPath, "..", "Library");
            var path = Path.Combine(libraryPath, fileName);
            var connection = new SQLite.SQLiteConnection(path);

            return connection;
        }
    }
}
