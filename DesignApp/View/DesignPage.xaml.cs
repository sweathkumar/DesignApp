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

    private void ToolbarItem_Clicked(object sender, EventArgs e)
    {

    }

    private void ImageButton_Clicked_1(object sender, EventArgs e)
    {
        ToolbarItem_Clicked(sender, e);
    }
}