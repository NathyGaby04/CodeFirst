using lib_aplicaciones.Implementaciones;
using lib_aplicaciones.Interfaces;
using lib_entidades;
using lib_repositorios;
using lib_repositorios.Implementaciones;
using lib_utilidades;
using Microsoft.AspNetCore.Mvc;

namespace asp_servicios.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class NotasController : ControllerBase
    {
        private INotasAplicacion? IAplicacion = null;

        public NotasController()
        {
            var conexion = new Conexion();
            conexion.StringConnection = "server=LAPTOP-1ITG8EDT\\SQLEXPRESS;database=db_notas;integrated security = true;TrustServerCertificate=true;";
            IAplicacion = new NotasAplicacion(
                new NotasRepositorio(conexion));
        }

        [HttpGet]
        public IEnumerable<Notas> Get()
        {
            var lista = IAplicacion!.Listar();
            return lista.ToArray();
        }

        [HttpPost]
        public string Listar()
        {
            var respuesta = new Dictionary<string, object>();
            try
            {
                var datos = ObtenerDatos();
                respuesta["Entidades"] = IAplicacion!.Listar();
                respuesta["Respuesta"] = "OK";
                respuesta["Fecha"] = DateTime.Now.ToString();
                return JsonHelper.ConvertirAString(respuesta);
            }
            catch (Exception ex)
            {
                respuesta["Error"] = ex.Message.ToString();
                return JsonHelper.ConvertirAString(respuesta);
            }
        }

        private Dictionary<string,object> ObtenerDatos()
        {
            var datos = new StreamReader (Request.Body).ReadToEnd().ToString();
            return JsonHelper.ConvertirAObjeto(datos);

        }

        [HttpPost]
        public string Guardar()
        {
            var respuesta = new Dictionary<string, object>();
            try
            {
                var datos = ObtenerDatos();

                var entidad = JsonHelper.ConvertirAObjeto<Notas>(
                    JsonHelper.ConvertirAString(datos["Entidad"]));
                entidad = IAplicacion!.Guardar(entidad);

                respuesta["Entidad"] = entidad;
                respuesta["Respuesta"] = "OK";
                respuesta["Fecha"] = DateTime.Now.ToString();
                return JsonHelper.ConvertirAString(respuesta);
            }
            catch (Exception ex)
            {
                respuesta["Error"] = ex.Message.ToString();
                return JsonHelper.ConvertirAString(respuesta);
            }
        }

        [HttpPost]
        public string Modificar()
        {
            var respuesta = new Dictionary<string, object>();
            try
            {
                var datos = ObtenerDatos();

                var entidad = JsonHelper.ConvertirAObjeto<Notas>(
                    JsonHelper.ConvertirAString(datos["Entidad"]));
                entidad = IAplicacion!.Modificar(entidad);

                respuesta["Entidad"] = entidad;
                respuesta["Respuesta"] = "OK";
                respuesta["Fecha"] = DateTime.Now.ToString();
                return JsonHelper.ConvertirAString(respuesta);
            }
            catch (Exception ex)
            {
                respuesta["Error"] = ex.Message.ToString();
                return JsonHelper.ConvertirAString(respuesta);
            }
        }

        [HttpPost]
        public string Borrar()
        {
            var respuesta = new Dictionary<string, object>();
            try
            {
                var datos = ObtenerDatos();

                var entidad = JsonHelper.ConvertirAObjeto<Notas>(
                    JsonHelper.ConvertirAString(datos["Entidad"]));
                entidad = IAplicacion!.Borrar(entidad);

                respuesta["Entidad"] = entidad;
                respuesta["Respuesta"] = "OK";
                respuesta["Fecha"] = DateTime.Now.ToString();
                return JsonHelper.ConvertirAString(respuesta);
            }
            catch (Exception ex)
            {
                respuesta["Error"] = ex.Message.ToString();
                return JsonHelper.ConvertirAString(respuesta);
            }
        }
    }
}