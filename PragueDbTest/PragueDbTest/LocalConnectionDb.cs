using PCLStorage;
using SQLite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;


namespace PragueDbTest
{
    public class LocalConnectionDb
    {

        public SQLite.SQLiteConnection GetConnection()
        {
            SQLiteConnection sqliteConnection;
            var sqliteFileName = "Customer.db3";
            IFolder folder = FileSystem.Current.LocalStorage;
            string path = PortablePath.Combine(folder.Path.ToString(), sqliteFileName);
            sqliteConnection = new SQLite.SQLiteConnection(path);
            return sqliteConnection;
        }


    }
}
