using Acr.UserDialogs;
using FreshMvvm;
using MyTasks.TODO.Helpers;
using MyTasks.TODO.ViewModels;
using MyTasks.TODO.Services;
using MyTasks.TODO.Views;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation (XamlCompilationOptions.Compile)]
namespace MyTasks.TODO
{
	public partial class App : Application
	{
		public App ()
		{
			InitializeComponent();

            FreshIOC.Container.Register<IUserDialogs>(UserDialogs.Instance);
            FreshPageModelResolver.PageModelMapper = new FreshViewModelMapper();
            InitNavigation();
        }

        private void InitNavigation()
        {
            var loginPage = FreshPageModelResolver.ResolvePageModel<LoginViewModel>();
            var loginStack = new FreshNavigationContainer(loginPage, NavigationStacks.LoginNavStack);

            var masterDetailNav = new MasterDetailNavigationContainer(NavigationStacks.MainNavStack);
            masterDetailNav.Init("Menu", "ic_toolbar_Bars");
            

            masterDetailNav.AddPage<ToDoListViewModel>("TODO Items", "Items", '\uf192'.ToString()); // user icon
            masterDetailNav.AddPage<QuickTabViewModel>("Quick Tabs", "Items", '\uf192'.ToString()); // target icon
            masterDetailNav.AddPage<ContactListViewModel>("Contacts", "Items", '\uf192'.ToString(), 1); // target icon
            masterDetailNav.AddPage<BlankViewModel>("Dashboard", "Dashboard", '\uf200'.ToString()); // piechart icon
            masterDetailNav.AddPage<AboutViewModel>("About", "Settings", '\uf129'.ToString()); // info icon
            masterDetailNav.AddPage<TabViewModel>("User Profile", "Settings", '\uf007'.ToString(), 2); // user icon
            
            MainPage = loginStack;
        }

        protected override void OnStart ()
		{
        }

		protected override void OnSleep ()
		{
			// Handle when your app sleeps
		}

		protected override void OnResume ()
		{
			// Handle when your app resumes
		}

        public class NavigationStacks
        {
            public static string LoginNavStack = "LoginNavStack";
            public static string MainNavStack = "MainNavStack";
        }
    }
}
