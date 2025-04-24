using Examen_3.Models;
using Servicios_Jue.Clases;
using System.Linq;
using System.Web.Http;

namespace Examen_3.Controllers
{
    [RoutePrefix("api/login")]
    public class LoginController : ApiController
    {
        // POST: api/login/ingresar
        [HttpPost]
        [Route("ingresar")]
        public IHttpActionResult Ingresar([FromBody] Login login)
        {
            if (login == null || string.IsNullOrEmpty(login.Usuario) || string.IsNullOrEmpty(login.Clave))
            {
                return BadRequest("Usuario y Clave son obligatorios.");
            }

            clsLogin servicioLogin = new clsLogin
            {
                login = login
            };

            var respuesta = servicioLogin.Ingresar().ToList();

            if (respuesta.FirstOrDefault()?.Autenticado == true)
                return Ok(respuesta);
            else
                return Unauthorized(); // también podrías retornar `Ok(respuesta)` si siempre querés devolver info
        }
    }
}
