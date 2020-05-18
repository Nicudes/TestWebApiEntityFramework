using System;
using System.Collections.Generic;
using System.Text;

namespace PragueDbTest
{
    public interface IDatabaseConnection
    {
        SQLite.SQLiteConnection DbConnection();
    }
}
