using Android.Views;
using Android.Content;
using MyTasks.TODO.Controls;
using MyTasks.TODO.Droid.Renderers;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;


[assembly: ExportRenderer(typeof(FocusableListView), typeof(FocusableListViewRenderer))]
namespace MyTasks.TODO.Droid.Renderers
{
    public class FocusableListViewRenderer : ListViewRenderer
    {
        public FocusableListViewRenderer(Context context): base(context)
        { }

        protected override void OnElementChanged(ElementChangedEventArgs<Xamarin.Forms.ListView> e)
        {
            base.OnElementChanged(e);
            if (e.NewElement != null)
            {
                var listView = Control;
                // The ViewGroup will get focus only if none of its descendants want it.
                listView.DescendantFocusability = DescendantFocusability.AfterDescendants;
            }
        }
    }
}