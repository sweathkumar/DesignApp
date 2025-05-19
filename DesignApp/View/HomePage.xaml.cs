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
}