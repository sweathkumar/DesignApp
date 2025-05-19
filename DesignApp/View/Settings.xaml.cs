using Microsoft.Maui.Controls.PlatformConfiguration;
using static DesignApp.Model.SystemPreferances;

namespace DesignApp.View;

public partial class Settings : ContentPage
{
    public Settings()
    {
        InitializeComponent();
        // Get saved theme (default to Light if not set)
        string savedTheme = Preferences.Get("AppTheme", "Light");
        string ScreenLock = Preferences.Get("ScreenLock", "Disabled");
        if (savedTheme == "Light") { ThemeSwitchToggle.IsToggled = false; } else { ThemeSwitchToggle.IsToggled = true; }
        if (ScreenLock == "Enabled") { LockSettings.IsVisible = true; lockToggleSwitch.IsToggled = true; lockToggle.Text = "Enabled"; } else { LockSettings.IsVisible = false; lockToggleSwitch.IsToggled = false; lockToggle.Text = "Disabled"; }
        AdditionalSettings.IsVisible = false;
        AdditionalSettingsNew.IsVisible = false;
        AdditionalArrow.Rotation = 180;
    }

    private void Switch_Toggled(object sender, ToggledEventArgs e)
    {
        if (e.Value)
        {
            ThemeSwitch.Text = "Dark";
            Application.Current.UserAppTheme = AppTheme.Dark;
            Preferences.Set("AppTheme", "Dark");
        }
        else
        {
            ThemeSwitch.Text = "Light";
            Application.Current.UserAppTheme = AppTheme.Light;
            Preferences.Set("AppTheme", "Light");
        }
    }

    private async void TapGestureRecognizer_Tapped(object sender, TappedEventArgs e)
    {
        var lastTab = NavigationState.LastTabRoute;
        await Shell.Current.GoToAsync($"//{lastTab}");
    }

    private void lockToggleSwitch_Toggled(object sender, ToggledEventArgs e)
    {
        if (e.Value)
        {
            lockToggle.Text = "Enabled";
            Preferences.Set("ScreenLock", "Enabled");
            LockSettings.IsVisible = true;
        }
        else
        {
            lockToggle.Text = "Disabled";
            Preferences.Set("ScreenLock", "Disabled");
            LockSettings.IsVisible = false;
            AdditionalSettings.IsVisible = false;
            AdditionalSettingsNew.IsVisible = false;
        }
    }

    private void TapGestureRecognizer_Tapped_1(object sender, TappedEventArgs e)
    {
        string savedPasscode = Preferences.Get("Passcode", string.Empty);
        if (savedPasscode != "")
        {
            if (AdditionalSettings.IsVisible)
            {
                AdditionalSettings.IsVisible = false;
                AdditionalArrow.Rotation = 180;
            }
            else
            {
                AdditionalSettings.IsVisible = true;
                AdditionalArrow.Rotation = 270;
            }
        }
        else
        {
            if (AdditionalSettingsNew.IsVisible)
            {
                AdditionalSettingsNew.IsVisible = false;
                AdditionalArrow.Rotation = 180;
            }
            else
            {
                AdditionalSettingsNew.IsVisible = true;
                AdditionalArrow.Rotation = 270;
            }
        }
    }

    private async void TapGestureRecognizer_Tapped_2(object sender, TappedEventArgs e)
    {
        string ScreenLock = Preferences.Get("ScreenLock", "Disabled");
        if(ScreenLock == "Enabled")
        {
            await Shell.Current.GoToAsync($"//Login");
        }
        else
        {
            Application.Current.Quit();
        }
    }
}