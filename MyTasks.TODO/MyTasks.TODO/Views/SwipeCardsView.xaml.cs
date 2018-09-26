using MyTasks.TODO.Models;
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
    public partial class SwipeCardsView : ContentPage
    {
        public SwipeCardsView()
        {
            InitializeComponent();

            // Disable swiping between tabs on Android, as it collides 
            // with Swipe Card's swipe gestures
            //this.On<Xamarin.Forms.PlatformConfiguration.Android>().SetIsSwipePagingEnabled(false);
        }


        private void OptionsListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var item = e.SelectedItem as OptionItem;
            Console.WriteLine("SelectedItem: " + item.Id);
        }

        private void OptionsListView_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            var control = sender as ListView;
            control.SelectedItem = null;
            var item = e.Item as OptionItem;
            Console.WriteLine("SelectedItem: " + item.Id);
            
        }
    }
}