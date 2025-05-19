using Android.App;
using Android.Content.PM;
using Android.OS;
using Android.Views;
using iText.Kernel.Pdf;
using Microsoft.Maui.Controls.PlatformConfiguration.AndroidSpecific;
using Plugin.Fingerprint;
using Plugin.Fingerprint.Abstractions;

namespace DesignApp
{
    [Activity(
        Theme = "@style/Maui.SplashTheme",
        MainLauncher = true,
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
            CrossFingerprint.SetCurrentActivityResolver(() => this);
            // Adjust layout when keyboard appears
            Window.SetSoftInputMode(SoftInput.AdjustResize);

            // Optional: if you want full screen uncomment below (may conflict with status bar)
            //Window.SetFlags(WindowManagerFlags.LayoutNoLimits, WindowManagerFlags.LayoutNoLimits);

            if (Build.VERSION.SdkInt >= BuildVersionCodes.Lollipop)
            {
                Window.AddFlags(WindowManagerFlags.DrawsSystemBarBackgrounds);
                Window.ClearFlags(WindowManagerFlags.TranslucentStatus);
                Window.SetStatusBarColor(Android.Graphics.Color.Transparent);
            }

            if (Build.VERSION.SdkInt >= BuildVersionCodes.M)
            {
                var flags = (int)Window.DecorView.SystemUiVisibility;
                var currentTheme = AppInfo.RequestedTheme;
                if (currentTheme == AppTheme.Light)
                {
                    // Dark icons on light background
                    flags |= (int)SystemUiFlags.LightStatusBar;
                }

                Window.DecorView.SystemUiVisibility = (StatusBarVisibility)flags;
            }
            CrossFingerprint.SetCurrentActivityResolver(() => this);
        }
        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, Permission[] grantResults)
        {
            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
            Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
    }
}
