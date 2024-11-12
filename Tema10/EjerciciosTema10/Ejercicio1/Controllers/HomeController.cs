using Ejercicio1.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using System.Diagnostics;

namespace Ejercicio1.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AbrirConexion()
        {
            SqlConnection miConexion = new SqlConnection();
            String estadoConexion;

            try
            {
                miConexion.ConnectionString = "Server=tcp:nestorss.database.windows.net,1433;Initial Catalog=EusebioNS;Persist Security Info=False;User ID=usuario;Password=Lacampana123;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
                miConexion.Open();
                estadoConexion = miConexion.State.ToString();
            } catch (Exception ex) {
                estadoConexion = "Error: " + ex.Message;
            } finally
            {
                if (miConexion.State == System.Data.ConnectionState.Open)
                {
                    miConexion.Close();
                }
            }

            ViewBag.EstadoConexion = estadoConexion;

            return View("Index");
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
