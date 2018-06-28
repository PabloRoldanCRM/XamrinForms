using System;
using Todo.Data;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation (XamlCompilationOptions.Compile)]
namespace Todo
{
	public partial class App : Application
	{
        private static TodoDatabase db;
        public static TodoDatabase Database
        {

            get { if (db != null)
                {
                    db = new TodoDatabase();
                }return db;

            }
        }
		public App ()
		{
			InitializeComponent();

			MainPage = new NavigationPage(new CreatePage());
		}

		protected override void OnStart ()
		{
			// Handle when your app starts
		}

		protected override void OnSleep ()
		{
			// Handle when your app sleeps
		}

		protected override void OnResume ()
		{
			// Handle when your app resumes
		}
	}
}
