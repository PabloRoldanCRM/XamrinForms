using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Todo.ViewModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Todo
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class CreatePage : ContentPage
	{
       // public List<TodoItem> todoItem;
        public CreatePageViewModel vm;
        private int updateID = 0;
        public CreatePage (int id)
		{
			InitializeComponent ();
            //todoItem = new List<TodoItem>();
            vm = new CreatePageViewModel();
            TodoItem todoItemOBJ = App.Database.GetTodo(id);
            Todo.Text = todoItemOBJ.TaskName;
            Date.Date = todoItemOBJ.DueDate;
            Time.Time= todoItemOBJ.DueDate.TimeOfDay;
            updateID = id;

        }
        public CreatePage()
        {
            InitializeComponent();
            //todoItem = new List<TodoItem>();
            vm = new CreatePageViewModel();
            BindingContext = vm;
            InitializeComponent();

        }
        public void OnSave(object o, EventArgs e)
        {
            //todoItem.Add(new TodoItem(Todo.Text, Priority.Items[Priority.SelectedIndex],
            //    SetDueDate(Date.Date,
            //         Time.Time.Hours,
            //         Time.Time.Minutes,
            //         Time.Time.Seconds), false));
            //Clear();
            vm.AddTask(Todo.Text,
                Priority.Items[Priority.SelectedIndex],
                Date.Date,
                Time.Time.Hours,
                Time.Time.Minutes,
                Time.Time.Seconds,
                updateID,
                false);
            Clear();
        }
        public void OnCancel(object o, EventArgs e) {
            Clear();
        }
        public void OnReview(object o, EventArgs e)
        {
           // var tempList = todoItem;
            Clear();
            //Navigation.PushAsync(new ListTaskPage(tempList));
            Navigation.PushAsync(new ListTaskPage());

        }
        public void OnSelectedIndexChanged(object o, EventArgs e) {
            
        }

        //private DateTime SetDueDate(DateTime date, int hour, int minute,int second)
        //{
        //    DateTime retVal = new DateTime(date.Year, date.Month, date.Day, hour, minute, second);
        //    return retVal;
        //}
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