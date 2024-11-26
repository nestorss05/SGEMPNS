using CRUDMAUIV3.Models.ViewModels;

namespace CRUDMAUIV3.Views
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private void ContentPage_Appearing(object sender, EventArgs e)
        {
            PersonaDepartamentoVM miVM = this.BindingContext as PersonaDepartamentoVM;
            // TODO: llamar a metodo para refrescar listado
        }
    }

}
