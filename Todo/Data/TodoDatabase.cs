using SQLite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Xamarin.Forms;

namespace Todo.Data
{
 public   class TodoDatabase
    {
        private SQLiteConnection db;
        static object locker = new object();

        public TodoDatabase() {
            // db = DependencyService.Get<ISQLite>().GetConnection();
            db = GetConnection();
            db.CreateTable<TodoItem>();
        }

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

        public int SaveTodo(TodoItem item) {
            lock (locker)
            {
                if (item.ID != 0)
                {
                    db.Update(item);
                    return item.ID;

                }
                else {
                    return db.Insert(item);
                }
            }
     
        }

        public TodoItem GetTodo(int id) {
            lock (locker)
            {
                return db.Table<TodoItem>().Where(c => c.ID == id).FirstOrDefault();
            }
        }
        public IEnumerable<TodoItem> GetTodos()
        {
            lock (locker)
            {
                return db.Table<TodoItem>().ToList();
            }
        }
    }
}
