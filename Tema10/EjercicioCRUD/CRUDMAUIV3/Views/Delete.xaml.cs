using CRUDMAUIV3.Models;
using CRUDMAUIV3.Models.ViewModels;

namespace CRUDMAUIV3.Views;

public partial class Delete : ContentPage
{
	public Delete(PersonaListaDepartamentos personaSeleccionada)
	{
		InitializeComponent();
		BindingContext = new DeleteVM { PersonaSeleccionada = personaSeleccionada };

    }
}