
using Acr.UserDialogs;
using Android.App;
using Android.Content.PM;
using Android.OS;
using Lottie.Forms.Droid;
using Xamarin.Forms.Platform.Android;

namespace MyTasks.TODO.Droid
{
    [Activity(Label = "Nav", Icon = "@mipmap/ic_launcher", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        protected override void OnCreate(Bundle bundle)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            Window.AddFlags(global::Android.Views.WindowManagerFlags.DrawsSystemBarBackgrounds);

            UserDialogs.Init(this);
            FFImageLoading.Forms.Platform.CachedImageRenderer.Init(true);
            base.OnCreate(bundle);

            global::Xamarin.Forms.Forms.Init(this, bundle);

            AnimationViewRenderer.Init();

            if (Build.VERSION.SdkInt >= BuildVersionCodes.Lollipop)
            {
                //Window.DecorView.SystemUiVisibility = 0;
                //var statusBarHeightInfo = typeof(FormsAppCompatActivity).GetField("_statusBarHeight", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic);
                //statusBarHeightInfo.SetValue(this, 0);
                //Window.SetStatusBarColor(new Android.Graphics.Color(176, 106, 179, 255));
            }

            LoadApplication(new App());

            // IMPORTANT: Initialize XFGloss AFTER calling LoadApplication on the Android platform
            XFGloss.Droid.Library.Init(this, bundle);
        }
    }
}

