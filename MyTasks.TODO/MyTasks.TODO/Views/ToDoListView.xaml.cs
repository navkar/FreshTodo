using Acr.UserDialogs;
using MyTasks.TODO.ViewModels;
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
        public ToDoListView()
		{
			InitializeComponent();
        }

        protected override void OnBindingContextChanged()
        {
            base.OnBindingContextChanged();

            var pageModel = BindingContext as ToDoListViewModel;

            // Modify the page based on the pageModel
            //pageModel.GetDataCommand.Execute(null);
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
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