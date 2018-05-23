using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Todo
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class CreatePage : ContentPage
	{
        public List<TodoItem> todoItem;
        public CreatePage ()
		{
			InitializeComponent ();
            todoItem = new List<TodoItem>();
            Priority.SelectedIndex = 0;


        }
        public void OnSave(object o, EventArgs e)
        {
            todoItem.Add(new TodoItem(Todo.Text, Priority.Items[Priority.SelectedIndex],
                SetDueDate(Date.Date,
                     Time.Time.Hours,
                     Time.Time.Minutes,
                     Time.Time.Seconds), false));
            Clear();
        }
        public void OnCancel(object o, EventArgs e) {
            Clear();
        }
        public void OnReview(object o, EventArgs e)
        {
            var tempList = todoItem;
            Clear();
            Navigation.PushAsync(new ListTaskPage(tempList));
        }
        public void OnSelectedIndexChanged(object o, EventArgs e) {
            
        }

        private DateTime SetDueDate(DateTime date, int hour, int minute,int second)
        {
            DateTime retVal = new DateTime(date.Year, date.Month, date.Day, hour, minute, second);
            return retVal;
        }
        private void Clear() {

            Priority.SelectedIndex = 0;
            Todo.Text  = String.Empty;
            Date.Date = DateTime.Now;
            Time.Time = new TimeSpan(
         DateTime.Now.Hour,
         DateTime.Now.Minute,
         DateTime.Now.Second
                );
        }
    }
}