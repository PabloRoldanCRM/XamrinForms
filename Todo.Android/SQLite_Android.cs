using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using SQLite;
using Todo.Data;
using Todo.Droid;

[assembly: Xamarin.Forms.Dependency(typeof(SQLite_Android))]
namespace Todo.Droid
{
    
    public class SQLite_Android : ISQLite
    {
        public SQLiteConnection GetConnection()
        {
            //throw new NotImplementedException();
            //var path = @"/users/pablo/Data/Todo.db";
            string DB_ANAGRAFICA_FILENAME = "basedatos.db";
            string folderPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
            string dbPath = Path.Combine(folderPath, DB_ANAGRAFICA_FILENAME);
           // var path = @"C:\Users\Rhino Systems\Desktop\Mydb";
            
            File.Open(dbPath, FileMode.OpenOrCreate);
            var conn = new SQLiteConnection(dbPath);
            return conn;
        }
    }
}