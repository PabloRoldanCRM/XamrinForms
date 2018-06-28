using SQLite;
using System;
using System.Collections.Generic;
using System.Text;


namespace Todo.Data
{
   public interface ISQLite
    {
        SQLiteConnection GetConnection();
    }
}
