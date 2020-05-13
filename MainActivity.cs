using Android.App;
using Android.OS;
using Android.Support.V7.App;
using Android.Runtime;
using Android.Widget;
using Android.Views;
using Java.Security;
using Java.Lang;

namespace Drawing_android
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity, View.IOnTouchListener
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_main);

            /*var view = this.FindViewById(Resource.Id.canvas);
            view.SetOnTouchListener(this);*/
        }

        public bool OnTouch(View v, MotionEvent e)
        {
            /*switch (e.Action)
            {
                case MotionEventActions.Down:
                    break;
                case MotionEventActions.Up:
                    FindViewById<TextView>(Resource.Id.canvas).Text = "tuk";
                    break;
            }*/
            return true;
        }
       
    }
}