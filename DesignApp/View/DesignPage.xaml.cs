using DesignApp.ViewModel;

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
    private void ImageButton_Clicked(object sender, EventArgs e)
    {
        if (Application.Current.MainPage is TabbedPage tabbedPage)
        {
            tabbedPage.CurrentPage = tabbedPage.Children[3];
        }
    }

    private async void TapGestureRecognizer_Tapped(object sender, TappedEventArgs e)
    {
        await Navigation.PushAsync(new ProfilePage());
    }
}