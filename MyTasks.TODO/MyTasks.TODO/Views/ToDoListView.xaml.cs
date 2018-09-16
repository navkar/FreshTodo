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
			InitializeComponent ();
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