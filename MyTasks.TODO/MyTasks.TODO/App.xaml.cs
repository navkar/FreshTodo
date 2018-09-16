using FreshMvvm;
using MyTasks.TODO.Helpers;
using MyTasks.TODO.ViewModels;
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

            FreshPageModelResolver.PageModelMapper = new FreshViewModelMapper();
            InitNavigation();
        }

        private void InitNavigation()
        {
            var loginPage = FreshPageModelResolver.ResolvePageModel<LoginViewModel>();
            var loginStack = new FreshNavigationContainer(loginPage, NavigationStacks.LoginNavStack);

            var masterDetailNav = new MasterDetailNavigationContainer(NavigationStacks.MainNavStack);
            masterDetailNav.Init("Menu", "ic_toolbar_Bars");
            masterDetailNav.AddPage<BlankViewModel>("Dashboard", "Dashboard", '\uf200'.ToString(), null); // piechart icon
            masterDetailNav.AddPage<QuickTabViewModel>("Quick Tabs", "Items", '\uf192'.ToString(), null); // target icon
            masterDetailNav.AddPage<ContactListViewModel>("Contacts", "Items", '\uf192'.ToString(), null); // target icon
            masterDetailNav.AddPage<AboutViewModel>("About", "Settings", '\uf129'.ToString(), null); // info icon
            masterDetailNav.AddPage<TabViewModel>("Tab", "Settings", '\uf007'.ToString(), null); // user icon

            //push a tabbed page Modally
                //var tabbedNavigation = new FreshTabbedNavigationContainer(NavigationStacks.TabNavStack);
                //tabbedNavigation.AddTab<ContactListViewModel>("Contacts", "contacts.png", null);
                //tabbedNavigation.AddTab<BlankViewModel>("Quotes", "document.png", null);

                //masterDetailNav.Detail = new NavigationPage(new TabView());

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
            public static string TabNavStack = "TabNavStack";
        }
    }
}
