using System.Threading.Tasks;
using static DesignApp.Model.SystemPreferances;

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

    private async void ImageButton_Clicked(object sender, EventArgs e)
    {
        NavigationState.LastTabRoute = Shell.Current.CurrentItem.Route;
        await Shell.Current.GoToAsync("///Settings");
    }
}