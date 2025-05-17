using System.Threading.Tasks;

namespace DesignApp.View;

public partial class AboutPage : ContentPage
{
	public AboutPage()
	{
		InitializeComponent();
	}

    private async void Button_Clicked(object sender, EventArgs e)
    {
        try
        {
            var url = "https://alco.framer.website"; // your actual site
            await Launcher.Default.OpenAsync(new Uri(url));
        }
        catch (FeatureNotSupportedException)
        {
            // Email is not supported on this device
            await DisplayAlert("Error", "Email is not supported on this device.", "OK");
        }
        catch (Exception ex)
        {
            // Some other error occurred
            await DisplayAlert("Error", $"An error occurred: {ex.Message}", "OK");
        }
    }

    private async void TapGestureRecognizer_Tapped(object sender, TappedEventArgs e)
    {
        await Navigation.PushAsync(new ProfilePage());
    }
}