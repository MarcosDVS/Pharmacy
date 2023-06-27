using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using FarmaciaDyM.Data.Entities;

namespace FarmaciaDyM.Data.Request
{
    public class ProveedorRequest
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "El nombre del nombre es obligatorio")]
        public string Nombre { get; set; } = null!;
        [Required(ErrorMessage = "El telefono del nombre es obligatorio")]
        public string? Telefono { get; set; }
    }
}

