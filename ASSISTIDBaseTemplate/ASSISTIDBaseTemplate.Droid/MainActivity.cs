
using Android.App;
using Android.Content.PM;
using Android.OS;
using Messier16.Forms.Android.Controls;

namespace ASSISTIDBaseTemplate.Droid
{
    [Activity(Label = "ASSISTIDBaseTemplate", Icon = "@drawable/icon", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        protected override void OnCreate(Bundle bundle)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            base.OnCreate(bundle);

            global::Xamarin.Forms.Forms.Init(this, bundle);
            Messier16Controls.InitAll();
            LoadApplication(new App());
        }
    }
}

