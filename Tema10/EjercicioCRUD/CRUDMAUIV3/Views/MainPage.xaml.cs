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
            base.OnAppearing();
            PersonaDepartamentoVM miVM = BindingContext as PersonaDepartamentoVM;
            miVM?.Refrescar();
            // TODO: arreglar el refrescamiento
        }
    }

}
