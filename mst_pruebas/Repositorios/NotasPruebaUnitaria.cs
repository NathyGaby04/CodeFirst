using lib_entidades;
using lib_repositorios;
using lib_repositorios.Implementaciones;
using lib_repositorios.Interfaces;

namespace mst_pruebas.Repositorios
{
    [TestClass]
    public class NotasPruebaUnitaria
    {
        private INotasRepositorio? iRepositorio = null;
        private Notas? entidad = null;

        public NotasPruebaUnitaria()
        {
            var conexion = new Conexion();
            conexion.StringConnection = "server=localhost;database=db_notas;uid=sa;pwd=Clas3sPrO2024_!;TrustServerCertificate=true;";
            iRepositorio = new NotasRepositorio(conexion);
        }

        [TestMethod]
        public void Ejecutar()
        {
            Guardar();
            Listar();
            Modificar();
            Borrar();
        }

        private void Guardar()
        {
            entidad = new Notas()
            {
                Persona = "Test 2",
                Nota1 = 1.2m,
                Nota2 = 2.5m,
                Nota3 = 4.5m,
                Nota4 = 3.8m,
                Nota5 = 4.3m,
                Final = 0.0m,
                Fecha = DateTime.Now,
            };
            entidad = iRepositorio!.Guardar(entidad);
            Assert.IsTrue(entidad.Id != 0);
        }

        private void Listar()
        {
            var lista = iRepositorio!.Listar();
            Assert.IsTrue(lista.Count > 0);
        }

        private void Modificar()
        {
            entidad!.Final = 3.0m;
            entidad = iRepositorio!.Modificar(entidad!);

            Assert.IsTrue(entidad!.Final == 3.0m);
        }

        private void Borrar()
        {
            entidad = iRepositorio!.Borrar(entidad!);

            Assert.IsTrue(entidad!.Final == 3.0m);
        }
    }
}