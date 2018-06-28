using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace Todo
{
   public class TodoItem
    {
        [PrimaryKeyAttribute,AutoIncrement]
        public int ID { get; set; }
        public string TaskName { get; set; }

        public string Priority { get; set; }

        public DateTime DueDate { get; set; }


        public bool IsDeleted { get; set; }

        //public TodoItem(string taskName, string priority, DateTime dueDate, bool isDeleted)
        //{
        //    this.TaskName = taskName;
        //    this.Priority = priority;
        //    this.DueDate = dueDate;
        //    this.IsDeleted = isDeleted;
        //}
    }
}
