using System.Collections;
using System.Collections.ObjectModel;
using static DesignApp.Model.SystemPreferances;

namespace DesignApp.View;

public partial class HomePage : ContentPage
{
    public HomePage()
	{
		InitializeComponent();
        BindingContext = this;
	}

    private async void ImageButton_Clicked(object sender, EventArgs e)
    {
        NavigationState.LastTabRoute = Shell.Current.CurrentItem.Route;
        await Shell.Current.GoToAsync("///Settings");
    }
}