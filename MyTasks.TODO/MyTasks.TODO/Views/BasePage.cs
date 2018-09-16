using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace MyTasks.TODO.Views
{
    public class BasePage : ContentPage
    {
        public BasePage()
        {
            //ToolbarItems.Add(new ToolbarItem("", "Home.png", () => {
            //    Application.Current.MainPage = new NavigationPage(new LaunchPage((App)Application.Current));
            //}));
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            var basePageModel = this.BindingContext as FreshMvvm.FreshBasePageModel;
            if (basePageModel != null)
            {
                if (basePageModel.IsModalAndHasPreviousNavigationStack())
                {
                    if (ToolbarItems.Count < 2)
                    {
                        var closeModal = new ToolbarItem("Close Modal", "", () => {
                            basePageModel.CoreMethods.PopModalNavigationService();
                        });

                        ToolbarItems.Add(closeModal);
                    }
                }
            }
        }
    }
}
