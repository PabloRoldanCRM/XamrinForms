using System;
using System.Collections.Generic;
using System.Text;

namespace Todo.ViewModel
{
   public class CreatePageViewModel
    {
        public CreatePageViewModel() { }
        public void AddTask(string todo, string priority, DateTime dueDate, int hour, int min, int sec, int updateID, bool isDelated)
        {
            var newTodo = new TodoItem
            {
                TaskName = todo,
                Priority = priority,
                DueDate = SetDueDate(dueDate, hour, min, sec),
                IsDeleted = isDelated,
                ID = updateID,

            };
            App.Database.SaveTodo(newTodo);
        }

        public DateTime SetDueDate(DateTime dueDate, int hour, int min, int sec)
        {
            DateTime retVal = new DateTime(dueDate.Year, dueDate.Month, dueDate.Day, hour, min, sec);
            return retVal;
        }
    }
}
