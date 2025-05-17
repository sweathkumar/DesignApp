using DesignApp.View;
using Microsoft.Maui.Controls;

namespace DesignApp
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();
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
