using lib_entidades;

namespace lib_aplicaciones.Interfaces
{
    public interface INotasAplicacion
    {
        List<Notas> Listar();
        Notas Guardar(Notas entidad);
        Notas Modificar(Notas entidad);
        Notas Borrar(Notas entidad);
    }
}