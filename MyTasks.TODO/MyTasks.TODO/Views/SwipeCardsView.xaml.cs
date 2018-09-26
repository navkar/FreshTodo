using MyTasks.TODO.Controls;
using MyTasks.TODO.Models;
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
    public partial class SwipeCardsView : ContentPage
    {
        private SwipeCardsViewModel VM { get; set; }
        public SwipeCardsView()
        {
            InitializeComponent();
            VM = BindingContext as SwipeCardsViewModel;
            // Disable swiping between tabs on Android, as it collides 
            // with Swipe Card's swipe gestures
            //this.On<Xamarin.Forms.PlatformConfiguration.Android>().SetIsSwipePagingEnabled(false);
        }

        protected override void OnBindingContextChanged()
        {
            base.OnBindingContextChanged();

            VM = BindingContext as SwipeCardsViewModel;
        }

        private void OptionsListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var item = e.SelectedItem as OptionItem;
            Console.WriteLine("SelectedItem: " + item.Id);
        }

        private void OptionsListView_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            var item = e.Item as OptionItem;
            if (item != null)
            {
                Console.WriteLine("VM.CurrentPositionIndex: " + VM.CurrentPositionIndex);
                //VM.Cards[VM.CurrentPositionIndex].Options[item.Id-1].IsSelected = !VM.Cards[VM.CurrentPositionIndex].Options[item.Id-1].IsSelected;
                Console.WriteLine("SelectedItem: " + (item.Id-1));
            }

            var control = sender as ListView;
            var selectedItem = control.SelectedItem;
            control.SelectedItem = null;
        }

        public void OptionListItem_OptionSelected(object sender, Xamarin.Forms.ToggledEventArgs e)
        {
            var control = sender as OptionListSwitch;
            Console.WriteLine("?=> " + e.Value);
        }
    }
}