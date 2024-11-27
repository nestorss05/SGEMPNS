using CRUDMAUIV3.Models.ViewModels;

namespace CRUDMAUIV3.Views
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            if (BindingContext is PersonaDepartamentoVM miVM)
            {
                // TODO: arreglar el refrescamiento
                miVM?.Refrescar();
            }
        }
    }

}
