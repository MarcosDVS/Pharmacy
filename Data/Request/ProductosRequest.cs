using FarmaciaDyM.Data.Entities;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FarmaciaDyM.Data.Request
{
    public class ProductosRequest
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "El codigo del producto es obligatorio")]
        public string Codigo { get; set; } = null!;
        [Required(ErrorMessage = "El nombre del producto es obligatorio")]
        public string Nombre { get; set; } = null!;
        public decimal Costo { get; set; }
        [Required(ErrorMessage = "El precio del producto es obligatorio")]
        public decimal Precio { get; set; }
        [Required(ErrorMessage = "La exixtencia del producto es obligatorio")]
        public int Existencia { get; set; }
        [Required(ErrorMessage = "La fecha de caducidad del producto es obligatorio")]
        public DateTime FechaDeCaducidad { get; set; } = DateTime.Now;
        public int ProveedorId { get; set; }

        [ForeignKey(nameof(ProveedorId))]
        public virtual Proveedor Proveedor { get; set; } = null!;

    }
}
