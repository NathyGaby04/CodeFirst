using System.ComponentModel.DataAnnotations;

namespace lib_entidades
{
    public class Notas
    {
        [Key] public int Id { get; set; }
        public string? Persona { get; set; }
        public decimal Nota1 { get; set; }
        public decimal Nota2 { get; set; }
        public decimal Nota3 { get; set; }
        public decimal Nota4 { get; set; }
        public decimal Nota5 { get; set; }
        public decimal Final { get; set; }
        public DateTime Fecha { get; set; }
    }
}
