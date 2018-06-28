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
	public partial class ListTaskPage : ContentPage
	{
        public string MyName { get; set; }
        public List<TodoItem> TodoItems { get; set; }
        public ListTaskPage ( List<TodoItem> items)
		{
            MyName = "Pablo";
            BindingContext = this;
            TodoItems = items;
			InitializeComponent ();
		}
        public ListTaskPage()
        {
            InitializeComponent();
        }

        public void OnSelected(object o, ItemTappedEventArgs e)
        {
            var toDoItems = e.Item as TodoItem;
            DisplayAlert("Item! ", toDoItems.TaskName + " Was Selcted!", "DISSMIS");
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            ToDoList.ItemsSource = App.Database.GetTodos();
        }
    }
}