using lib_entidades;

namespace lib_repositorios.Interfaces
{
    public interface INotasRepositorio
    {
        List<Notas> Listar();
        Notas Guardar(Notas entidad);
        Notas Modificar(Notas entidad);
        Notas Borrar(Notas entidad);
    }
}