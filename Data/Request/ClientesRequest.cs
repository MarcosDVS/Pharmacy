using System.ComponentModel.DataAnnotations;
using FarmaciaDyM.Data.Entities;

namespace FarmaciaDyM.Data.Request
{
    public class ClientesRequest
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "El telefono del cliente es obligatorio")]
        public DateTime Fecha { get; set; }
        public string Nombre { get; set; } = null!;
        [Required(ErrorMessage = "El telefono del cliente es obligatorio")]
        public string Telefono { get; set; } = null!;
        [Required(ErrorMessage = "la direccion del cliente es obligatorio")]
        public string Direccion { get; set; } = null!;
        public ICollection<Venta> Ventas { get; set; } = null!;
    }
}
