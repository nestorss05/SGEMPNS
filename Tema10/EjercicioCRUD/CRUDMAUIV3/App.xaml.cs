using CRUDMAUIV3.Views;

namespace CRUDMAUIV3
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new BarraNav());
        }
    }
}
