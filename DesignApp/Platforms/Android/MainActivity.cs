using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.OS;
using Android.Views;
using Microsoft.Maui.Controls.PlatformConfiguration.AndroidSpecific;

namespace DesignApp
{

    [Activity(Theme = "@style/Maui.SplashTheme", MainLauncher = true,
        LaunchMode = LaunchMode.SingleTop,
        ConfigurationChanges = ConfigChanges.ScreenSize
                             | ConfigChanges.Orientation
                             | ConfigChanges.UiMode
                             | ConfigChanges.ScreenLayout
                             | ConfigChanges.SmallestScreenSize
                             | ConfigChanges.Density)]
    public class MainActivity : MauiAppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Window.SetFlags(WindowManagerFlags.LayoutNoLimits, WindowManagerFlags.LayoutNoLimits);
            Window.ClearFlags(WindowManagerFlags.TranslucentStatus);
            Window.SetSoftInputMode(SoftInput.AdjustResize);
            Window.SetStatusBarColor(Android.Graphics.Color.Transparent);
            if (Build.VERSION.SdkInt >= BuildVersionCodes.M)
            {
                Window.DecorView.SystemUiVisibility = (StatusBarVisibility)(SystemUiFlags.LightStatusBar);
            }
        }
    }
}
