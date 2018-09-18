using Acr.UserDialogs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MyTasks.TODO.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ToDoListView : ContentPage
	{
        //ViewModels.ToDoListViewModel ViewModel = new ViewModels.ToDoListViewModel(UserDialogs.Instance);
        public ToDoListView()
		{
			InitializeComponent();
          //  this.BindingContext = ViewModel;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            //ViewModel.GetDataCommand.Execute(null);
        }
        
        void ToDoItemsListView_OnItemTapped(object sender, ItemTappedEventArgs e)
        {
        }

        void ToDoItemsListView_OnItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            ToDoItemsListView.SelectedItem = null;
        }
    }
}