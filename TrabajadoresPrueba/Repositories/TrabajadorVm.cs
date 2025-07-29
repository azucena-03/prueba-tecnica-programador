using System.ComponentModel.DataAnnotations;

namespace TrabajadoresPrueba.Repositories
{
    public class TrabajadorVm
    {
        public int Id { get; set; }
        [Required]
        public string? TipoDocumento { get; set; }
        [Required]
        public string? NumeroDocumento { get; set; }
        [Required]
        public string? Nombres { get; set; }
        [Required]
        public string? Sexo { get; set; }
        [Required]
        public string? Departamento { get; set; }
        [Required]
        public string? Provincia { get; set; }
        [Required]
        public string? Distrito { get; set; }
    }
}
