using lib_entidades;
using lib_aplicaciones.Interfaces;
using lib_repositorios.Interfaces;

namespace lib_aplicaciones.Implementaciones
{
    public class NotasAplicacion : INotasAplicacion
    {
        private INotasRepositorio? iRepositorio = null;

        public NotasAplicacion(INotasRepositorio iRepositorio)
        {
            this.iRepositorio = iRepositorio;
        }

        public Notas Borrar(Notas entidad)
        {
            if (entidad == null)
                throw new Exception("lbFaltaInformacion");

            if (entidad.Id == 0)
                throw new Exception("lbNoSeGuardo");

            entidad = iRepositorio!.Borrar(entidad);
            return entidad;
        }

        public Notas Guardar(Notas entidad)
        {
            if (entidad == null)
                throw new Exception("lbFaltaInformacion");

            if (entidad.Id != 0)
                throw new Exception("lbYaSeGuardo");

            entidad = Calcular(entidad);
            entidad = iRepositorio!.Guardar(entidad);
            return entidad;
        }

        public List<Notas> Listar()
        {
            return iRepositorio!.Listar();
        }

        public Notas Modificar(Notas entidad)
        {
            if (entidad == null)
                throw new Exception("lbFaltaInformacion");

            if (entidad.Id == 0)
                throw new Exception("lbNoSeGuardo");

            entidad = Calcular(entidad);
            entidad = iRepositorio!.Modificar(entidad);
            return entidad;
        }

        private Notas Calcular(Notas entidad)
        {
            entidad.Final = (entidad.Nota1 +
                entidad.Nota2 +
                entidad.Nota3 +
                entidad.Nota4 +
                entidad.Nota5) / 5;
            entidad.Fecha = DateTime.Now;
            return entidad;
        }
    }
}