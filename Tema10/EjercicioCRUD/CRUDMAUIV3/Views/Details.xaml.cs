using CRUDMAUIV3.Models;
using CRUDMAUIV3.Models.ViewModels;

namespace CRUDMAUIV3.Views;

public partial class Details : ContentPage
{
	public Details(PersonaListaDepartamentos personaSeleccionada)
	{
		InitializeComponent();
		BindingContext = new DetailsVM { PersonaSeleccionada = personaSeleccionada };
	}
}