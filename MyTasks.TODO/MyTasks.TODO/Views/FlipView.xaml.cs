using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MyTasks.TODO.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class FlipView : ContentPage
	{
        int TimeKeeper { get; set; } = 5;

		public FlipView ()
		{
			InitializeComponent ();

            EnableAutoFlip(1);

        }

        private void EnableAutoFlip(double seconds)
        {

            Device.StartTimer(TimeSpan.FromSeconds(seconds),
                () =>
                {
                    frontViewTimeLabel.Text = TimeKeeper.ToString();
                    backViewTimeLabel.Text = TimeKeeper.ToString();
                    TimeKeeper--;
                    if (TimeKeeper <= 0)
                    {
                        flipViewContentControl.IsFlipped = !flipViewContentControl.IsFlipped;
                        TimeKeeper = 3;
                        //Thread.Sleep(100);
                    }
                    return true;
                });
        }
    }
}