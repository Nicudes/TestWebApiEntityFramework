//using PragueDbTest.UWP;
//using SQLite;
//using System;
//using System.Collections.Generic;
//using System.IO;
//using System.Linq;
//using System.Runtime.CompilerServices;
//using System.Text;
//using System.Threading.Tasks;
//using Windows.Storage;
//using Xamarin.Forms;

//[assembly: Xamarin.Forms.Dependency(typeof(DatabaseConnection_UWP))]
//namespace PragueDbTest.UWP
//{
//    public class DatabaseConnection_UWP : IDatabaseConnection
//    {
//        public SQLiteConnection DbConnection()
//        {
//            var dbName = "CustomersDb.db3";
//            var path = Path.Combine(ApplicationData.Current.LocalFolder.Path, dbName);
//            return new SQLiteConnection(path);
//        }
//    }
//}
