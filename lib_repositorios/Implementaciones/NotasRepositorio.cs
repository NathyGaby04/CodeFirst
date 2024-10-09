using lib_entidades;
using lib_repositorios.Interfaces;

namespace lib_repositorios.Implementaciones
{
    public class NotasRepositorio : INotasRepositorio
    {
        private Conexion? conexion = null;

        public NotasRepositorio(Conexion conexion)
        {
            this.conexion = conexion;
        }

        public List<Notas> Listar()
        {
            return conexion!.Listar<Notas>();
        }

        public Notas Guardar(Notas entidad)
        {
            conexion!.Guardar(entidad);
            conexion!.GuardarCambios();
            return entidad;
        }

        public Notas Modificar(Notas entidad)
        {
            conexion!.Modificar(entidad);
            conexion!.GuardarCambios();
            return entidad;
        }

        public Notas Borrar(Notas entidad)
        {
            conexion!.Borrar(entidad);
            conexion!.GuardarCambios();
            return entidad;
        }
    }
}