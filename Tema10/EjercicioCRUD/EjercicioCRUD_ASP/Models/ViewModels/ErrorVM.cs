namespace EjercicioCRUD_ASP.Models.ViewModels
{
    public class ErrorVM
    {
        private Exception exception;
        public Exception Exception { get { return exception; } }
        public ErrorVM(Exception exception)
        {
            this.exception = exception;
        }
    }
}
