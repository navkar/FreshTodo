using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MyTasks.TODO.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class BlankView : ContentPage
	{
		public BlankView()
		{
			InitializeComponent ();
            //NavigationPage.SetHasNavigationBar(this, false);
		}
	}
}