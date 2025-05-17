using System.Threading.Tasks;

namespace DesignApp.View;

public partial class ProfilePage : ContentPage
{
	public ProfilePage()
	{
        InitializeComponent();
	}

    private async void TapGestureRecognizer_Tapped_1(object sender, TappedEventArgs e)
    {
        await Navigation.PopAsync();
    }

    private void Stepper_ValueChanged(object sender, ValueChangedEventArgs e)
    {
        AgeEntry.Text = e.NewValue.ToString("0");
    }
}