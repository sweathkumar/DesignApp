using DesignApp.ViewModel;
using static DesignApp.Model.SystemPreferances;

namespace DesignApp.View;

public partial class DesignPage : ContentPage
{
    public DesignViewModel ViewModel { get; set; }
    public DesignPage()
    {
        InitializeComponent();
        ViewModel = new DesignViewModel();
        this.BindingContext = ViewModel;
    }

    private async void ImageButton_Clicked(object sender, EventArgs e)
    {
        NavigationState.LastTabRoute = Shell.Current.CurrentItem.Route;
        await Shell.Current.GoToAsync("///Settings");
    }
}