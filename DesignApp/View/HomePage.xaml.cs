using System.Collections;
using System.Collections.ObjectModel;

namespace DesignApp.View;

public partial class HomePage : ContentPage
{
    public HomePage()
	{
		InitializeComponent();
        BindingContext = this;
	}

    protected override void OnAppearing()
    {
        base.OnAppearing();
        Device.StartTimer(TimeSpan.FromSeconds(3), () =>
        {
            if (MyCarousel.ItemsSource is IList items && items.Count > 0)
            {
                var nextIndex = (MyCarousel.Position + 1) % items.Count;
                MyCarousel.Position = nextIndex;
            }
            return true; // repeat timer
        });
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