using DesignApp.View;
using Microsoft.Maui.Controls;

namespace DesignApp
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();
            // Get saved theme (default to Light if not set)
            string savedTheme = Preferences.Get("AppTheme", "Light");
            // Set the app theme
            Application.Current.UserAppTheme = savedTheme == "Dark" ? AppTheme.Dark : AppTheme.Light;
        }
        protected override void OnNavigating(ShellNavigatingEventArgs args)
        {
            base.OnNavigating(args);

            // Check if re-selecting Home Tab
            if (args.Source == ShellNavigationSource.ShellSectionChanged && args.Target.Location.OriginalString.Contains("//HomePage"))
            {
                // Reset Navigation to HomePage
                Shell.Current.GoToAsync("//HomePage", true);
            }
        }

    }
}
