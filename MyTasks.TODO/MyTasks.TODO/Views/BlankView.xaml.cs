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
		}

        protected override void OnAppearing()
        {
            base.OnAppearing();
            Device.StartTimer(new System.TimeSpan(0, 0, 4), StopAnimation);
        }

        private bool StopAnimation()
        {
            blankAnimation.IsPlaying = false;
            blankAnimation.IsVisible = false;
            lblComment.IsVisible = true;
            return true;
        }

	}
}