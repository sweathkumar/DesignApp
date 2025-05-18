using DesignApp.Model;
using Microsoft.Maui;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace DesignApp.View;

public partial class Login : ContentPage
{
    public List<LoginModel> Pages { get; set; }
    public Login()
    {
        InitializeComponent();
        Pages = new List<LoginModel>
        {
            new LoginModel { PageOne = true, PageTwo = false, PageThree = false },
            new LoginModel { PageOne = false, PageTwo = true, PageThree = false },
            new LoginModel { PageOne = false, PageTwo = false, PageThree = true }
        };

        FormSlider.PositionChanged += FormSlider_PositionChanged;

        UpdateButtons(FormSlider.Position);
        this.BindingContext = this;
    }

    private void UpdateButtons(int position)
    {
        int lastIndex = Pages?.Count - 1 ?? 0;

        // Hide Back button on first page
        BackButton.IsVisible = position != 0;

        // Change Next button text to Submit on last page
        if (position == lastIndex)
        {
            NextButton.Text = "Submit";
            NextButton.IsEnabled = false;
            NextButton.BackgroundColor = (Color)Application.Current.Resources["Gray100"];
            NextButton.TextColor = (Color)Application.Current.Resources["Gray300"];
        }
        else
        {
            NextButton.Text = "Next";
            NextButton.IsEnabled = true;
            NextButton.BackgroundColor = (Color)Application.Current.Resources["Primary"];
            NextButton.TextColor = (Color)Application.Current.Resources["White"];
        }
    }

    private void Button_Clicked(object sender, EventArgs e)
    {
        int currentIndex = FormSlider.Position;

        if (currentIndex > 0)
        {
            FormSlider.Position = currentIndex - 1;
        }
    }

    private void Button_Clicked_1(object sender, EventArgs e)
    {
        int currentIndex = FormSlider.Position;
        int lastIndex = Pages?.Count - 1 ?? 0;

        if (currentIndex < lastIndex)
        {
            FormSlider.Position = currentIndex + 1;
        }
        else
        {
            Application.Current.MainPage = new AppShell();
        }
    }

    private void FormSlider_PositionChanged(object sender, PositionChangedEventArgs e)
    {
        UpdateButtons(e.CurrentPosition);
    }

    private void AgreementCheckBox_CheckedChanged(object sender, CheckedChangedEventArgs e)
    {
        if (FormSlider.Position == Pages.Count - 1)
        {
            NextButton.IsEnabled = e.Value;
            NextButton.BackgroundColor = (Color)Application.Current.Resources["Primary"];
            NextButton.TextColor = (Color)Application.Current.Resources["White"];
        }
    }
}