using Android.Animation;
using Android.Content;
using MyTasks.TODO.Controls;
using MyTasks.TODO.Droid.Renderers;
using System.ComponentModel;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(FlipViewContent), typeof(FlipViewContentRenderer))]
namespace MyTasks.TODO.Droid.Renderers
{
    public class FlipViewContentRenderer : ViewRenderer
    {
        private float _cameraDistance;

        private readonly ObjectAnimator _animateYAxis0To90;
        private readonly ObjectAnimator _animateYAxis90To180;

        public FlipViewContentRenderer(Context context) : base(context)
        {
            // Initiating the first half of the animation
            _animateYAxis0To90 = ObjectAnimator.OfFloat(this, "RotationY", 0.0f, -90f);
            _animateYAxis0To90.SetDuration(500);
            _animateYAxis0To90.Update += (sender, args) =>
            {
                // On every animation Frame we have to update the Camera Distance since Xamarin overrides it somewhere
                SetCameraDistance(_cameraDistance);
            };
            _animateYAxis0To90.AnimationEnd += (sender, args) =>
            {
                if (((FlipViewContent)Element).IsFlipped)
                {
                    // Change the visible content
                    ((FlipViewContent)Element).FrontView.IsVisible = false;
                    ((FlipViewContent)Element).BackView.IsVisible = true;
                }
                else
                {
                    // Change the visible content
                    ((FlipViewContent)Element).BackView.IsVisible = false;
                    ((FlipViewContent)Element).FrontView.IsVisible = true;
                }

                this.RotationY = -270;

                _animateYAxis90To180.Start();
            };

            // Initiating the second half of the animation
            _animateYAxis90To180 = ObjectAnimator.OfFloat(this, "RotationY", -270f, -360f);
            _animateYAxis90To180.SetDuration(500);
            _animateYAxis90To180.Update += (sender1, args1) =>
            {
                // On every animation Frame we have to update the Camera Distance since Xamarin overrides it somewhere
                SetCameraDistance(_cameraDistance);
            };
        }

        protected override void OnElementChanged(ElementChangedEventArgs<Xamarin.Forms.View> e)
        {
            base.OnElementChanged(e);

            if (((FlipViewContent)e.NewElement) != null)
            {
                // Calculating Camera Distance to be used at Animation Runtime
                // https://forums.xamarin.com/discussion/49978/changing-default-perspective-after-rotation
                var distance = 8000;
                _cameraDistance = Context.Resources.DisplayMetrics.Density * distance;
            }
        }

        protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);

            if (e.PropertyName == FlipViewContent.IsFlippedProperty.PropertyName)
            {
                if (!((FlipViewContent)sender).IsFlipped)
                {
                    this.RotationY = 0;
                }

                AnimateFlipHorizontally();
            }
        }

        private void AnimateFlipHorizontally()
        {
            SetCameraDistance(_cameraDistance);
            _animateYAxis0To90.Start();
        }
    }
}