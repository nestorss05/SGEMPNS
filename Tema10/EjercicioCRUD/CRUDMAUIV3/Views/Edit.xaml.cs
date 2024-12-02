using CRUDMAUIV3.Models;
using CRUDMAUIV3.Models.ViewModels;

namespace CRUDMAUIV3.Views;

public partial class Edit : ContentPage
{
	public Edit(PersonaListaDepartamentos personaSeleccionada)
	{
		InitializeComponent();
		BindingContext = new EditVM { PersonaSeleccionada = personaSeleccionada };
    }
}