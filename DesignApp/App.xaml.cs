using DesignApp.View;
using Plugin.Fingerprint.Abstractions;
using Plugin.Fingerprint;

namespace DesignApp
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            // Always start with AppShell
            MainPage = new AppShell();

            string screenLock = Preferences.Get("ScreenLock", "Disabled");

            // Navigate to Login if screen lock is enabled
            if (screenLock == "Enabled")
            {
                // Use absolute route to go directly to Login page
                Shell.Current.GoToAsync("///Login");
            }
            else
            {
                Authentication();
            }
        }
        async void Authentication()
        {
            try
            {
                var request = new AuthenticationRequestConfiguration("Scan your fingerprint!", "")
                {
                    FallbackTitle = "Use Pattern",
                    AllowAlternativeAuthentication = true,
                };
                var result = await CrossFingerprint.Current.AuthenticateAsync(request);
                if (result.Authenticated)
                {
                    MainPage = new Login();
                }
                else
                {
                    MainPage = new AppShell();
                }
            }
            catch (Exception ex)
            {
                MainPage = new AppShell();
            }
        }

    }
}
