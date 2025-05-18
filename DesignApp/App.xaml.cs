using DesignApp.View;

namespace DesignApp
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            MainPage = new Login();

        }

    }
}
